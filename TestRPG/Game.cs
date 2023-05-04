using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        private Scene           curScene;
        private MainMenuScene   mainMenuScene;
        private MapScene        mapScene;
        private InventoryScene  inventoryScene;
        private BattleScene     battleScene;

        public void Run()   // 게임 동작시키기
        {
            // 초기화
            Init();

            // 게임 루프
            while (isRunning)
            {
                // 렌더링(표현)
                Render();
                // 입력

                // 갱신(업데이트) + 입력
                Update();
            }

            // 마무리
            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();

            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            curScene = mainMenuScene;
        }

        public void GameStart()
        {
            curScene = mapScene;
            mapScene.GenerateMap();
        }

        public void GameOver(string text = "")
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            Console.WriteLine(sb.ToString());

            isRunning = false;
        }
        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }
        private void Update()
        {
            curScene.Update();
        }
        private void Release()
        {
        }
        public void MainMenu()
        {
            curScene = mainMenuScene;
        }

        public void Map()
        {
            curScene = mapScene;
        }

        public void Battle(Monster monster)
        {
            curScene = battleScene;
            battleScene.StartBattle(monster);
        }

        public void Inventory()
        {
            curScene = inventoryScene;
        }
    }
}
