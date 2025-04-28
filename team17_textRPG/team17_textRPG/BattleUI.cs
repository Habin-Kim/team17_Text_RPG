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
        Character character = Program.character;

        public Random rand = new Random();
        public List<Monsters> monsters = new List<Monsters>();
        //public Character character;
        Item item = new Item();
        TextArt textArt = new TextArt();


        public BattleUI()
        {
            monsters = Monsters.Spawn();
            //character = Program.character;
        }
        public void CharacterAttack(Character character, Monsters monster)
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[PlayerPhase]");
            Console.WriteLine();
            int errorRangeCA = (int)Math.Ceiling(character.totalAtk * 0.1);
            int damage = rand.Next(character.totalAtk - errorRangeCA, character.totalAtk + errorRangeCA + 1);

            bool isCritical = rand.Next(0, 100) < 15;
            if (isCritical)
            {
                damage = (int)Math.Ceiling(damage * 1.6f);
            }
            textArt.PlayerArt(character.Hp, character.MaxHp);
            Console.WriteLine($"{character.Name} 의 공격!");
            ApplyDamage(monster, damage, isCritical);
        }

        public void MonsterAttack(Monsters monster, Character character)
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[EnemyPhase]");
            Console.WriteLine();

            int errorRangeMA = (int)Math.Ceiling(monster.Atk * 0.1);
            int damage = rand.Next(monster.Atk - errorRangeMA, monster.Atk + errorRangeMA + 1);

            bool isCritical = rand.Next(0, 100) < 15;
            if (isCritical)
            {
                damage = (int)Math.Ceiling(damage * 1.6f);
            }

            textArt.MonsterArt(monster.Name);
            Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
            ApplyDamage(character, damage, isCritical);
        }
        public void ApplyDamage(Character character, int damage, bool isCritical)
        {

            Console.WriteLine($"Lv.{character.Lv} {character.Name} 을(를) 맞췄습니다. [데미지 : {damage}] {(isCritical ? "- 치명타 공격!!" : "")}");
            character.DecreaseHP(damage);
            Console.WriteLine($"\nLv.{character.Lv} {character.Name}\nHP {character.beforeHp} -> {character.Hp}");
        }

        public void ApplyDamage(Monsters monster, int damage, bool isCritical = false)
        {

            int originalHp = monster.Hp;
            monster.Hp -= damage;
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {damage}] {(isCritical ? "- 치명타 공격!!" : "")}");
                Console.WriteLine($"\nLv.{monster.Level} {monster.Name}\nHP {originalHp} -> Dead");
                Console.WriteLine($"\n경험치 {monster.Exp}를 얻었습니다.");
                Character.GetExp(monster.Exp);
                Monsters.deadMonsterCount++;
                item.GetHpPotion();
                item.GetGold();

            }
            else
            {
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {damage}] {(isCritical ? "- 치명타 공격!!" : "")}");
                Console.WriteLine($"\nLv.{monster.Level} {monster.Name}\nHP {originalHp} -> {monster.Hp}");
            }
        }

        public void BattleStart()
        {
            Console.Clear();

            //if (character.Hp != character.MaxHp)
            //{
            //    item.DisplayHealUI();
            //}

            //몬스터 생성 및 몬스터 정보
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].SpawnInfo();
            }
            //캐릭터 정보 불러오기
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{character.Lv} {character.Name} ({character.Jobs[character.JobCode - 1]})\nHP {character.Hp}");
            Console.WriteLine($"Exp.{character.CurrentExp}/{(character.Lv < 5 ? character.MaxExp[character.Lv - 1] : "000")}");
            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해 주세요.");
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
            while (true)
            {
                Console.Clear();

                if (Program.character.Hp <= 0)
                {
                    BattleResult battleResult = new BattleResult();
                    battleResult.Lose();
                    break;
                }
                //전투화면(캐릭터공격)

                //취소를 누르면 몬스터 공격 턴으로 넘어감.
                //캐릭터가 공격할 몬스터를 선택하면 공격
                //몬스터 정보 (타겟숫자표시)
                Console.WriteLine("Battle!!");
                Console.WriteLine();
                for (int i = 0; i < monsters.Count; i++)
                {

                    Console.Write($"{i + 1}. ");
                    monsters[i].BattleInfo();
                    //Console.WriteLine($"{i + 1}. Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].Hp}");
                }
                //캐릭터 정보 불러오기
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{character.Lv} {character.Name} ({character.Jobs[character.JobCode - 1]})\nHP {character.Hp}");
                Console.WriteLine($"Exp.{character.CurrentExp}/{(character.Lv < 5 ? character.MaxExp[character.Lv - 1] : "000")}");
                Console.WriteLine();
                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("대상을 선택해 주세요.");
                Console.Write(">>");

                // while (true)
                // {
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
                            CharacterAttack(Program.character, target);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("이미 죽은 몬스터 입니다.");
                            Console.WriteLine();
                            Console.WriteLine("0. 다음");
                            Console.Write(">>");
                            int missInput = Program.CheckInput(0, 0);
                            continue;
                        }
                        Console.WriteLine();
                        Console.WriteLine("0. 다음");
                        Console.Write(">>");
                        int input = Program.CheckInput(0, 0);
                        BattleEnemyPhase();
                        break;
                }
                bool allMonstersDead = monsters.TrueForAll(monsters => monsters.Hp <= 0);
                if (allMonstersDead)
                {
                    BattleResult battleResult = new BattleResult();
                    battleResult.Victory();
                    break;
                }
                // break;
                // BattleEnemyPhase();
                // }
            }
        }

        public void BattleEnemyPhase()
        {
            Console.Clear();
            //List<Monsters> monsters = new List<Monsters>();
            //전투화면 (몬스터공격)
            while (true)
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();
                Console.WriteLine("[EnemyPhase]");
                Console.WriteLine();
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].Hp > 0)
                    {
                        MonsterAttack(monsters[i], character);
                        Console.WriteLine();
                        Console.WriteLine("0. 다음");
                        Console.Write(">>");
                        textArt.FriendsHelp(character.Hp, character.MaxHp);

                        int result = Program.CheckInput(0, 0);
                    }
                    if (character.Hp <= 0)
                    {
                        // BattleResult battleResult = new BattleResult();
                        // battleResult.Lose();
                        break;
                    }
                }
                break;
                // BattleCharacterPhase();
            }
        }

    }

}

