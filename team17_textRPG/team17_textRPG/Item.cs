namespace team17_textRPG
{

    class Item
    {
        public string Name { get; private set; }
        public int Effect { get; private set; }
        public static int hpPotion = 3;
        public static int getPotionCount = 0;
        public static int getGold;

        public Item()
        {
            Name = "체력회복포션";
            Effect = 30;
        }

        //회복 UI
        public void DisplayHealUI()
        {
            Console.Clear();
            Console.WriteLine("회복");
            Console.WriteLine($"포션을 사용하면 체력을 30 회복할 수 있습니다. (남은 포션 : {hpPotion})");
            Console.WriteLine();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            int result = Program.CheckInput(0, 1);

            switch (result)
            {
                case 0:
                    // Program.StartScene();
                    break;
                case 1:
                    UseHpPotion();
                    break;
            }
        }

        // 체력회복포션 사용
        public void UseHpPotion()
        {
            while (true)
            {
                if (hpPotion > 0)
                {
                    //현재 체력이 최대 체력보다 적을 때 -> 포션사용
                    if (Program.character.Hp < Program.character.MaxHp)
                    {
                        Console.Clear();
                        Console.WriteLine("체력이 회복되었습니다.");
                        Program.character.HealHp(Effect);
                        Console.WriteLine($"현재체력 : {Program.character.Hp}");
                        hpPotion--;
                        Console.WriteLine();
                        Console.WriteLine("1. 또 사용하기");
                        Console.WriteLine("0. 나가기");

                        int result = Program.CheckInput(0, 1);

                        switch (result)
                        {
                            case 1:
                                // UseHpPotion();
                                break;
                            case 0:
                                // Program.StartScene();
                                return;
                        }
                    }
                    else
                    {   //현재 체력이 최대 체력일 때 -> 포션 사용 불가
                        Console.WriteLine("최대 체력입니다. 체력을 회복할 수 없습니다.");
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        int result = Program.CheckInput(0, 0);
                        switch (result)
                        {
                            case 0:
                                // Program.StartScene();
                                // break;
                                return;
                        }
                    }
                }
                else // hpPotion (포션 갯수) <= 0
                {
                    Console.WriteLine("포션이 부족합니다.");
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");

                    int result = Program.CheckInput(0, 0);
                    switch (result)
                    {
                        case 0:
                            // Program.StartScene();
                            // break;
                            return;
                    }
                }
            }
        }
        // 몬스터 사냥시 체력회복포션 획득      
        public void GetHpPotion()
        {
            Random rand = new Random();
            int chance = rand.Next(0, 100);
            if (chance < 50) // 50% 확률

            {   
                //Console.WriteLine("체력회복포션을 1개 얻었습니다.");
                hpPotion ++;
                getPotionCount ++;
            }
            else
            {
                return;
            }
        }


        public void GetGold()
        {
            Random rand = new Random();
            int chance = rand.Next(0, 100);
            if (chance < 50) // 50% 확률
            {
                getGold += 100;
                Program.character.getGold += getGold;
            }
            else
            {
                return;
            }

        }
    }        

}

