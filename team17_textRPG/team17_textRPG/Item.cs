
//회복물약UI hpPotion
//=====완성=====

//화면
//인벤토리UI


//회복물약 기능
//사냥을 통해 얻을 수 있다.
//던전 입장전 포션을 사용할 수 있다. - 포션 사용시 메세지 출력 "회복을 완료했습니다", "포션이 부족합니다."
//포션의 회복량 30
//최대 체력보다 높게 회복 불가
//보유포션 표시, 사용시 포션 개수 차감
namespace team17_textRPG
{
    
    class Item
    {   
        static int hpPotion = 3;
    

        public void DisplayHealUI()
        {
            Console.WriteLine("회복");
            Console.WriteLine($"포션을 사용하면 체력을 30 회복할 수 있습니다. (남은 포션 : {hpPotion})");
            Console.WriteLine();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }

        public void DisplayInventory()
        {
            
        }
    }
}

