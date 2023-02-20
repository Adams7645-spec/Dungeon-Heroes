using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class DrawingInterface
    {
        //Поля
        private int option = 0;
        public int Option { get => option; }

        //Вывод центрированного текста
        public void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        //Вывод текста на на определенные координаты в консоли
        public void PositionText(String text, int marginLeft, int marginTop)
        {
            Console.SetCursorPosition(marginLeft, marginTop);
            Console.WriteLine($@"{text}");
            Thread.Sleep(10);
        }

        //Вывод центрированного рисунка ASCII
        public void PrintASCIICentered(string[] asciiPicture)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                CenterText($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }

        //Вывод рисунка ASCII на определенные координаты в консоли
        public void PrintASCIIAtPosition(string[] asciiPicture, int marginLeft, int marginTop)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                Console.SetCursorPosition(marginLeft, marginTop + i);
                Console.WriteLine($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }

        //Выводим менюшку с выбором действия ВЕРТИКАЛЬНО
        public void SelectOptionVertically(List<string> Options, int MarginLeft, int MarginTop)
        {
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            bool isSelected = false;
            string prefix;

            for(int i = 0; i < Options.Count; i++)
            {
                PositionText($"{Options[i]}", MarginLeft, MarginTop + i);
            }

            while (!isSelected)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.S:
                        option = (option == 2 ? 0 : option + 1);
                        break;
                    case ConsoleKey.W:
                        option = (option == 0 ? 2 : option - 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

                for (int i = 0; i < Options.Count; i++)
                {
                    if (option == i)
                    {
                        prefix = "►";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = " ";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    PositionText($"{Options[i]}", MarginLeft, MarginTop + i);
                    PositionText($"{prefix}", MarginLeft - 2, MarginTop + i);
                }
                Console.ResetColor();
            }
        }
    }
}
