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
             
            List<Monsters> monsters = new List<Monsters>();
            Character character = new Character();
            

            //몬스터 생성 및 몬스터 정보
            while (true)
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();
               
                foreach (Monsters monster in monsters)
                {
                    monster.SpawnInfo();
                }
                //캐릭터 정보
                Console.WriteLine($"{character.Name}\n{character.Lv} {character.Name} {character.Job}\n HP {character.Hp}");

                Console.WriteLine("1. 공격");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">>");

                int result = program.CheckInput(0, 1);

                switch (result)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("0. 취소");
                        Console.WriteLine();
                        Console.WriteLine("대상을 선택해 주세요.");
                        Console.Write(">>");
                        bool input = int.TryParse(Console.ReadLine(), out int choice);
                        if (!input || choice <0 || choice > monsters.Count)
                        {
                            Console.WriteLine("다시 선택해 주세요.");
                        }
                        else
                        {
                            int index = choice - 1;
                            Monsters target = monsters[index];
                            
                            CharacterAttack(character, target);
                        }
                       break;
                }
                
               


            }

            
            

            Console.WriteLine("1. 공격");


        }

    }
}
