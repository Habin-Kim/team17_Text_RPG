using System.Security.Cryptography.X509Certificates;

namespace team17_textRPG
{

    
    class TextArt
    {
        // Console.OutputEncoding = System.Text.Encoding.UTF8; 
        public static void TextRpgArt()
        {
            Console.WriteLine("""
                                                                                                                
             _______ ________   _________   _____  _____   _____   __ ______ 
            |__   __|  ____\ \ / |__   __| |  __ \|  __ \ / ____| /_ |____  |
               | |  | |__   \ V /   | |    | |__) | |__) | |  __   | |   / / 
               | |  |  __|   > <    | |    |  _  /|  ___/| | |_ |  | |  / /  
               | |  | |____ / . \   | |    | | \ \| |    | |__| |  | | / /   
               |_|  |______/_/ \_\  |_|    |_|  \_|_|     \_____|  |_|/_/                                                                                                                           
            
            """);
        }
        public static void ShopOwnerArt()
        {
            
            string[] talk_shopOwner =
            {
                "어서 오시게! 천천히 구경해보게나. 좋은 물건들이 많다구.",
                "아직 도끼 들 힘은 충분하다고! 흐하하하핫",
                "옛날엔 나도 자네처럼 온갖 곳을 누비며 다녔지. 그립구만.",
                "...아직도 살지 말지 고민하고 있는건가?",
                "목숨이 달려있으니 장비엔 돈을 아끼지 말게. 모험에 질긴 목숨만큼 중요한 건 없거든."
            };
            Random rand = new Random();
            int i = rand.Next(0,5);

            Console.WriteLine(
            $"""                          
                    _____                                                                
                   /_____\   {talk_shopOwner[i]}                                          
                   (|0 0|)                                                    
                 __/(\U/)\_ ___/vvv                                                
                / \  (~)   / _|_P|                                                 
                | /\  ~   /_/   ||                                                 
                |_| (____)      ||                       
                \_]/______\  /\_||_/\ 
                   _\_||_/_ |] _||_ [|            
                  (_,_||_,_) \/ [] \/

            """);
        }
        public static void DocterArt() // Rest화면에서 쓰기
        {
            string[] talk_docter =
            {
                "모...모험가님! 피가...!!",
                "지금 당장 치료하지 않으면 목숨이 위험해요.",
                "호호. 겨우 주사가지고 엄살부리시는 건 아니죠?",
                "몸이 이지경이 될 때까지 어떻게 참으셨어요?",
                "전 모험가님처럼 몬스터들과 싸울 용기는 없답니다."
            };
            Random rand = new Random();
            int i = rand.Next(0,5);
            Console.WriteLine(
            $"""
                        .----. 
                       ===(_)==    
                      // 6  6 \\   
                    //(    7   )\\   {talk_docter[i]} 
                    (((\ '--' /)))
                   )))))\_ ._/(((((
                  (((((__)  (__)))))   
                    /"`/`\`V/`\`\
                   /   \  `Y _/_ \
                  / [DR]\_ |/ / /\
                  |     ( \/ / / /
            
            """);
        }
        public static void GearArt(int result)
        {   
            switch(result)
            {
                case 1:
                    Console.WriteLine("""
                       -=={==========*

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("초심자들이 주로 사용하는 검입니다. 둔탁해 보입니다.");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                    
                case 2:
                    Console.WriteLine("""     
                            /
                        O===[====================-
                            \

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("날카롭게 벼려진 날이 빛을 받아 반짝입니다.");
                    Console.ResetColor();
                    Console.WriteLine();

                    break;

                case 3:
                    Console.WriteLine("""
                            /| _________________
                        O|===|*>________________>
                            \|

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("...무엇이든 베어낼 수 있을 것 같습니다...");
                    Console.ResetColor();
                    Console.WriteLine();

                    break;
                
                case 4:
                    Console.WriteLine("""
                    |\---/\---/|
                    |    ||    |
                    |____()____|
                    |__((<>))__|
                    \    \/    /
                     \   ||   /
                      \__||__/

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("화살 자국이 몇개 보이지만 쓸만해보입니다.");
                    Console.ResetColor();
                    Console.WriteLine();

                    break;
                case 5:
                    Console.WriteLine("""
                        _..._
                    .-'_.---._'-.
                    ||####|(__)||
                    ((####|(**)))
                     '\###|_''/'
                      \\()|##//
                       \\ |#//
                        .\_/.

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("화려한 장식이 눈길을 끄는 방패입니다. 묵직함이 전해져옵니다.");
                    Console.ResetColor();
                    Console.WriteLine();
                    
                    break;
                
                case 6:
                    Console.WriteLine("""
                        |\ _..--.._ /|
                        |############|
                         )##########(
                      ._/##.'//\\'.##\_.
                       .__)#((()))#(__.
                        \##'.\\//.'##/
                         \####\/####/
                         /,.######.,\
                        (  \##__##/  )
                            "(\/)"
                              )(

                    """);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("조금의 기스도 보이지 않습니다.");
                    Console.WriteLine("...무엇이든 막아낼 수 있을 것 같습니다...");
                    Console.ResetColor();
                    Console.WriteLine();
                    
                    break;
            }

        }

        public void MonsterArt(string name)
        {
            Random rand = new Random();
            int i = rand.Next(0,3);

            //ms1 - monster sound "흡혈박쥐"
            string[] ms1 =
            {
                "츳츳츳츠츠츳",
                "쓰쓱, 쓰읏쓰",
                "츠퍄아아아!!!"
            };
            //ms2 - monster sound "독성옥토퍼스"
            string[] ms2 =
            {
                "꾸르륵...꾸르륵....",
                "부콰와아아악!!!",
                "꾸릉? 부웨에에엑"
            };
            //ms3 - monster sound "근육고릴라"
            string[] ms3 =
            {
                "크아아아아아!!!!",
                "바...나...나....",
                "죽...어...인간...."
            };

            switch(name)
            {
                case "흡혈박쥐":
                    Console.WriteLine(
                    $"""
                                                (_    ,_,    _) 
                                                / `'--) (--'` \
                                               /  _,-'\_/'-,_  \
                                              /.-'     "     '-.\
                                                 {ms1[i]}

                    """);
                    break;

                case "감염된옥토퍼스":
                    Console.WriteLine(
                    $"""
                                                        .'.'
                                                      .'-'.
                                                 .   (o O )
                                                   \_ `  _,   _
                                                -.___'.) ( ,-'
                                                     '-.O.'-..-..       
                                                 ./\/\/ | \_.-._
                                                        ;
                                                     ._/
                                                {ms2[i]} 

                    """);
                    break;

                case "근육고릴라":
                    Console.WriteLine(
                    String.Format("""
                                                       ."`".
                                                   .-./ _=_ \.-.
                                                  {  (,(oYo),) }}
                                                  {{ |   "   |} }
                                                  { { \(---)/  }}
                                                  {{  }'-=-'{ } }
                                                  { { }._:_.{  }}
                                                  {{  } -:- { } }
                                                  {_{ }`===`{  _}
                                                 ((((\)     (/))))
                                                  {0}          
                    
                    """, ms3[i]));
                    break;
                                            
            }
        }
    }
}

//         
//      .  .
//       \/
//      (@@)
//  g/\__)(__/\e
// g/\_(=--=)_/\e
//      //\\
//   g\_|  |_/e 
//
//  |\__/,|   (`\
//  |_ _  |.--.) )
//  ( T   )     /
// (((^_(((/(((_/}
