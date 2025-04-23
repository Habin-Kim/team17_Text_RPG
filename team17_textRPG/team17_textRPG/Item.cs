namespace team17_textRPG
{
    
    class Item
    {
        public string Name { get; private set; }
        public int Effect { get; private set; }
        static int hpPotion = 3;
        //private Character character = new Character();
        Program program = new Program();
        //int currentHP = player.Hp;


    
        public Item()
        {
            Name = "체력회복포션";
            Effect = 30;
        }

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

            int result = Program.CheckInput(0,1);

            switch(result)
            {
                case 0:
                {
                    break;;
                }
                case 1:
                    UseHpPotion();
                    break;
            }
        }

        public void UseHpPotion()
        {
            if (hpPotion > 0)
            {
                if(Program.character.Hp < Program.character.maxHp)
                {
                    Console.WriteLine("체력이 회복되었습니다.");
                    Program.character.PlusHp(Effect);
                    hpPotion --;
                }
                else
                {
                    Console.WriteLine("체력을 회복할 수 없습니다.");
                }
            }
            else
            {
                Console.WriteLine("포션이 부족합니다.");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");

                int result = Program.CheckInput(0,0);
                switch(result)
                {
                    case 0:
                    {
                        break;
                    }
                }
            }
        }
        public void GetHpPotion()
        {
            Random rand = new Random();
            int chance = rand.Next(0, 100);
            if (chance < 5)
            {   
                Console.WriteLine($"체력회복포션을 1개 얻었습니다.");
                hpPotion ++;
            }
            else
            {
                return;
            }

        }
    }
}

