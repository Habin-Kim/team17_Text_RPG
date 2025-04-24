namespace team17_textRPG
{

    
    class TextArt
    {

        public void TextRpgArt()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;   
            Console.WriteLine("""
            ▄▖▄▖▖▖▄▖ ▄▖▄▖▄▖ 
            ▐ ▙▖▚▘▐  ▙▘▙▌▌ 
            ▐ ▙▖▌▌▐  ▌▌▌ ▙
            """);
        }
        public void ShopOwnerArt()
        {
            Console.WriteLine(
            """
                            
                    _____                                                                
                   /_____\   어서오게나!                                              
                   (|0 0|)                                                    
                 __/{\U/}\_ ___/vvv                                                
                / \  {~}   / _|_P|                                                 
                | /\  ~   /_/   ||                                                 
                |_| (____)      ||                       
                \_]/______\  /\_||_/\ 
                   _\_||_/_ |] _||_ [|            
                  (_,_||_,_) \/ [] \/


            """);
        }
        public void DocterArt() // Rest화면에서 쓰기
        {
            Console.WriteLine(
            """
                        .----. 
                       ===(_)==    지금 당장 치료해야해요! 
                      // 6  6 \\    빨리 이리로 오세요!
                    //(    7   )\\
                    (((\ '--' /)))
                   )))))\_ ._/(((((
                  (((((__)  (__)))))
                    /"`/`\`V/`\`\
                   /   \  `Y _/_ \
                  / [DR]\_ |/ / /\
                  |     ( \/ / / /
                   \  \  \      /
                     \  `-/`  _.`
                      `=._`=./
            
            """);

        }
        public void GearArt()
        {
            if(Program.gearDb[0].Name == "목검")
            {
                Console.WriteLine("""
                -=={==========*
                """);
            }
            else if(Program.gearDb[1].Name == "철검")
            {
                Console.WriteLine("""     
                    /
                O===[====================-
                    \
                """);            
            }
            else if(Program.gearDb[2].Name == "강철검")
            {
                Console.WriteLine("""
                
                      /| ________________
                O|===|* >________________>
                      \|
                """);
                Console.WriteLine();
                Console.WriteLine("...무엇이든 베어낼 수 있을것만 같습니다...")


            }
            if(Program.gearDb[3].Name == "목방패")
            {
                Console.WriteLine("""
                  |\---/\---/|
                  |    ||    |
                  |____()____|
                  |__((<>))__|
                  \    \/    /
                   \   ||   /
                    \__||__/
                  
                """);
            }
            else if(Program.gearDb[4].Name == "철방패")
            {
                Console.WriteLine("""
                      _..._
                  .-'_.---._'-.
                  ||####|(__)||
                  ((####|(**)))
                   '\###|_''/'
                    \\()|##//
                     \\ |#//
                      .\_/.
                       L.J

                """);
            }
            else if(Program.gearDb[5].Name == "강철방패")
            {
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
                Console.WriteLine("...무엇이든 막아낼 수 있을 것만 같습니다...");
            }

        }

    }

}
