namespace team17_textRPG
{
    internal class Character
    {
        public string Name { get; private set; }
        public string Job { get; private set; }
        public int Lv { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Hp { get; private set; }
        public int Gold { get; private set; }

        public Character()
        {
            Name = "John";
            Job = "전사";
            Lv = 1;
            Atk = 10;
            Def = 5;
            Hp = 100;
            Gold = 1500;
        }

        List<Item> itemList = new List<Item>();

        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("\n상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0:D2}", Lv);
            Console.WriteLine($"{Name} ({Job})");
            Console.WriteLine($"공격력: {Atk}");
            Console.WriteLine($"방어력: {Def}");
            Console.WriteLine($"체 력: {Hp}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine("\n0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
        }

        public void ShowInv()
        {
            int itemCount = itemList.Count;
            Console.Clear();
            Console.WriteLine("\n인벤토리");
            Console.WriteLine("인벤토리의 정보가 표시됩니다.\n");
            for(int i  = 0; i < itemCount; i++)
            {
                Console.WriteLine($"{itemList[i].Name}   체력{itemList[i].Effect}회복");
            } 
            Console.WriteLine("\n1.장비  2.물약  0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
        }
    }
}
