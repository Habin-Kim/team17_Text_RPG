namespace team17_textRPG
{
    
    // 전투 결과
    public class BattleResult
    {
        // 이기면 빅토리 뜨고 체력 띄우기
        static void Victory()
        {
            Console.Clear();

            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVictory");
            Console.ResetColor();

            Console.WriteLine($"\n던전에서 몬스터 {KilledMonster}마리를 잡았습니다.");

            Console.WriteLine("Lv. {0:D2} {1}"Lv, Name);
            Console.WriteLine($"HP {MaxHp} -> {ResultHp}");

            Console.WriteLine("0. 다음");
            Console.Write(">> ");

            int result = CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    DisplayMainUI();
                    break;
            }
        }
        
        // 지면 루즈 뜨고 체력 띄우기
        static void Lose()
        {
            Console.Clear();

            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou Lose...");
            Console.ResetColor();

            Console.WriteLine("Lv. {0:D2} {1}"Lv, Name);
            Console.WriteLine($"HP {MaxHp} -> {ResultHp}");

            Console.WriteLine("0. 다음");
            Console.Write(">> ");

            int result = CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    DisplayMainUI();
                    break;
            }
        }
    }
}
