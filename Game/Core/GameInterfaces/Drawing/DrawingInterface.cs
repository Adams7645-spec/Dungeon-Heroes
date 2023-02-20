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
        //Вывод центрированного текста
        public void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        //Вывод текста на на определенные координаты в консоли
        public void PositionText(String text, int marginLeft, int marginTop)
        {
            Console.SetCursorPosition(marginLeft, marginTop + 1);
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
    }
}
