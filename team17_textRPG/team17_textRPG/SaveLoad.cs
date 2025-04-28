using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team17_textRPG
{
    internal class SaveLoad
    {
        public static void Save()
        {
            int result;
            Console.Clear();
            Console.WriteLine("\n저장하시겠습니까?");
            Console.WriteLine("1.예  2.아니요");
            Console.WriteLine("버튼을 입력해주세요");
            Console.Write(">>");

            result = Program.CheckInput(1, 2);
            if (result == 1)
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save");
                string characterfilePath = Path.Combine(folderPath, "character.json");
                DirectoryInfo di = new DirectoryInfo(folderPath);

                if (di.Exists == false)
                {
                    di.Create();
                }

                string jsonStringCharacter = JsonConvert.SerializeObject(Program.character, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(characterfilePath, jsonStringCharacter);

                SaveGear();
            }
            else
            {
                return;
            }
        }

        public static void SaveGear()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save");
            string gearfilePath = Path.Combine(folderPath, "gear.json");
            DirectoryInfo di = new DirectoryInfo(folderPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            string jsonStringGear = JsonConvert.SerializeObject(Program.gearDb, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(gearfilePath, jsonStringGear);

            Console.Clear();
            Console.WriteLine("\n저장이 완료되었습니다.");
            Console.WriteLine("1.확인");
            Console.WriteLine("버튼을 입력해주세요");
            Console.Write(">>");
            Program.CheckInput(1, 1);
        }

        public static int Load()
        {
            int result;
            Console.Clear();
            Console.WriteLine("\n불러오시겠습니까?");
            Console.WriteLine("1.예  2.아니요");
            Console.WriteLine("버튼을 입력해주세요");
            Console.Write(">>");

            result = Program.CheckInput(1, 2);
            if (result == 1)
            {
                string characterfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save", "character.json");
                string characterjsonString = File.ReadAllText(characterfilePath);
                if (File.Exists(characterfilePath))
                {
                    Program.character = JsonConvert.DeserializeObject<Character>(characterjsonString);
                    Program.LoadGear();
                    LoadGear();
                    return 1;
                }
                else
                {
                    Console.WriteLine("저장파일이 존재하지 않습니다.");
                    Console.WriteLine("0.확인");
                    Console.WriteLine("버튼을 입력해주세요");
                    Console.Write(">>");

                    Program.CheckInput(0, 0);
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static void LoadGear()
        {
            string gearfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save", "gear.json");
            string gearjsonString = File.ReadAllText(gearfilePath);
            if (File.Exists(gearfilePath))
            {
                Program.gearDb = JsonConvert.DeserializeObject<Gears[]>(gearjsonString);

                Console.Clear();
                Console.WriteLine("\n불러오기가 완료되었습니다.");
                Console.WriteLine("1.확인");
                Console.WriteLine("버튼을 입력해주세요");
                Console.Write(">>");
                Program.CheckInput(1, 1);
                return;
            }
            else
            {
                Console.WriteLine("저장파일이 존재하지 않습니다.");
                Console.WriteLine("0.확인");
                Console.WriteLine("버튼을 입력해주세요");
                Console.Write(">>");

                Program.CheckInput(0, 0);
                return;
            }
        }
    }
}
