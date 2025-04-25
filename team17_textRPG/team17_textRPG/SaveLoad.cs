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
            string folderPath = ".\\/save";
            string characterfilePath = ".\\/save/character.json";
            DirectoryInfo di = new DirectoryInfo(folderPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            string jsonStringCharacter = JsonConvert.SerializeObject(Program.character, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(characterfilePath, jsonStringCharacter);
        }

        public static void Load()
        {
            string characterfilePath = ".\\/save/character.json";
            string characterjsonString = File.ReadAllText(characterfilePath);
            if (File.Exists(characterfilePath))
            {
                Program.character = JsonConvert.DeserializeObject<Character>(characterjsonString);
                Program.StartScene();
            }
            else
            {
                Console.WriteLine("저장파일이 존재하지 않습니다.");
                Console.WriteLine("0.확인");
                Console.WriteLine("버튼을 입력해주세요");
                Console.Write(">>");

                Program.CheckInput(0, 0);
            }
        }
    }
}
