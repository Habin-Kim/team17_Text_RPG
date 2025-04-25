
using System.Collections;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;


namespace team17_textRPG
{
    internal class Character
    {
        public string Name { get; private set; }
        private string Job;
        public string[] Jobs { get; private set; } = new string[] { "전사", "도적" };
        public int JobCode { get; private set; }
        public int Lv { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Hp { get; private set; }
        public int MaxHp {get; private set;}
        public int beforeHp{get; private set;}
        public int Gold { get; private set; }
        public int[] MaxExp { get; private set; }
        public int CurrentExp { get; private set; }
        public int ExtraAtk { get; private set; }
        public int ExtraDef { get; private set; }
        public bool[] GearsIHave = new bool[] { false, false, false, false, false, false, false, false, false };
        public int[] GearSlot { get; private set; } = new int[] { -1, -1, -1 };
        private bool[] isSlotEmpty = new bool[] { true, true, true };
        public int totalAtk => ExtraAtk + Atk;
        public int totalDef => ExtraDef + Def;
        public Character(string name, int jobCode, int lv, int hp, int gold, int currentExp, int extraAtk, int extraDef, int[] gearSlot)
        {
            Name = name;
            JobCode = jobCode;
            Job = Jobs[JobCode-1];
            
            if (jobCode == 1)
            {
                Atk = 10;
                Def = 5;
                Hp = hp;
                MaxHp = 100;
            }
            else
            {
                Atk = 12;
                Def = 3;
                Hp = hp;
                MaxHp = 80;
            }
            Lv = lv;
            Gold = gold;
            MaxExp = new int[] { 10, 35, 65, 100 };
            CurrentExp = currentExp;
            ExtraAtk = extraAtk;
            ExtraDef = extraDef;
            GearSlot = gearSlot;
        }

        //List<Item> itemList = new List<Item>();
        public List<Gears> InventoryGears = new List<Gears>();
        public List<Gears> EquippedGears = new List<Gears>();

        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("\n상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0:D2}", Lv);
            Console.WriteLine($"{Name} ({Job})");
            Console.WriteLine(ExtraAtk > 0 ? $"공격력: {Atk + ExtraAtk} +({ExtraAtk})" : $"공격력: {Atk}");
            Console.WriteLine(ExtraDef > 0 ? $"방어력: {Def + ExtraDef} +({ExtraDef})" : $"방어력: {Def}");
            Console.WriteLine($"체 력: {Hp}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Exp : {CurrentExp}/{(Lv < 5 ? MaxExp[Lv - 1] : "000")}");
            Console.WriteLine("\n0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
        }

        public void ShowInv()
        {
            int result;
            int InvGearCount = InventoryGears.Count;
            while (true)
            {
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
                        // Program.StartScene();
                        // break;
                        return;
                }
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
                    //switch (InventoryGears[i].Type)
                    //{
                    //    case 1:
                    //        Console.WriteLine("[검]");
                    //        break;
                    //    case 2:
                    //        Console.WriteLine("\n[방패]");
                    //        break;
                    //    default:
                    //        Console.WriteLine("\n[갑옷]");
                    //        break;
                    //}
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

            result = Program.CheckInput(0, InvGearCount);
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
                        //EquippedGears.Remove(gear);
                        gear.isEquipped = false;
                        if (gear.Type == 1)
                        {
                            EquippedGears.Remove(EquippedGears[GearSlot[0]]);
                            ExtraAtk -= gear.Effect;
                        }
                        else if(gear.Type == 2)
                        {
                            EquippedGears.Remove(EquippedGears[GearSlot[1]]);
                            ExtraDef -= gear.Effect;
                        }
                        else
                        {
                            EquippedGears.Remove(EquippedGears[GearSlot[2]]);
                            ExtraDef -= gear.Effect;
                        }
                    }
                    else
                    {
                        EquippedGears.Add(gear);
                        gear.isEquipped = true;
                        if (gear.Type == 1)
                        {
                            if (GearSlot[0] != -1)
                            {
                                ExtraAtk -= InventoryGears[GearSlot[0]].Effect;
                                InventoryGears[GearSlot[0]].isEquipped = false;
                                EquippedGears.Remove(EquippedGears[0]);
                            }
                            ExtraAtk += gear.Effect;
                            GearSlot[0] = iNum;
                        }
                        else if (gear.Type == 2)
                        {
                            if (GearSlot[1] != -1)
                            {
                                ExtraDef -= InventoryGears[GearSlot[1]].Effect;
                                InventoryGears[GearSlot[1]].isEquipped = false;
                                EquippedGears.Remove(EquippedGears[1]);
                            }
                            ExtraDef += gear.Effect;
                            GearSlot[1] = iNum;
                        }
                        else
                        {
                            if (GearSlot[2] != -1)
                            {
                                ExtraDef -= InventoryGears[GearSlot[2]].Effect;
                                InventoryGears[GearSlot[2]].isEquipped = false;
                                EquippedGears.Remove(EquippedGears[2]);
                            }
                            ExtraDef += gear.Effect;
                            GearSlot[2] = iNum;
                        }
                    }
                    // ShowInv();
                }
                // else
                // {
                //     // ShowInv();
                // }
            }
            return;
            // else
            // {
            //     // ShowInv();
            // }
        }

        public void BuyItem(Gears gear, int code)
        {
            InventoryGears.Add(gear);
            Gold -= gear.Price;
            GearsIHave[code] = true;
        }
        public static void GetExp(int exp)
        {
            if (Program.character.Lv == 5)
            {
                return;
            }
            else if (Program.character.CurrentExp + exp < Program.character.MaxExp[Program.character.Lv - 1])
            {
                Program.character.CurrentExp += exp;
                return;
            }
            else
            {
                Program.character.Lv++;
                if (Program.character.Lv == 5)
                {
                    Program.character.CurrentExp = 0;
                    return;
                }
                int upExp = Program.character.CurrentExp + exp - Program.character.MaxExp[Program.character.Lv - 2];
                Program.character.CurrentExp = 0;
                Console.WriteLine($"\n레벨 업!");
                GetExp(upExp);
            }
        }
        public void HealHp(int amount)
        {
            Hp = Math.Min(Hp + amount, MaxHp);
        }

        public void PlayerGetDamage(int damage, bool isCritical)
        {
            int decreasDamage = (int)Math.Round(damage - (totalDef) * 0.6f);

            if (decreasDamage <= 0)
            {
                decreasDamage = 1;
            }

            int originalHp = Hp;
            Hp = originalHp-decreasDamage;
            
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
      
        public static void PlayerRevive()
        {
            Program.character.Hp = Program.character.MaxHp;
        }
        public void RestUI()
        {
            Console.Clear();
            Console.WriteLine("치료하기");
            TextArt.DocterArt();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("500G ");
            Console.ResetColor();
            Console.WriteLine("를 내면 체력을 회복할 수 있습니다.");
            Console.WriteLine($"현재 체력 : {Hp}");
            Console.WriteLine($"보유 골드 : {Gold} G");
            Console.WriteLine();
            Console.WriteLine("1. 치료하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            int result = Program.CheckInput(0, 1);

            switch(result)
            {
                case 1 :
                    Console.Clear();
                    int originalHp = Hp;
                    PlayerRevive();
                    Gold -= 500;
                    Console.WriteLine($"체력이 모두 회복되었습니다. {originalHp} -> {Hp}");
                    Console.WriteLine($"보유 골드 : {Gold} G");
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.ReadLine();
                    goto case 0;

                case 0 :
                    // Program.StartScene();
                    break;
            }
        }
        public void PlusGold()
        {
            Gold += Item.getGold;
        }
    }
}
