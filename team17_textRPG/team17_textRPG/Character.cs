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
        public int MaxHp {get; private set;}
        public int beforeHp{get; private set;}
        public int Gold { get; private set; }
        public int[] MaxExp { get; private set; }
        public int currentExp { get; private set; }
        private int extraAtk;
        private int extraDef;
        private int[] gearSlot = new int[] { 0, 0, 0 };
        private bool[] isSlotEmpty = new bool[] { true, true, true };

        public Character(string name, int jobCode)
        {
            Name = name;
            Job = Jobs[jobCode - 1];
            if (jobCode == 1)
            {
                Atk = 10;
                Def = 5;
                Hp = 100;
                MaxHp = 100;
            }
            else
            {
                Atk = 12;
                Def = 3;
                Hp = 80;
                MaxHp = 80;
            }
            Lv = 1;
            Gold = 1500;
            MaxExp = new int[] { 10, 35, 65, 100 };
            currentExp = 0;
        }

        //List<Item> itemList = new List<Item>();
        List<Gears> InventoryGears = new List<Gears>();
        List<Gears> EquippedGears = new List<Gears>();

        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("\n상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0:D2}", Lv);
            Console.WriteLine($"{Name} ({Job})");
            Console.WriteLine(extraAtk > 0 ? $"공격력: {Atk + extraAtk} +({extraAtk})" : $"공격력: {Atk}");
            Console.WriteLine(extraDef > 0 ? $"방어력: {Def + extraDef} +({extraDef})" : $"방어력: {Def}");
            Console.WriteLine($"체 력: {Hp}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine("\n0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
        }

        public void ShowInv()
        {
            int result;
            int InvGearCount = InventoryGears.Count;
            Console.Clear();
            Console.WriteLine("\n인벤토리");
            Console.WriteLine("인벤토리의 정보가 표시됩니다.\n");

            ShowInvList(1);
            Console.WriteLine("\n1.장착관리  0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            result = Program.CheckInput(0, 1);
            switch (result)
            {
                case 1:
                    EquipGear();
                    break;
                case 0:
                    Program.StartScene();
                    break;
            }
        }

        void ShowInvList(int type)
        {
            int typeBefore = 0;
            int InvGearCount = InventoryGears.Count;
            string eff;
            //for (int i = 0; i < itemCount; i++)
            //{
            //    Console.WriteLine($"{itemList[i].Name}   체력{itemList[i].Effect}회복");
            //}
            for (int i = 0; i < InvGearCount; i++)
            {
                if (typeBefore != InventoryGears[i].Type)
                {
                    switch (InventoryGears[i].Type)
                    {
                        case 1:
                            Console.WriteLine("[검]");
                            break;
                        case 2:
                            Console.WriteLine("\n[방패]");
                            break;
                        default:
                            Console.WriteLine("\n[갑옷]");
                            break;
                    }
                }
                eff = InventoryGears[i].Type == 1 ? "공격력" : "방어력";
                Console.WriteLine($"-{(type == 1 ? "" : i + 1)} {(InventoryGears[i].isEquipped ? "[E]" : "")}{InventoryGears[i].Name}  | {eff}+{InventoryGears[i].Effect}  | {InventoryGears[i].Desc}");
                typeBefore = Program.gearDb[i].Type;
            }
        }
        void EquipGear()
        {
            int result;
            int InvGearCount = InventoryGears.Count;
            Console.Clear();
            Console.WriteLine("\n인벤토리");
            Console.WriteLine("인벤토리의 정보가 표시됩니다.\n");
            ShowInvList(2);
            Console.WriteLine("\n장착할 장비의 번호를 입력하세요  0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");

            result = Program.CheckInput(1, InvGearCount);
            if (result != 0)
            {
                int iNum = result - 1;
                Gears gear = InventoryGears[result - 1];
                Console.Clear();
                Console.WriteLine("\n장착관리");
                Console.WriteLine("장착할 장비의 정보가 표시됩니다.\n");
                Console.WriteLine($"- {(gear.isEquipped ? "[E]" : "")}{gear.Name}  | {(gear.isEquipped ? "[E]" : "")}{(gear.Type == 1 ? "공격력" : "방어력")}+{gear.Effect}  | {gear.Desc}");
                if (gear.isEquipped)
                {
                    Console.WriteLine("\n1.해제  0.나가기");
                }
                else
                {
                    Console.WriteLine("\n1.장착  0.나가기");
                }
                Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                result = Program.CheckInput(0, 1);
                if (result != 0)
                {
                    if (gear.isEquipped)
                    {
                        EquippedGears.Remove(gear);
                        gear.isEquipped = false;
                        if (gear.Type == 1)
                        {
                            extraAtk -= gear.Effect;
                        }
                        else
                        {
                            extraDef -= gear.Effect;
                        }
                    }
                    else
                    {
                        EquippedGears.Add(gear);
                        gear.isEquipped = true;
                        if (gear.Type == 1)
                        {
                            if (gearSlot[0] != -1)
                            {
                                InventoryGears[gearSlot[0]].isEquipped = false;
                                EquippedGears.Remove(InventoryGears[gearSlot[0]]);
                            }
                            extraAtk += gear.Effect;
                            gearSlot[0] = iNum;
                        }
                        else if (gear.Type == 2)
                        {
                            if (gearSlot[1] != -1)
                            {
                                InventoryGears[gearSlot[1]].isEquipped = false;
                                EquippedGears.Remove(InventoryGears[gearSlot[1]]);
                            }
                            extraDef += gear.Effect;
                            gearSlot[1] = iNum;
                        }
                        else
                        {
                            if (gearSlot[2] != -1)
                            {
                                InventoryGears[gearSlot[2]].isEquipped = false;
                                EquippedGears.Remove(InventoryGears[gearSlot[2]]);
                            }
                            extraDef += gear.Effect;
                            gearSlot[2] = iNum;
                        }
                    }
                    ShowInv();
                }
                else
                {
                    ShowInv();
                }
            }
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
        public void HealHp(int amount)
        {
            Hp = Math.Min(Hp + amount, MaxHp);
        }

        public void PlayerGetDamage(int damage,bool isCritical)
        {
            int originalHp = Hp;
            Hp = originalHp-damage;
            Console.WriteLine($"\nLv.{Lv} {Name}");
            Console.WriteLine($"Hp {originalHp} -> {Hp}");
            
            if (Hp < 0)
            {
                Hp = 0;
            }
            
        }
        public void DecreaseHP(int damage)
        {
            beforeHp = Hp;
            Hp -= damage;
        }

        public void PlayerRevive()
        {
            Hp = MaxHp;
        }
    }
}
