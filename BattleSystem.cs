using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//여기에는 게임 할지 말지랑 게임을 반복할 구간임
namespace buckShoot
{
    enum GamePlay // 시작과 종료를 받을 enum문
    {
        게임시작 = 1, 게임종료 = 2
    }
    internal class BattleSystem
    {
        ShotGun shotgun = new ShotGun();//클레스생성
        Item item = new Item();//클레스생성
        God god = new God();//클레스생성
        Player player = new Player();//클레스생성
        Animation animation = new Animation();//클레스생성

        public void playgame()
        {
            GamePlay userChoose;

            while (player != null) 
            {
                Console.WriteLine("게임을 하시겠습니까? (1 또는 게임시작)는 게임시작    (2 또는 게임종료)는 게임종료");
                Enum.TryParse(Console.ReadLine(), out userChoose);
                switch (userChoose)
                {
                    case GamePlay.게임시작:
                        Console.WriteLine("게임을 시작합니다.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.Write("이름을 입력해주세요: ");
                        player.playerName = Console.ReadLine();//이름을 입력받음

                        player.ReGamePlayer();//게임 재시작이나 그냥플레이할때 값을 초기화
                        god.ReGameGod();//게임 재시작이나 그냥플레이할때 값을 초기화
                        shotgun.ReSetBullet();//게임 재시작이나 그냥플레이할때 값을 초기화

                        while (player.PlayerLife > 0 && god.godlife > 0)// 이게 1번돌면 서로 1턴씩 돌아간거임(god이나 플레이어 체력없으면 빠져나감)
                        {
                            shotgun.ReRoad();//총알이 없으면 장전해줌
                            player.PlayerTurn(shotgun, god);//플레이어 행동 클래스값도 연결해줌
                            shotgun.ReRoad();//총알이 없으면 장전해줌
                            god.GodTurn(shotgun, player);// God 행동 클래스값도 연결해줌
                            Thread.Sleep(3000);// 전체 상황을 3초간 보게 해줌
                            Console.Clear();
                        }
                        if (player.PlayerLife <= 0)//플레이어 체력이 없으면 
                        {
                            Console.WriteLine(player.playerName + "은 패배하였습니다");
                        }
                        else if (god.godlife <= 0)//God 체력이없으면
                        {
                            Console.WriteLine(player.playerName + "은 승리하였습니다");
                        }

                        break;

                    case GamePlay.게임종료:
                        Console.WriteLine("게임종료");
                        Environment.Exit(0); // 프로그램종료 코드
                        break;

                    default: //다른 값을 입력받을경우  
                        Console.WriteLine("다시입력해주세요");
                        Thread.Sleep(1000);
                        continue;
                }
                continue;
            }


        }



    }
}
