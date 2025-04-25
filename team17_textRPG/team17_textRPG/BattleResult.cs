namespace team17_textRPG
{
    
    // 전투 결과
    public class BattleResult
    {
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
            //Console.WriteLine($"\n던전에서 체력회복포션 {Item.getPotionCount} 개를 얻었습니다.");
            Console.WriteLine();
            Monsters.deadMonsterCount = 0;
            Item.getPotionCount = 0;
            Console.WriteLine("\n[캐릭터 정보]");
            Console.WriteLine($"Lv. {Program.character.Lv:D2} {Program.character.Name}");
            Console.WriteLine($"HP {Program.character.MaxHp} -> {Program.character.Hp}");
            Console.WriteLine("\n[획득 아이템]");
            Console.WriteLine($"체력회복포션 {Item.getPotionCount} 개를 얻었습니다.");
            Console.WriteLine($"{Item.getGold} Gold 를 얻었습니다.");
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.Write(">> ");

            int result = Program.CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    Program.StartScene();
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

            Console.WriteLine($"Lv. {Program.character.Lv:D2} {Program.character.Name}");
            Console.WriteLine($"HP {Program.character.MaxHp} -> {Program.character.Hp}");
            Character.PlayerRevive();
            Console.WriteLine("0. 다음");
            Console.Write(">> ");

            int result = Program.CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    Program.StartScene();
                    break;
            }
        }
    }
}
