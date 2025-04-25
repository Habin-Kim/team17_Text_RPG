using static System.Formats.Asn1.AsnWriter;

namespace team17_textRPG
{
    internal class Program
    {
        public static Character character { get; set; }
        public static Gears[] gearDb { get; set; }
        static void Main(string[] args)
        {
            MainMain();
            CreateCharacter();
            LoadGear();
            StartScene();
        }
        static void MainMain()
        {
            int getInt = 0;
            while (true)
            {
                Console.Clear();
                TextArt.TextRpgArt();
                Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("\n1.게임시작  2.불러오기");
                Console.WriteLine("\n번호를 입력해 주세요.");
                Console.Write(">>");
                getInt = CheckInput(1, 2);

                if (getInt == 1)
                {
                    return;
                }
                else
                {
                    int i = SaveLoad.Load();
                    if (i == 1)
                    {
                        StartScene();
                    }
                }
            }
        }
        static void CreateCharacter()
        {
            string getString;
            int getInt;
            Console.Clear();
            TextArt.TextRpgArt();
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n이름을 입력해 주세요.");
            Console.Write(">>");
            getString = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("\n직업을 선택해 주세요.");
            Console.WriteLine("\n1. 전사\n2. 도적");
            Console.Write("\n>>");
            getInt = CheckInput(1, 2);
            character = new Character(getString, getInt, 1, (getInt == 1? 100: 80), 1500, 0, 0, 0, new int[] { -1,-1,-1}, false);
        }
        public static void LoadGear()
        {
            gearDb = new Gears[]
            {
                new Gears("목검", "나무로 만든 검", 2, 500, 1),
                new Gears("철검","철로 만든 검", 5, 1000, 1),
                new Gears("강철검","강철로 만든 검", 10, 2000, 1),
                new Gears("목방패", "나무로 만든 방패", 2, 500, 2),
                new Gears("철방패","철로 만든 방패", 5, 1000, 2),
                new Gears("강철방패","강철로 만든 방패", 10, 2000, 2),
                new Gears("나무갑옷", "나무로 만든 갑옷", 2, 500, 3),
                new Gears("철갑옷","철로 만든 갑옷", 5, 1000, 3),
                new Gears("강철갑옷","강철로 만든 갑옷", 10, 2000, 3)
            };
        }
        public static void StartScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                Console.WriteLine("\n1. 상태 보기\n2. 상점\n3. 인벤토리\n4. 전투 시작\n5. 회복 아이템\n6. 치료하기\n7. 저장\n8. 불러오기");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                Console.Write(">>");
                int result = CheckInput(1, 8);
                switch (result)
                {
                    case 1:
                        // character.ShowStats();
                        ShowStats();
                        break;
                    case 2:
                        Store.ShowStore();
                        break;
                    case 3:
                        character.ShowInv();
                        break;
                    case 4:
                        BattleUI battleUI = new BattleUI();
                        battleUI.BattleStart();
                        break;
                    case 5:
                        Item itemclass = new Item();
                        itemclass.DisplayHealUI();
                        break;
                    case 6:
                        character.RestUI();
                        break;
                    case 7:
                        SaveLoad.Save();
                        //SaveLoad.SaveGear();
                        break;
                    case 8:
                        SaveLoad.Load();
                        //SaveLoad.LoadGear();
                        break;
                }
            }
        }

        static void ShowStats()
        {
            int result;
            character.ShowStats();
            result = CheckInput(0, 0);
            switch (result)
            {
                case 0:
                    // StartScene();
                    // break;
                    return;
            }
        }

        public static int CheckInput(int min, int max)
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out result);
                if (isNumber)
                {
                    if (result >= min && result <= max)
                        return result;
                }
                Console.WriteLine("잘못된 입력입니다!");
            }
        }
    }
}