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
        UserOptionsInteraction interaction = new UserOptionsInteraction(options);
        DifficultyLevel difficultyLevel = new DifficultyLevel();

        static List<string> options = new List<string> { "Легкая сложность", "Средняя сложность", "Тяжелая сложность" };
        public void ShowSettings()
        {
            Console.Clear();

            interaction.SelectOption(45, 13);
            SetDifficulty(interaction.OptionCounter);

            Console.ReadKey();

            menu.ShowMainMenuScreen();
        }
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
    }
}
