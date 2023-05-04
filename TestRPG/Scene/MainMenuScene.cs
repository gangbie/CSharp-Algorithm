using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {

        }
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임시작");
            sb.AppendLine("2. 게임종료").AppendLine();
            sb.Append("메뉴를 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if(!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력했습니다.");
                Thread.Sleep(500);
                return;
            }

            switch(command)
            {
                case 1:
                    // 게임 시작
                    game.GameStart();
                    Console.WriteLine("게임시작");
                    Thread.Sleep(500);
                    break;
                case 2:
                    // 게임 종료
                    game.GameOver();
                    Console.WriteLine("게임종료");
                    Thread.Sleep(500);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다");
                    Thread.Sleep(500);
                    break;

            }
        }
    }
}
