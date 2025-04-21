namespace team17_textRPG
{
    internal class Program
    {
        private static Character character;
        static void Main(string[] args)
        {
            
            CreateCharacter();
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
        static void StartScene()
        {
            int result;
            Console.Clear();
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\t3. 전투 시작");
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
                    character.ShowInv();
                    break;
                case 3:
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

        static int CheckInput(int min, int max)
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
