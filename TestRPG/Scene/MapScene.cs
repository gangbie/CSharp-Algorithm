using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {

        }
        public override void Render()
        {
            PrintMap();
            PrintMenu();
            PrintInfo();

            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            // 플레이어 이동
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    // 플레이어 위로 이동
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
                case ConsoleKey.I:
                    // 인벤토리 창
                    game.Inventory();
                    return;
            }

            // 아이템 습득
            Item item = Data.ItemInPos(Data.player.pos);
            if (item != null)
            {
                Data.player.GetItem(item);
                Data.items.Remove(item);
            }

            // 몬스터 전투
            Monster monster = Data.MonsterInPos(Data.player.pos);
            if (monster != null)
            {
                game.Battle(monster);
                return;
            }

            // 몬스터 이동
            foreach (Monster m in Data.monsters)
            {
                m.MoveAction();
                if(m.pos.x == Data.player.pos.x && m.pos.y == Data.player.pos.y)
                {
                    game.Battle(m);
                    return;
                }
            }
        }
        public void GenerateMap()
        {
            Data.LoadLevel1();
        }

        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('＠');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            foreach (Monster monster in Data.monsters)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(monster.pos.x * 2, monster.pos.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            Console.Write(Data.player.icon);
        }
        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data.map.GetLength(1) + 20, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data.map.GetLength(1) + 20, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data.map.GetLength(1) + 20, 4);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
            Console.Write($"HP : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data.player.CurExp,3}/{Data.player.MaxExp,3}");
        }
    }
}
