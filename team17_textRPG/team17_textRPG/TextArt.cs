using System.Globalization;
using System.Security.Cryptography.X509Certificates;

// 이미지 출처 : https://www.asciiart.eu/
namespace team17_textRPG
{

    
    class TextArt
    {
        // Console.OutputEncoding = System.Text.Encoding.UTF8; 
        public static bool MeetFriendSceneHasRun = false; //저장기능에 추가해주세요. true일 때 동료도움 실행됨.
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
        
        //상점 주인
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

        //병원(치료하기) 주인
        public static void DocterArt()
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
        
        //장비 
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

        //몬스터 
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
                    """
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

                    """ + $"\t\t\t\t{ms3[i]}");
                    Console.WriteLine();
                    break;
            }
        }

        //플레이어
        public void PlayerArt(int hp, int maxhp)
        {
            Random rand = new Random();
            int i;
            double playerhp = (double)hp / maxhp;

            if(playerhp <= 0.2)
            {
                i = 4; // 체력이 20% 이하일 때만 출력되는 대사.
            }
            else if(playerhp <= 0.4)
            {
                i = 3; // 체력이 30% 이하일 때만 출력되는 대사.
            }
            else
            {
                i = rand.Next(0,3);
            }

            string[] talk_player =
            {
                "죽어라!!!",
                "히야아아아압!",
                "역겨운 몬스터놈들...",
                "으아아악아악!\n 나한테서 당장 떨어져!!",
                "크윽...더이상은..."        
            };
            Console.WriteLine(
            $"""
                 __      
                 /__\__  
                //_____\///
               _| /+_+\)|/_
              (___\ O //___\
              (  |\\_/// * \\
               \_| \_((*   *))
               ( |__|_\\  *//
               (o/  _  \_*_/
               //\__|__/\
              // |  | |  |
               {talk_player[i]}

            """);
        }
        
        //동료와 만나는 씬
        public void MeetFriendScene()
        {   
            
            if(MeetFriendSceneHasRun == false) //실행이 1번만 되도록.
            {
                Console.Clear();
                Console.WriteLine("멀리서 사람이 한 명 다가온다....");
                Console.ReadLine();
                int j = 0;
                string[] talk_friend =
                {
                    "몬스터를 단번에 죽이시다니. 대단해요!!",
                    "모험가신가요? 저도 모험가에요. 아직 초짜지만...헤헤",
                    "어?..상처가...",
                    "제가 치료해드릴게요",
                    "(여자의 몸 주위로 빛 입자가 퍼진다. 상처가 아문다.)",
                    "다 됐어요. 깊지 않아서 다행이에요. \n혼자 여행중이신가요?",
                    "(고개를 끄덕이자 여자가 환히 웃는다.)",
                    "그럼 같이 다녀요!!\n방금 보셨겠지만 전 치유마법사에요",
                    "둘이니까 몬스터도 더이상 무섭지 않을거에요!!"
                };

                for(int i=0; i<talk_friend.Length; i++)
                {
                    Console.Clear();
                    FriendsFace(j);
                    Console.WriteLine(talk_friend[i]);
                    Console.ReadLine();
                    if (i == 1)
                    {
                        j = 1;
                    }
                    else if(i == 5)
                    {
                        j = 2;
                    }
                }

                Console.Clear();
                Console.WriteLine("동료를 얻었습니다.");
                Console.ReadLine();
                Console.WriteLine("이제부터 위험에 처했을 때 동료가 당신을 돕습니다.");
                MeetFriendSceneHasRun = true;
                Console.ReadLine();
            }
        }

        //동료의 도움 -> 체력 15 회복
        public void FriendsHelp(int hp, int maxhp)
        {
            if(MeetFriendSceneHasRun == true)
            {
                Random rand = new Random(); 
                double playerhp = (double)hp / maxhp;
                if (playerhp <= 0.4) //플레이어 체력이 40% 이하일 때
                {
                    int chance = rand.Next(0, 100);
                    if (chance < 30) //30% 확률로 실행
                    {   
                        Console.ReadLine();
                        Console.Clear();
                        FriendsFace(3);
                        Program.character.HealHp(15);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("동료가 당신을 도우러 왔습니다");
                        Console.Write("체력이 ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("15 ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("회복되었습니다.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("0. 다음");
                    }
                }
            }
        }

        //동료 이미지
        public void FriendsFace(int number)
        {
            switch(number)
            {
                case 0:
                    Console.WriteLine(
                    """
                         ,-.,~~.
                       ,'///||\\`.
                      ///(((||)))\\.
                     (((  ,   ,  )))
                     _)))   -    |(_
                    ._//\   -   /\\_.
                    `-'_/`-._.-'\-`-'
                      ' \/=._.=\/ 

                    """);
                    break;
                
                case 1:
                    Console.WriteLine(
                    """
                         ,-.,~~.
                       ,'///||\\`.
                      ///(((||)))\\.
                     (((  ,   ,  )))
                     _)))   -    |(_
                    ._//\   O   /\\_.
                    `-'_/`-._.-'\-`-'
                      ' \/=._.=\/ 
                    
                    """);
                    break;

                case 2:
                    Console.WriteLine(
                    """
                         ,-.,~~.
                       ,'///||\\`.
                      ///(((||)))\\.
                     (((  ,   ,  )))
                     _)))   -    |(_
                    ._//\ '---'  /\\_.
                    `-'_/`-._.-'\-`-'
                      ' \/=._.=\/ 
                    
                    """);
                    break;

                case 3:
                    Console.WriteLine(
                    """
                      +     o    . _     .
                          +   .   (_)  +  +   o   +
                       o     ____   + Heal!!! _       o
                      _    ////())))  .  +   (_)   .      +
                     (_) _((({{( ,(     + +           _
                     o    _)))/' _/   ,_ ,      o    (_)
                      . O    _/-(_   /-_/      .  ,        o
                      +     / \/ \\_/ /  +  
                        o  /    ) )  /      o       O
                      
                    """);
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


//
//            ,
//             /:\
//             >:<
//             >:<
//             >:<
//        ,,,,,\:/
//       #########
//      //////\\\\\
//     // /_\ /_\ \\
//     \(  0 _ 0  )/
//     /\\=  _\ =//\
//     \\/\ --- /\//
//     //\ '---' /\\
//     \//       \\/
//     /\\       //\
//     \\/       \//
//      #         #
// jgs  "         "

//      ,-.,~~.
//    ,'///||\\`.
//   ///(((||)))\\.
//  (((  ,   ,  )))
//  _)))   -    |(_
// ._//\   -   /\\_.
// `-'_/`-._.-'\-`-'
//   ' \/=._.=\/ hjw

//                                                                o .,<>., o
//                                                                |\/\/\/\/|
//                                                                '========'
//                                                                (_ SSSSSSs
//                                                                )a'`SSSSSs
//                                                               /_   SSSSSS
//                                                               .=## SSSSS
//                                                               .####  SSSSs
//                                                               ###::::SSSSS
//                                                              .;:::""""SSS
//                                                             .:;:'  . .  \\
//                                                            .::/  '     .'|
//                                                           .::( .         |
//                                                           :::)           \
//                                                           /\(            /
//                                                          /)            ( |
//                                                        .'  \  .       ./ /
//                                                     _-'    |\  .        |
//                                   _..--..   .  /"---\      | ` |      . |
//           -=====================,' _     \=(*#(7.#####()   |  `/_..   , (
//                       _.-''``';'-''-) ,.  \ '  '+/// |   .'/   \  ``-.) \
//                     ,'  _.-  ((    `-'  `._\    `` \_/_.'  )    /`-._  ) |
//                   ,'\ ,'  _.'.`:-.    \.-'                 /   <_L   )"  |
//                 _/   `._,' ,')`;  `-'`'                    |     L  /    /
//                / `.   ,' ,|_/ / \                          (    <_-'     \
//                \ / `./  '  / /,' \                        /|`         `. |
//                )\   /`._   ,'`._.-\                       |)            \'
//               /  `.'    )-'.-,' )__)                      |\            `|
//              : /`. `.._(--.`':`':/ \                      ) \             \
//              |::::\     ,'/::;-))  /                      ( )`.            |
//              ||:::::  . .::':  :`-(                       |/    .          |
//              ||::::|  . :|  |==[]=:                       .        -       \
//              |||:::|  : ||  :  |  |                      /\           `     |
//  ___ ___     '|;:::|  | |'   \=[]=|                     /  \                \
// |   /_  ||``|||:::::  | ;    | |  |                     \_.'\_               `-.
// :   \_``[]--[]|::::'\_;'     )-'..`._                 .-'\``:: ` .              \
//  \___.>`''-.||:.__,'     SSt |_______`>              <_____:::.         . . \  _/
//                                                            `+a:f:......jrei'''


    //   _,.
//     ,` -.)
//    ( _/-\\-._
//   /,|`--._,-^|            ,
//   \_| |`-._/||          ,'|
//     |  `-, / |         /  /
//      `r-._||/   __   /  /
//  __,-<_     )`-/  `./  /
// '  \   `---'   \   /  /
//     |           |./  /
//     /           //  /
// \_/' \         |/  /
//  |    |   _,^-'/  /
//  |    , ``  (\/  /_
//   \,.->._    \X-=/^
//   (  /   `-._//^`
//    `Y-.____(__}
//     |     {__)


//   / \
//   | |
//   |.|
//   |.|
//   |:|      __
// ,_|:|_,   /  )
//   (Oo    / _I_
//    +\ \  || __|
//       \ \||___|
//         \ /.:.\-\
//          |.:. /-----\
//          |___|::oOo::|
//          /   |:<_T_>:|
//         |_____\ ::: /
//          | |  \ \:/
//          | |   | |
//          \ /   | \___
//          / |   \_____\
//          `-'