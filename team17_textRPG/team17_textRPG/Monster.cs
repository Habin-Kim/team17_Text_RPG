using System.Runtime.CompilerServices;

namespace team17_textRPG
{
    internal class Monsters
    {
        public string Name;

        public int Level;
        public int Atk;
        public int Hp;

        bool isDead = false;

        public Monsters(string name, int level, int atk, int hp)
        {
            Name = name;
            Level = level;
            Atk = atk;
            Hp = hp;
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
                int monsterLevel = random.Next(1, 6); // 1~5레벨 랜덤
                Monsters newMonster = null;

                // 레벨에 따른 몬스터 타입 선택
                if (monsterLevel <= 2) // Lv2 미니언 (레벨 1~2)
                {
                    newMonster = new Monsters("Lv2 미니언", 2, 5, 15);
                }
                else if (monsterLevel <= 4) // Lv3 공허충 (레벨 3~4)
                {
                    newMonster = new Monsters("Lv3 공허충", 3, 9, 10);
                }
                else // Lv5 대포미니언 (레벨 5)
                {
                    newMonster = new Monsters("Lv5 대포미니언", 5, 8, 25);
                }

                if (newMonster != null)
                {
                    monstersList.Add(newMonster);
                }
            }

            return monstersList;
        }

        // 몬스터 등장 및 정보
        public void SpawnInfo()
        {
            Console.WriteLine($" Lv.{Level} {Name} 등장!!");
        }

        // 전투 시 출력 될 몬스터 정보
        public void BattleInfo()
        {
            Console.WriteLine($"Lv.{Level} {Name} HP {Hp}");
        }

        // 몬스터 피격
        public void Damage()
        {
            // 몬스터 체력 - 플레이어 공격 
            CheckDeath();
        }

        // 몬스터 공격
        public void Attack()
        {
            if(!isDead)
            {
                // 플레이어 체력 - 몬스터 공격력
            }
        }

        public void CheckDeath()
        {
            if(0 <= Hp)
            {
                isDead = true;
            }
        }
    }
}