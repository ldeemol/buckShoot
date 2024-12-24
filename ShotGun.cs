using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// ShotGun: 실탄, 공포탄, 총데미지
namespace buckShoot
{
    internal class ShotGun
    {

        Random reroad = new Random();// 총알 장전할때 쓸 랜덤문
        int Damage= 1; // 샷건의 기본데미지임 
        int Count = 0; // 총알의 순서임 한발쏘면 다음발을 이걸로 넘김
        List<int> Bullet = new List<int>();// 실탄 공포탄을 여기에다가 담아줄꺼임
        int cheakrealSlug;//실탄값을 넘겨주기위한 int
        int cheakfakeSlug;//공포탄값을 넘겨주기위한 int

        public void ReSetBullet()//만약 게임을 재시작을 할때 총알에 값이 남으면안되서 쓰는 함수 List<int> Bullet 값을 싹다 없애줌
        {
            Bullet.Clear();//리스트값 없앤거 
        }

        public int GodrRealBullet//신이 실탄갯수를 알게됨 프로퍼티
        {
            get { return cheakrealSlug; }
            set { cheakrealSlug = value; }
        }

        public int GodrFakeBullet//신이 공포탄 갯수를 알게됨 프로퍼티
        {
            get { return cheakfakeSlug; }
            set { cheakfakeSlug = value; }
        }

        public int count// 맥주때문에 값을 수정해야할수있어서 프로퍼티
        {
            get { return Count; }
            set { Count = value; }
        }

        public int bulletcheak// 돋보기 와 전환기를 위한 프로퍼티
        {
            get { return Bullet[Count]; }
            set { Bullet[Count] = value; }
        }



        public int Fire(int life)//목숨값 받아와서 리턴으로 보내준다
        {
            if (Bullet[Count] == 1)//실탄일경우 
            {
                life = life - Damage;//받은 목숨값을 데미지에 빼서 값을보냄
                Console.WriteLine("실탄입니다.");
                Thread.Sleep(3000);
            }

            else if (Bullet[Count] == 2)//공포탄일경우 (굳이 목숨값을 뺄필요가 없으니깐 출력만함)
            {
                Console.WriteLine("공포탄입니다");
                Thread.Sleep(3000);
            }
            Count++; // 다음탄약으로 바꿔줌 
            return life;// 값 보내줌 목숨값
        }

        public void ReRoad()// 총알을 장전하기위해 만든 함수 
        {
            if (Bullet.Count == Count)//list안에 들어있는 값의 갯수가 Count랑같으면 총알을 다 쓴거니깐 
            {
                Console.WriteLine("장전!");
                Count = 0; //list에 첫번째칸부터 보기위해서  
                Bullet.Clear();//list 값을 싹다 지워줌
                int realSlug = 0;//실탄의 값을 받아줄것 
                int fakeSlug = 0;//공포탄의 값을 받아줄것
                realSlug = reroad.Next(1, 5);//실탄 갯수 정해줌
                fakeSlug = reroad.Next(1, 5);//공포탄 갯수 정해줌 
                cheakrealSlug = realSlug;//총알체크용 God도 이걸로 값을 받고 실행함
                cheakfakeSlug = fakeSlug;//총알체크용 God도 이걸로 값을 받고 실행함
                int SumSlug = realSlug + fakeSlug; //실탄 공포탄의 더한값이 총알의 총합이므로 for문에 쓸 총합(바로 밑에 있음)
                for (int i = 0; i < SumSlug; i++)//총알을 안에다가 반복해서 넣는것
                {
                    int Reroad = reroad.Next(1, 3);//1 아니면 2 숫자를 넣어주고 1이면 실탄 2이면 공포탄
                    if (realSlug > 0 && Reroad == 1)//1일면 실탄임 //실탄이 원레 갯수보다 더들어가지않게 하는것
                    {
                        Bullet.Add(1);
                        realSlug--;
                    }
                    else if (fakeSlug > 0 && Reroad == 2)// 2이면 공포탄 //공포탄이 원레 갯수보다 더들어가지않게 하는것
                    {
                        Bullet.Add(2);
                        fakeSlug--;
                    }
                    else if(fakeSlug > 0 && Reroad == 1)//위에처리 했는데 실탄 나왔는데 실탄값이 없으면 공포탄으로 바꿔서 넣어줌
                    {
                      
                        Bullet.Add(2);
                        fakeSlug--;
                    }
                    else if (realSlug > 0 && Reroad == 2)//위에처리 했는데 공포탄이 나왔는데 공포탄값이 없으면 실탄으로 바꿔서 넣어줌
                    {
                 
                        Bullet.Add(1);
                        realSlug--;
                    }

                }
                Console.WriteLine($"실탄 {cheakrealSlug}개      공포탄{cheakfakeSlug}개 있습니다");// 실탄이랑 공포탄 갯수를 보여줌
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
    }
}
