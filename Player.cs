using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// Player : 플레이어 체력 , 플레이어의 이름, 플레이어 선택지(스위치문)
namespace buckShoot
{
    enum choose//누구한테 쏠 것인지 
    {
        나 = 1, 상대 = 2, 아이템 = 3
    }
    enum item //아이템 모든종류
    {
        수갑 = 1, 담배 = 2, 톱 = 3, 맥주 = 4, 돋보기 = 5, 전환기 = 6, 핸드폰 = 7, 알약= 8
    }

    public class Player
    {
        Random ItemGet = new Random();
        int Life=4;// 플레이어 목숨
        List<int> PlayerItem = new List<int>(8); // 플레이어의 아이템 칸은 8칸으로 고정임
        choose userChoose; // 유저가 처음에 뭐할지 정하는거 
        item useritem;// 유저가 아이템쓸때 뭘쓸지 고르는거
        bool useItem =false;


        string PlayerName;//플레이어 이름 마지막에 플레이어 이름이 승리하였습니다 나 플레이어가 졌다는것을 넣을꺼임

        public bool UseItem
        {
            get{ return useItem; }
            set { useItem = value; }
        }

        public string playerName //플레이어 이름 안전하게 바꿔주는 프로퍼티
        {
            get { return PlayerName; }
            set { PlayerName = value; }
        }
        public int PlayerLife// 컴퓨터가 이 프로퍼티로 life를 수정함
        {
            get { return Life; }
            set { Life = value; }
        }
        
        public void ReGamePlayer()// 플레이어 값을 초기화 해주기 위한 함수(목숨이랑 아이템)
        {
            Life = 4;// 플레이어 목숨
            PlayerItem.Clear();//아이템
        }

        public void PlayerGetItem()
        {
            int count=4; //아이템 얻게 할 갯수 
            int printitem;
            PlayerItem.Add(3);//이거는 톱 버그 확인용
            PlayerItem.Add(3);//이거는 톱 버그 확인용
            while (PlayerItem.Count < 8 && count > 0)
            {
                printitem = ItemGet.Next(1, 9);
                PlayerItem.Add(printitem);
                count--;
                useritem = (item)printitem;
                Console.WriteLine(useritem + " 획득하였습니다.");
                Thread.Sleep(1000);
            }
            if (PlayerItem.Count >= 8)
            {
                Console.WriteLine(playerName + " 아이템이 8개이상이라 더이상 못얻습니다.");
            }
            
        }


        public void PlayerTurn(ShotGun shotgun, God god, Item item ,Player player)// 플레이어 턴
        {
            if (item.UseHandCuff == false)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("1.나 2.상대 3.아이템");
                    Enum.TryParse(Console.ReadLine(), out userChoose);//유저의 입력값 받게 해주는것

                    switch (userChoose)//플레이어의 선택지 (스위치문)
                    {
                        case choose.나:
                            Console.WriteLine(PlayerName + " 자신사격");
                            Thread.Sleep(1000);
                            int cheakfakebullt = Life;
                            Life = shotgun.Fire(Life);//나한테 쏠경우 처리하는것
                            if (cheakfakebullt == Life)//공포탄 일경우 한번더
                            {
                                Console.WriteLine(playerName + "은 공포탄이라 피해를 안입었습니다. 남은 체력 : " + Life);
                                shotgun.ReRoad(player, god);// 공포탄 쏠경우 총알이 없으면 여기서 처리함
                                continue;//한번더 해주게 만들어줌 While문
                            }
                            else
                            {
                                Console.WriteLine(playerName + "은 실탄이라 피해를 입었습니다. 남은 체력 : " + Life);
                            }
                            break;

                        case choose.상대://상대 한테 쏠경우 스위치문
                            Console.WriteLine(PlayerName + " God사격");
                            Thread.Sleep(1000);
                            god.godlife = shotgun.Fire(god.godlife);//여기서 God 피를 깎을꺼임
                            Console.WriteLine("God 체력: " + god.godlife);
                            Thread.Sleep(1000);
                            break;

                        case choose.아이템:// 아이템 사용칸
                            if (PlayerItem.Count > 0)
                            {
                                Console.WriteLine("수갑 = 1, 담배 = 2, 톱 = 3, 맥주 = 4, 돋보기 = 5, 전환기 = 6, 핸드폰 = 7, 알약= 8");
                                Console.Write("현제 가지고잇는템: ");
                                foreach (var b in PlayerItem)// 현제 가지고있는 아이템 알려줌
                                {
                                    useritem = (item)b;
                                    Console.Write("  " + useritem);
                                }
                                Console.WriteLine();
                                Console.WriteLine(" 사용하실 아이템을 선택해주세요.");
                                Enum.TryParse(Console.ReadLine(), out useritem);
                                int cheack;
                                cheack = PlayerItem.Find(n => n == (int)useritem);
                                if (cheack > 0)//0보다 크면 값이 있는거임
                                {
                                    useItem = true;
                                    Console.WriteLine("아이템 사용중...");
                                    Thread.Sleep(1000);
                                    item.choosecode = cheack;
                                    item.GodPlayer = true;
                                    item.UseItemSwich(player, god, shotgun);
                                    Console.WriteLine("아이템 사용완료");
                                    PlayerItem.Remove(cheack);//사용했으면지워야지
                                    Thread.Sleep(1000);
                                    continue;
                                }
                                else if (cheack == 0)//0이나오면 해당 아이템은 없는거임
                                {
                                    Console.WriteLine("해당 아이템은 가지고 있지 않습니다.");
                                    Thread.Sleep(1000);
                                    continue;
                                }

                            }
                            else
                            {
                                Console.WriteLine("사용할수 있는 아이템이 없습니다.");
                                continue;
                            }

                            //여기에 스위치문 추가 list써서 현제 아이템 갯수가없으면 거르는것도 할꺼

                            continue;

                        default:// 잘못 입력받을경우
                            {
                                Console.WriteLine("다시 입력해주세요");
                                Thread.Sleep(1000);
                                continue;
                            }
                    }
                    break;
                }
                item.UseHandCuff = false;
            }
        }
    }
}
