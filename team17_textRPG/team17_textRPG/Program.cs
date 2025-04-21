namespace team17_textRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        
        static int CheckInput(int min, int max)
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out result);
                if (isNumber)
                {
                    if(result >= min && result <= max)
                        return result;
                }
                Console.WriteLine("잘못된 입력입니다!");
            }
        }
    }



}
