using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class MainMenuInterface
    {
        DrawingInterface drawer = new DrawingInterface();

        //В списке хранятся названия опций, которые выводятся на экран
        List<string> menuOptions = new List<string> { "Начать игру!", "Перейти в настройки", "Выйти" };

        //Вывод менюшки на экран 
        public void ShowMainMenuScreen()
        {
            Console.Clear();

            PrintBackground();
            PrintControlInfo();
            drawer.SelectOptionVertically(menuOptions, 43, 13);
            ChooseOption(drawer.Option);
        }
        
        //Начать игру
        private void StartGame()
        {
            GameProcess game = new GameProcess();

            game.Game();
        }

        //Перейти в настройки игры 
        private void Settings()
        {
            SettingsInterface settings = new SettingsInterface();

            settings.ShowSettings();
        }

        //Выйти из игры
        private void Exit()
        {
            Environment.Exit(0);
        }

        //Рисуем задники
        private void PrintBackground()
        {
            string[] asciiSword = new string[]
            {
                @"        )         ",
                @"          (       ",
                @"        '    }    ",
                @"      (    '      ",
                @"     '      (     ",
                @"      )  |    )   ",
                @"    '   /|\    `  ",
                @"   )   / | \  ` ) ",
                @"  {    | | |  {   ",
                @" }     | | |  .   ",
                @"  '    | | |    ) ",
                @" (    /| | |\    .",
                @"  .  / | | | \  ( ",
                @"}    \ \ | / /  . ",
                @" (    \ `-' /    }",
                @" '    / ,-. \    '",
                @"  }  / / | \ \  } ",
                @" '   \ | | | /   }",
                @"  (   \| | |/  (  ",
                @"    )  | | |  )   ",
                @"    .  | | |  '   ",
                @"       J | L      ",
                @" /|    J_|_L    |\",
                @" \ \___/ o \___/ /",
                @"  \_____ _ _____/ ",
                @"        |-|       ",
                @"        |-|       ",
                @"        |-|       ",
                @"       ,'-'.      ",
                @"       '---'      "
            };

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            drawer.PrintASCIIAtPosition(asciiSword, 5, 2);

            Console.ResetColor();
        }

        //Вывод информании об управлении 
        private void PrintControlInfo()
        {
            drawer.PositionText("W - вверх", 85, 1);
            drawer.PositionText("S - вниз", 85, 2);
            drawer.PositionText("Enter - выбрать", 85, 3);
        }

        //Вызываем выбранную опцию
        private void ChooseOption(int Option)
        {
            switch (Option)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    Settings();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }
    }
}
