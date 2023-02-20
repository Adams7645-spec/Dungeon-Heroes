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
        int option = 1;
        public int Option { get => option; }

        //Вывод менюшки на экран 
        public void ShowMainMenuScreen()
        {
            Console.Clear();

            PrintBackground();
            SelectOption();
            ChooseOption();
        }
        
        //Доступные для выбора опции 
        private void StartGame()
        {
            GameProcess game = new GameProcess();

            game.Game();
        }
        private void Settings()
        {
            SettingsInterface settings = new SettingsInterface();

            settings.ShowSettings();
        }
        private void Exit()
        {
            Environment.Exit(0);
        }

        //Выбираем опцию
        private void SelectOption()
        {
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            bool isSelected = false;
            string prefix = "\u001a";

            while (!isSelected)
            {
                drawer.PositionText($"{(option == 1 ? prefix : "")} Начать игру! ", (Console.WindowWidth - 14) / 2, 11);
                drawer.PositionText($"{(option == 2 ? prefix : "")} Перейти в настройки ", (Console.WindowWidth - 21) / 2, 13);
                drawer.PositionText($"{(option == 3 ? prefix : "")} Выйти ", (Console.WindowWidth - 7) / 2, 15);

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.S:
                        option = (option == 3 ? 1 : option + 1);
                        break;
                    case ConsoleKey.W:
                        option = (option == 1 ? 3 : option - 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
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

            //Вывод информании об управлении 
            drawer.PositionText("W - вверх", 85, 0);
            drawer.PositionText("S - вниз", 85, 1);
            drawer.PositionText("Enter - выбрать", 85, 2);
        }

        //Вызываем выбранную опцию
        private void ChooseOption()
        {
            switch (Option)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    Settings();
                    break;
                case 3:
                    Exit();
                    break;
            }
        }
    }
}
