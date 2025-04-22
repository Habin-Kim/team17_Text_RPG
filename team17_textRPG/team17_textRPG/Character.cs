namespace team17_textRPG
{
    internal class Character
    {
        public string Name { get; private set; }
        public string Job { get; private set; }
        private string[] Jobs = new string[] { "전사", "도적" };
        public int Lv { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Hp { get; private set; }
        public int Gold { get; private set; }
        public int[] MaxExp { get; private set; }
        public int currentExp { get; private set; }

        public Character(string name, int jobCode)
        {
            Name = name;
            Job = Jobs[jobCode - 1];
            if(jobCode == 1)
            {
                
                Atk = 10;
                Def = 5;
                Hp = 100;
            }
            else
            {
                Atk = 12;
                Def = 3;
                Hp = 80;
            }
            Lv = 1;
            Gold = 1500;
            MaxExp = new int[] { 10, 35, 65, 100 };
            currentExp = 0;
        }

        //List<Item> itemList = new List<Item>();
        List<Gears> InventoryGears = new List<Gears>();

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
            //int itemCount = itemList.Count;
            int InvGearCount = InventoryGears.Count;
            string eff;
            Console.Clear();
            Console.WriteLine("\n인벤토리");
            Console.WriteLine("인벤토리의 정보가 표시됩니다.\n");
            //for (int i = 0; i < itemCount; i++)
            //{
            //    Console.WriteLine($"{itemList[i].Name}   체력{itemList[i].Effect}회복");
            //}
            for (int i = 0; i < InvGearCount; i++)
            {
                eff = InventoryGears[i].Type == 1 ? "공격력" : "방어력";
                Console.WriteLine($"- {InventoryGears[i].Name}  | {eff}+{InventoryGears[i].Effect}  | {InventoryGears[i].Desc}");
            }
            Console.WriteLine("\n1.장착관리  0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
        }

        public void BuyItem(Gears gear)
        {
            InventoryGears.Add(gear);
            Gold -= gear.Price;
        }
        public void GetExp(int exp)
        {
            if (Lv == 5)
            {
                return;
            }
            else if (currentExp + exp < MaxExp[Lv - 1])
            {
                currentExp += exp;
                return;
            }
            else
            {
                Lv++;
                currentExp = 0;
                Console.WriteLine($"레벨 업!");
                GetExp(currentExp + exp - MaxExp[Lv - 2]);
            }
        }
    }
}
