﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team17_textRPG
{
    internal class Store
    {
        static Character character = Program.character;

        public static void ShowStore()
        {
            int result;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n상점\n");
                TextArt.ShopOwnerArt();
                Gears.ShowGears(1);
                Console.WriteLine($"\t\t\t\t\t골드 : {character.Gold}G");

                Console.WriteLine("\n1.장비 구매  0.나가기");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                Console.Write(">>");
                result = Program.CheckInput(0, 1);
                switch (result)
                {
                    case 0:
                        // Program.StartScene();
                        // break;
                        return;
                    case 1:
                        PurchaseGear();
                        break;
                }
            }
        }

        static void PurchaseGear()
        {
            int result, gearCount = Program.gearDb.Count(); ;
            string eff;
            Console.Clear();
            Console.WriteLine("\n상점\n");
            Gears.ShowGears(2);

            Console.WriteLine("\n구매하실 장비의 번호를 입력하세요  0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
            Console.Write(">>");
            result = Program.CheckInput(0, gearCount);
            int code = result;
            if (result == 0)
            {
                // ShowStore();
                return;
            }
            Gears gear = Program.gearDb[result - 1];
            if (result != 0)
            {
                Console.Clear();
                Console.WriteLine("\n상점\n");
                TextArt.GearArt(result);
                eff = gear.Type == 1 ? "공격력" : "방어력";
                Console.WriteLine($"- {gear.Name}   |  {eff} + {gear.Effect}   |  {gear.Desc}   |  {gear.Price}");
                Console.WriteLine("\n구매하시겠습니까?");
                Console.WriteLine("\n1.예  0.나가기");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                Console.Write(">>");

                result = Program.CheckInput(0, 1);
                switch (result)
                {
                    case 0:
                        // ShowStore();
                        // break;
                        return;
                    case 1:
                        if (character.Gold >= gear.Price && !character.GearsIHave[code - 1])
                        {
                            character.BuyItem(gear, code - 1);
                            Console.Clear();
                            Console.WriteLine("\n상점\n");
                            eff = gear.Type == 1 ? "공격력" : "방어력";
                            Console.WriteLine($"- {gear.Name}  | {eff}+{gear.Effect}  | {gear.Desc}  | {gear.Price}");
                            Console.WriteLine("\n구매를 완료하였습니다.");
                            Console.WriteLine("\n1.인벤토리 0.나가기");
                            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                            Console.Write(">>");
                            result = Program.CheckInput(0, 1);
                            switch (result)
                            {
                                case 0:
                                    // ShowStore();
                                    // break;
                                    return;
                                case 1:
                                    character.ShowInv();
                                    break;
                            }
                        }
                        else if (character.Gold < gear.Price)
                        {
                            Console.Clear();
                            Console.WriteLine("\n상점\n");
                            eff = gear.Type == 1 ? "공격력" : "방어력";
                            Console.WriteLine($"- {gear.Name}  | {eff}+{gear.Effect}  | {gear.Desc}  | {gear.Price}");
                            Console.WriteLine("\n골드가 부족합니다.");
                            Console.WriteLine("\n0.나가기");
                            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                            Console.Write(">>");
                            result = Program.CheckInput(0, 0);
                            // ShowStore();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n상점\n");
                            eff = Program.gearDb[result - 1].Type == 1 ? "공격력" : "방어력";
                            Console.WriteLine($"- {gear.Name}  | {eff}+{gear.Effect}  | {gear.Desc}  | {gear.Price}");
                            Console.WriteLine("\n이미 구매한 상품입니다.");
                            Console.WriteLine("\n0.나가기");
                            Console.WriteLine("\n원하시는 행동을 입력해 주세요.");
                            Console.Write(">>");
                            result = Program.CheckInput(0, 0);
                            // ShowStore();
                        }
                        return;
                }
            }
        }
    }
}
