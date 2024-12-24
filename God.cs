using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// God : 인공지능(무언갈 구별하는기능), 아이템 사용할지 여부, God 체력
namespace buckShoot
{
    internal class God
    {
        Random Ai = new Random();
        int Life = 4;
        List<string> GodItem = new List<string>(8); // God의 아이템 칸은 8칸으로 고정임

        public void ReGameGod() //God의 값을 초기화해주는 함수 (목숨이랑 아이템)
        {
            Life = 4;// 플레이어 목숨
            GodItem.Clear();//God의 아이템
        }

        public int godlife //god의 채력을 수정해주기위한 프로퍼티
        {
            get { return Life; }
            set { Life = value; }
        }

        public void GodTurn(ShotGun shotgun, Player player)//클래스 받아온거임
        {
            int KnowAllGodBullet = shotgun.GodrRealBullet + shotgun.GodrFakeBullet;//실탄과 공포탄 갯수 더한값
            int realbulletCount = shotgun.GodrRealBullet;//realbulletCount에 GodrRealBullet을 대입
            int fakebulletCount = shotgun.GodrFakeBullet;//fakebulletCount에 GodrFakeBullet을 대입
            int GodChoose = Ai.Next(1, KnowAllGodBullet);//아이템 사용 추가시 KnowAllGodBullet에 +1 넣을것(이거는아이템 추가시 임)
            while(true)
            {
                if (GodChoose <= realbulletCount)//실탄이 많으면 플레이어 한테 쏠확률이 높아짐
                {
                    Console.WriteLine($"God {player.playerName}을 사격");
                    Thread.Sleep(1000);
                    player.PlayerLife = shotgun.Fire(player.PlayerLife);//샷건을 쏘고 플레이어한테 값가져와서 빼줌
                    Console.WriteLine(player.playerName + "의 체력: " + player.PlayerLife);
                    Thread.Sleep(1000);
                    break;
                }
                else if (GodChoose > KnowAllGodBullet)//여기에 나중에 아이템 사용값 추가해줘야함
                {
                    Console.WriteLine("God 자신사격");
                    Thread.Sleep(1000);
                    int cheakfakebullt = Life;//일단 현제 체력값을 담아줌
                    Life = shotgun.Fire(Life);//god의 체력을 샷건에 값 만큼빼줌
                    if (cheakfakebullt == Life)//공포탄 일경우 한번더(이전 체력값이 현제체력값과 같으면 공포탄인것 이니깐)
                    {
                        Console.WriteLine("God은 공포탄이라 피해를 안입었습니다. 남은 체력 : " + Life);
                        shotgun.ReRoad();// 공포탄쏘고 총알 전부 없으면 재장전실행
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("God은 실탄이라 피해를 입었습니다. 남은 체력 : " + Life);
                        break;
                    }
                }
            }
            //else if ()
            //{
            ////여기는 아이템 사용칸으로 만들거임
            //}

        }


    }
}
