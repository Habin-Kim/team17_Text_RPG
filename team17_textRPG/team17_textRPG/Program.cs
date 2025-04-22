using static System.Formats.Asn1.AsnWriter;

namespace team17_textRPG
{
    internal class Program
    {
        public static Character character { get; set; }
        public static Gears[] gearDb { get; set; }
        static void Main(string[] args)
        {
            CreateCharacter();
            LoadGear();
            StartScene();
        }
        static void CreateCharacter()
        {
            string getString;
            int getInt;
            Console.Clear();
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
            character = new Character(getString, getInt);
        }
        static void LoadGear()
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
            int result;
            Console.Clear();
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("\n1. 상태 보기\n2. 상점\n3. 인벤토리\n4. 전투 시작");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            result = CheckInput(1, 2);
            switch (result)
            {
                case 1:
                    character.ShowStats();
                    ShowStats();
                    break;
                case 2:
                    Store.ShowStore();
                    break;
                case 3:
                    character.ShowInv();
                    break;
                case 4:
                    //전투시작
                    break;
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
                    StartScene();
                    break;
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
