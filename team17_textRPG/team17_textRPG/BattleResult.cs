namespace team17_textRPG
{
    
    // 전투 결과
    public class BattleResult
    {
        Character character = Program.character;
        // 이기면 빅토리 뜨고 체력 띄우기
        public void Victory()
        {
            Console.Clear();
            
            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVictory");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"\n던전에서 몬스터 {Monsters.deadMonsterCount}마리를 잡았습니다.");
            Console.WriteLine();
            Console.WriteLine("\n[캐릭터 정보]");
            Console.WriteLine($"Lv. {character.Lv:D2} {character.Name}");
            Console.WriteLine($"HP {character.MaxHp} -> {character.Hp}");
            Console.WriteLine("\n[획득 아이템]");
            Console.WriteLine($"체력회복포션 {Item.getPotionCount} 개를 얻었습니다.");
            Console.WriteLine($"{Item.getGold} Gold 를 얻었습니다.");
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.Write(">> ");
            character.HpPotion += Item.getPotionCount;
            character.PlusGold();
            Monsters.deadMonsterCount = 0;
            Item.getPotionCount = 0;
            Item.getGold = 0;

            int result = Program.CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    TextArt textart = new TextArt();
                    textart.MeetFriendScene();
                    // Program.StartScene();
                    break;
            }
        }
        
        // 지면 루즈 뜨고 체력 띄우기
        public void Lose()
        {
            Console.Clear();

            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou Lose...");
            Console.ResetColor();
            Console.WriteLine($"Lv. {character.Lv:D2} {character.Name}");
            Console.WriteLine($"HP {character.MaxHp} -> {character.Hp}");
            Character.PlayerRevive();
            Console.WriteLine("0. 다음");
            Console.Write(">> ");
            Monsters.deadMonsterCount = 0;
            Item.getPotionCount = 0;
            Item.getGold = 0;

            int result = Program.CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("여신의 가호로 부활합니다.");
                    Console.ReadLine();
                    Program.StartScene();
                    break;
            }
        }
    }
}
