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
        UserOptionsInteraction interaction = new UserOptionsInteraction(mainMenuOptions);

        static List<string> mainMenuOptions = new List<string> { "Начать игру", "Настройки", "Выход" };

        //Вывод менюшки на экран 
        public void ShowMainMenuScreen()
        {
            Console.Clear();

            PrintBackground();
            interaction.SelectOption(45, 13);
            ChooseOption(interaction.OptionCounter);
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
