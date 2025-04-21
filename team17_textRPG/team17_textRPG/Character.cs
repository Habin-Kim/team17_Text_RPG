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

        public void ShowStats()
        {
            Console.WriteLine("Lv. {0:D2}", Lv);
            Console.WriteLine($"{Name} ({Job})");
            Console.WriteLine($"공격력: {Atk}");
            Console.WriteLine($"방어력: {Def}");
            Console.WriteLine($"체 력: {Hp}");
            Console.WriteLine($"Gold: {Gold}");
        }


    }
}
