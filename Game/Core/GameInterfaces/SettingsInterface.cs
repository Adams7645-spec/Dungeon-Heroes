using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class SettingsInterface
    {
        MainMenuInterface menu = new MainMenuInterface();
        DrawingInterface drawer = new DrawingInterface();
        DifficultyLevel difficultyLevel = new DifficultyLevel();

        List<string> settingsMenu = new List<string> { "Легкая сложность", 
                                                       "Средняя сложность", 
                                                       "Тяжелая сложность" };

        //Вывод настроек сложности на экран
        public void ShowSettings()
        {
            Console.Clear();

            PrintBackground();
            drawer.SelectOptionVertically(settingsMenu, 43, 11);
            SetDifficulty(drawer.Option);

            Console.ReadKey();

            menu.ShowMainMenuScreen();
        }
        
        //Устанавливаем сложность
        private void SetDifficulty(int option)
        {
            switch (option)
            {
                case 0:
                    difficultyLevel.SetEasyDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
                case 1:
                    difficultyLevel.SetMidDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
                case 2:
                    difficultyLevel.SetHardDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
            }
        }

        //Рисуем задники
        private void PrintBackground()
        {
            string[] asciiFloppy = new string[] 
            {
                @".____________________________.",
                @"|;;|                     |;;||",
                @"|[]|---------------------|[]||",
                @"|;;|         FOR         |;;||",
                @"|;;|   ---------------   |;;||",
                @"|;;|        GAME         |;;||",
                @"|;;|   ---------------   |;;||",
                @"|;;|      DIFFICULTY     |;;||",
                @"|;;|   ---------------   |;;||",
                @"|;;|_____________________|;;||",
                @"|;;;;;;;;;;;;;;;;;;;;;;;;;;;||",
                @"|;;;;;;_______________ ;;;;;||",
                @"|;;;;;|  ___          |;;;;;||",
                @"|;;;;;| |;;;|         |;;;;;||",
                @"|;;;;;| |;;;|         |;;;;;||",
                @"|;;;;;| |;;;|         |;;;;;||",
                @"|;;;;;| |;;;|         |;;;;;||",
                @"|;;;;;| |___|         |;;;;;||",
                @"\_____|_______________|_____||",
                @" ~~~~~^^^^^^^^^^^^^^^^^~~~~~~"
            };

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            drawer.PrintASCIIAtPosition(asciiFloppy, 3, 6);

            Console.ResetColor();
        }
    }
}
