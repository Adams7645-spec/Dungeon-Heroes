using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class UserOptionsInteraction
    {
        static DrawingInterface drawer = new DrawingInterface();
        List<string> options;
        int optionCounter;
        public int OptionCounter { get => optionCounter; }

        public UserOptionsInteraction(List<string> options)
        {
            this.options = options;
            optionCounter = 0;
        }
        public void SelectOption()
        {
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            bool isSelected = false;
            string prefix;

            while (!isSelected)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    if (optionCounter == i)
                    {
                        prefix = ">>";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = "  ";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    drawer.PositionText($"{options[i]}", 45, 13 + i);
                    drawer.PositionText($"{prefix}", 42, 13 + i);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.S:
                        optionCounter = (optionCounter == (options.Count - 1) ? 0 : optionCounter + 1);
                        break;
                    case ConsoleKey.W:
                        optionCounter = (optionCounter == 0 ? (options.Count - 1) : optionCounter - 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
        }
    }
}
