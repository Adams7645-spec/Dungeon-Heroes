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

        int option = 1;
        public void ShowSettings()
        {
            Console.Clear();

            SelectOption();
            SetDifficulty(option);

            Console.ReadKey();

            menu.ShowMainMenuScreen();
        }
        private void SelectOption()
        {
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            bool isSelected = false;
            string prefix = "\u001a";

            while (!isSelected)
            {
                drawer.PositionText($"{(option == 1 ? prefix : "")} Легкая сложность ", (Console.WindowWidth - 18) / 2, 11);
                drawer.PositionText($"{(option == 2 ? prefix : "")} Средняя сложность ", (Console.WindowWidth - 19) / 2, 13);
                drawer.PositionText($"{(option == 3 ? prefix : "")} Тяжелая сложность ", (Console.WindowWidth - 19) / 2, 15);

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
        private void SetDifficulty(int option)
        {
            switch (option)
            {
                case 1:
                    difficultyLevel.SetEasyDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
                case 2:
                    difficultyLevel.SetMidDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
                case 3:
                    difficultyLevel.SetHardDiff();
                    Console.WriteLine($"Выбрана {difficultyLevel.DifficultyName} сложность!");
                    break;
            }
        }
    }
}
