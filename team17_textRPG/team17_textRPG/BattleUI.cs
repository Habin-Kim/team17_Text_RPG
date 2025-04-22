using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace team17_textRPG
{
    internal class BattleUI
    {
        public Random rand = new Random();
        Program program = new Program();
        public List<Monsters> monsters ;
        public Character character;

        public BattleUI(Character character, List<Monsters> monsters)
        {
            this.character = character;
            this.monsters = monsters;
        }
        public void CharacterAttack(Character character, Monsters monster)
        {
            int errorRangeCA = (int)Math.Ceiling(character.Atk * 0.1);
            int damage = rand.Next(character.Atk - errorRangeCA, character.Atk + errorRangeCA + 1);
            Console.WriteLine($"\n{character.Name} 의 공격!");
            ApplyDamage(monster, damage);
        }

        public void MonsterAttack(Monsters monster, Character character)
        {
            int errorRangeMA = (int)Math.Ceiling(monster.Atk * 0.1);
            int damage = rand.Next(monster.Atk - errorRangeMA, monster.Atk + errorRangeMA + 1);
            Console.WriteLine($"{monster.Level} {monster.Name} 의 공격!");
            ApplyDamage(character, damage);
        }
        public void ApplyDamage(Character character, int damage)
        {
            int originalHp = character.Hp;
            character.Hp -= damage;
            if (character.Hp < 0) character.Hp = 0;
            Console.WriteLine($"\nLv.{character.Lv} {character.Name} 을(를) 맞췄습니다.  [데미지 : {damage}]");
            Console.WriteLine($"Lv.{character.Lv} {character.Name}\nHP {originalHp} -> {character.Hp}");
        }

        public void ApplyDamage(Monsters monster, int damage)
        {
            int originalHp = monster.Hp;
            monster.Hp -= damage;
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.WriteLine($"\n{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"{monster.Level} {monster.Name}\nHP {originalHp} -> Dead");
            }
            else
            {
                Console.WriteLine($"\n{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"{monster.Level} {monster.Name}\nHP {originalHp} -> {monster.Hp}");
            }
        }

        public void BattleStart()
        {

            //List<Monsters> monsters = new List<Monsters>();
            //Character character = new Character();
            //전투화면

            //몬스터 생성 및 몬스터 정보
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].SpawnInfo();
            }
            //캐릭터 정보 불러오기
            Console.WriteLine($"{character.Name}\n{character.Lv} {character.Name} {character.Job}\n HP {character.Hp}");

            Console.WriteLine("1. 공격");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            int result = Program.CheckInput(1, 1);

            switch (result)
            {
                case 1:
                    BattleCharacterPhase();
                    break;
            }
        }
        public void BattleCharacterPhase()
        {
            //List<Monsters> monsters = new List<Monsters>();
            //Character character = new Character();
            //전투화면(캐릭터공격)

            //취소를 누르면 몬스터 공격 턴으로 넘어감.
            //캐릭터가 공격할 몬스터를 선택하면 공격
            //몬스터 정보 (타겟숫자표시)
            while (true)
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {monsters[i].Level} {monsters[i].Name} {monsters[i].Hp}");
                }
                //캐릭터 정보 불러오기
                Console.WriteLine($"{character.Name}\n{character.Lv} {character.Name} {character.Job}\n HP {character.Hp}");

                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("대상을 선택해 주세요.");
                Console.Write(">>");

                int result = Program.CheckInput(0, monsters.Count);
                switch (result)
                {
                    case 0:
                        //몬스터 공격 턴으로 넘어감.
                        BattleEnemyPhase();
                        break;
                    default:
                        //몬스터의 체력이 0보다 크면 공격
                        //몬스터의 체력이 0보다 작으면 공격 불가
                        int index = result - 1;
                        Monsters target = monsters[index];
                        if (target.Hp > 0)
                        {
                            CharacterAttack(character, target);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }
                        Console.WriteLine("0. 다음");
                        Console.ReadLine();

                        break;
                }
                bool allMonstersDead = monsters.TrueForAll(monsters => monsters.Hp == 0);
                if (allMonstersDead)
                {
                    BattleResult.Victory();
                    break;
                }
            }
        }
        public void BattleEnemyPhase()
        {
            //List<Monsters> monsters = new List<Monsters>();
            //전투화면 (몬스터공격)
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Hp > 0)
                {
                    MonsterAttack(monsters[i], character);
                    Console.WriteLine("0. 다음");
                    Console.ReadLine();
                }
                if (character.Hp <=0 )
                {
                    BattleResult.Lose();
                    break;
                }
            }

            }

        }

    }
}
