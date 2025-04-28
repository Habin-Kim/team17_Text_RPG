using System.Runtime.CompilerServices;

namespace team17_textRPG
{
    internal class Monsters
    {
        public string Name;
        public int Level;
        public int Atk;
        public int Hp;
        Item item = new Item();
        bool isDead = false;
        public static int deadMonsterCount;
        public int Exp { get; private set; }

        // 몬스터 레벨에 따라서 스탯 정해짐
        public Monsters(string name, int level, int atk, int hp ,int exp)
        {
            Name = name;
            Level = level;
            Atk = atk;
            Hp = hp;
            Exp = exp;
            isDead = false;
        }

        // 몬스터의 등장 수 랜덤하게
        public static List<Monsters> Spawn()
        {
            // 몬스터 종류 설정
            List<Monsters> monstersList = new List<Monsters>();

            // 등장할 몬스터 수 랜덤 설정 (1~4마리)
            Random random = new Random();
            int monsterCount = random.Next(1, 5);

            // 랜덤하게 몬스터 추가
            for (int i = 0; i < monsterCount; i++)
            {
                int monsterLevel = random.Next(1, 6); // 1~5 랜덤 5레벨 확률 낮춤

                // 레벨에 따른 몬스터 타입 선택
                if (monsterLevel <= 2)
                {
                    monstersList.Add(new Monsters("흡혈박쥐", 2, 5, 15, 10));
                }
                else if (monsterLevel <= 4)
                {
                    monstersList.Add(new Monsters("감염된옥토퍼스", 3, 9, 10, 20));
                }
                else
                {
                    monstersList.Add(new Monsters("근육고릴라", 5, 8, 25, 40));
                }
            }

            return monstersList;
        }

        // 몬스터 등장 및 정보
        public void SpawnInfo()
        {
            Console.WriteLine($"Lv.{Level} {Name} 등장!!");
        }

        // 전투 시 출력 될 몬스터 정보
        public void BattleInfo()
        {
            if (Hp<=0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Lv.{Level} {Name} Dead");
            }
            else
            {
                Console.WriteLine($"Lv.{Level} {Name}  HP: {Hp}");
            }
            Console.ResetColor();
        }

    }
}
