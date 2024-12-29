using buckShoot;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
// Item : 수갑, 담배, 톱, 맥주, 돋보기, 전환기, 핸드폰, 주사기, 알약

        public class Item
        {
            bool Godplayer;//플레이어가 아이템을 쓴건지 God이 쓴건지 구별하기위한 bool
            int Choosecode; // 플레이어나 God 아이템리스트에 검증 다받고 있는거 받아온거임
            bool DoNotMove = false; //수갑을 썼는지 안썼는지 여부알기위해 
            

            public int choosecode//신이 실탄갯수를 알게됨 프로퍼티
            {
                get { return Choosecode; }
                set { Choosecode = value; }  
            }
            public bool GodPlayer//플레이어가 아이템을 쓴건지 God이 쓴건지 구별하기위한 bool
            {
                get { return Godplayer; }
                set { Godplayer = value; }
            }
            public bool UseHandCuff
            {
                get { return DoNotMove; }
                set { DoNotMove = value; }
            }

            public void UseItemSwich(Player player, God god , ShotGun shotgun)
            {
                switch (Choosecode)
                {
                    case 1:
                    {
                        HandCuff();
                    break;
                    }        
                    
                    case 2 :
                    {
                    if (Godplayer==true)
                    {
                        Cigarette(player.PlayerLife);
                    }
                    if (Godplayer == false) 
                    {
                        Cigarette(god.godlife);
                    }
                    break;
                    }

                    case 3:
                    {
                    Saw(shotgun.damage);
                    break;
                    }

                    case 4 : 
                    {
                    Beer(shotgun.count, shotgun.bulletcheak);
                    break;
                    }
                    
                    case 5:
                    {
                    Glasses(shotgun.bulletcheak);
                    break;
                    }

                    case 6:
                    {
                    BulletChange(shotgun.bulletcheak);
                    break;
                    }

                    //case 7:
                    //{
                    //Phone(shotgun.bulletcheak);
                    //break;
                    //}

                    case 8:
                    {
                    if (Godplayer == true)
                    {
                        Pill(player.PlayerLife);
                        Console.WriteLine("플레이어 체력 : " + player.PlayerLife);
                        Thread.Sleep(3000);

                    }
                    else if (Godplayer == false)
                    {
                        Pill(god.godlife);
                        Console.WriteLine("God 체력 : " + god.godlife);
                        Thread.Sleep(3000);
                    }

                    break;
                    }
                }

            }

           public bool HandCuff()
           {
               DoNotMove = true;
               return DoNotMove;
           }
            
           public int Cigarette(int life)
           {
                life= life + 1;
                return life;
           }
            
           public int Saw(int damage)
           {
            damage = 2;
            return damage;
           }
           
            public int Beer(int count, int bullet) 
            {
            if (bullet == 1)
            {
                Console.WriteLine("맥주를 마시고 실탄이 빠져나갔습니다.");
                Thread.Sleep(3000);
            }
            if (bullet == 2)
            {
                Console.WriteLine("맥주를 마시고 공포탄이 빠져나갔습니다.");
                Thread.Sleep(3000);
            }
                count = count + 1;

                return count;
            }
            
            public void Glasses(int bullet)
            {
            if (bullet == 1)
            {
                Console.WriteLine("실탄 입니다");
                Thread.Sleep(3000);
            }
            if (bullet == 2)
            {
                Console.WriteLine("공포탄입니다");
                Thread.Sleep(3000);
            }
            }
            
            public int BulletChange(int BulletChange)
            {
                 if (BulletChange == 1)
                 {
                     Console.WriteLine("전환중 입니다.");
                     BulletChange = 2;
                     Thread.Sleep(3000);
                 }
                 else if (BulletChange == 2)
                 {
                     Console.WriteLine("전환중 입니다.");
                     BulletChange = 1;
                     Thread.Sleep(3000);
                 }
                 return BulletChange;
            }


            //public int Phone(int will)
            //{
            //Random random = new Random();
            //will = 


            //return 
            //}

            public int Pill(int life)
            {
            Random random = new Random();
            int pill = random.Next(1, 3);
            if (pill == 1) //1이나오면 체력 2증가 
            {
                life = life + 2;
                Console.WriteLine("회복약이네요 체력 2 회복합니다");
                Thread.Sleep(1000);
            }
            else if (pill == 2)// 2가나오면 체력 -1
            {
                life = life - 1;
                Console.WriteLine("독약이네요 체력 -1 됩니다");
                Thread.Sleep(1000);
            }

            return life;
            }

        }














