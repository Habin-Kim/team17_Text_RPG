using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team17_textRPG
{
    internal class Gears
    {
        public string Name { get; private set; }
        public string Desc { get; private set; }
        public int Effect { get; private set; }
        public int Price { get; private set; }
        public int Type { get; private set; }
        public bool isHave { get; set; }
        public bool isEquipped { get; set; }

        public Gears(string name, string desc, int eff, int price, int type, bool ishave)
        {
            Name = name;
            Desc = desc;
            Effect = eff;
            Price = price;
            Type = type;
            isHave = ishave;
            isEquipped = false;
        }

        public static void ShowGears(int showType)
        {
            int gearCount = Program.gearDb.Count();
            int typeBefore = 0;
            string eff;

            for (int i = 0; i < gearCount; i++)
            {
                if (typeBefore != Program.gearDb[i].Type)
                {
                    switch (Program.gearDb[i].Type)
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
                eff = Program.gearDb[i].Type == 1 ? "공격력" : "방어력";
                Console.WriteLine($"-{(showType == 1 ? "" : i + 1)} {Program.gearDb[i].Name}  | {eff}+{Program.gearDb[i].Effect}  | {Program.gearDb[i].Desc}  | {(Program.gearDb[i].isHave ? "이미 구매한 상품입니다" :Program.gearDb[i].Price)}");
                typeBefore = Program.gearDb[i].Type;

            }

        }
    }
}   

