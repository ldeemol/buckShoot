using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// Item : 수갑, 담배, 톱, 맥주, 돋보기, 전환기, 핸드폰, 주사기, 알약
namespace buckShoot
{
    internal class Item
    {
        int ItemCount = 1;//아이템을 얻으면 기존값아이템 갯수에 더해주기위해 만든것   
    }
        public class Handcuff
        {
            int DoNotMove = 2; //수갑에 묶일경우 배틀시스템에서 처리
            public int donotmove//값을 받을 프로퍼티
            {
                get {  return DoNotMove; }
                set {  DoNotMove = value; }
            }
        }

        public class Cigarette
        {
            int AddLife = 1;//체력추가 1
            public int addlife//값을 받을 프로퍼티
            {
                get { return AddLife; }
                set { AddLife = value; }
            }
        }

        public class Saw
        {
            public int SawDamage = 1;//톱을 쓰면 추가로 damage에 추가 1 받음
            public int sawdamage//값을 받을 프로퍼티
            {
                get { return SawDamage;}
                set { SawDamage = value; }
            }
        }

        public class Beer
        {
            int AddCount = 1; // 샷건에 카운터를 증가시켜서 다음탄환으로 바꿔줌
            public int addCount//값을 받을 프로퍼티
            {
                get { return AddCount; }
                set { AddCount = value; }
            }
        }

        public void Glasses(ShotGun shotgun) // 실탄이랑 공포탄 구별해주는것 컴퓨터일경우 이걸쓰면 무조건 실탄일경우 플레이어 쏘고 공포탄이면 자기자신을 쏜다
        {
            if (shotgun.bulletcheak == 1)
            {
                Console.WriteLine("실탄입니다");
                Thread.Sleep(3000);
            }
            else if (shotgun.bulletcheak == 2)
            {
                Console.WriteLine("공포탄입니다");
                Thread.Sleep(3000);
            }
        }

        public int BulletChange(ShotGun shotgun) //현제 탄환을 바꿔줌 공포탄 > 실탄 , 실탄 > 공포탄 
        {
            if (shotgun.bulletcheak == 1)
            {
                shotgun.bulletcheak = 2;
                Thread.Sleep(3000);
            }
            else if (shotgun.bulletcheak == 2)
            {
                shotgun.bulletcheak = 1;
                Thread.Sleep(3000);
            }
            return shotgun.bulletcheak;
        }

        class Phone
        {

        }

        class Drug
        {

        }

        class Pill//약을 먹을때 50% 확률로 체력이 2늘어나거나 1줄어들거나
        {
            static Random CoinToss = new Random();
            public void UsePill(int Life)
            {
                int pill = CoinToss.Next(1, 3);
                if (pill == 1) //1이나오면 체력 2증가 
                {
                    Life = Life + 2;
                }
                else if (pill == 2)// 2가나오면 체력 -1
                {
                    Life = Life - 1;
                }
            }

        }
    
}
