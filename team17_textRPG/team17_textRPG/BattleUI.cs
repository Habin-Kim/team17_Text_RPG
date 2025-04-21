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
        private Random rand = new Random();

        public void CharacterAttack(Character character, Monster monster)
        {
            int errorRange = (int)Math.Ceiling(character.AttackPower * 0.1);
            int damage = rand.Next(player.AttackPower - errorRange, player.AttackPower + errorRange + 1);
            Console.WriteLine($"\n{player.Name} 의 공격!");
            ApplyDamage(monster, damage);
        }

        public void MonsterAttack(Monster monster, Player player)
        {
            int damage = rand.Next(4, 9);
            Console.WriteLine($"{monster.DisplayName()} 의 공격!");
            ApplyDamage(player, damage);
        }

        private void ApplyDamage(Monster monster, int damage)
        {
            if (!monster.IsAlive)
            {
                Console.WriteLine("잘못된 입력입니다 (이미 죽은 몬스터입니다).");
                return;
            }

            int originalHp = monster.Hp;
            monster.Hp -= damage;
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.WriteLine($"\n{monster.DisplayName()} 을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"{monster.DisplayName()}\nHP {originalHp} -> Dead");
            }
            else
            {
                Console.WriteLine($"\n{monster.DisplayName()} 을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"{monster.DisplayName()}\nHP {originalHp} -> {monster.Hp}");
            }
        }

        private void ApplyDamage(Player player, int damage)
        {
            int originalHp = player.Hp;
            player.Hp -= damage;
            if (player.Hp < 0) player.Hp = 0;
            Console.WriteLine($"\nLv.{player.Level} {player.Name} 을(를) 맞췄습니다.  [데미지 : {damage}]");
            Console.WriteLine($"Lv.{player.Level} {player.Name}\nHP {originalHp} -> {player.Hp}");
        }
    }
}
