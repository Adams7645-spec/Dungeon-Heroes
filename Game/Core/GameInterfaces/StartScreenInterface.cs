using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    class StartScreenInterface
    {
        //Устанавливаем параметры игрового окна
        public void SetGameWindow()
        {
            Console.Title = "Dungeon Heroes";
            Console.SetWindowSize(100, 35);
        }

        //Вывод начального экрана
        public void ShowStartScreen()
        {
            PrintGameLogo();
            PrintBackgroundLeft();
            PrintBackgroundRight();
            PrintBackgroungCenter();
            PrintMainMenu();
        }
        
        //Метод для центрирования текста (ВЕРТИКАЛЬНАЯ плоскость не учитывается)
        private void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        //Вывод центрированного рисунка ASCII
        private void PrintASCIICentered(string[] asciiPicture)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                CenterText($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }

        //Вывод рисунка ASCII на определенные координаты в консоли
        private void PrintASCIIAtPosition(string[] asciiPicture, int marginWight, int marginHight)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                Console.SetCursorPosition(marginWight, marginHight + i);
                Console.WriteLine($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }
        private void PrintGameLogo()
        {
            string[] asciiGameLogo = new string[] { 
                $@"    ____                                        __  __                         ",
                $@"   / __ \__  ______  ____ ____  ____  ____     / / / ___  _________  ___  _____",
                $@"  / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \   / /_/ / _ \/ ___/ __ \/ _ \/ ___/",
                $@" / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / /  / __  /  __/ /  / /_/ /  __(__  ) ",
                $@"/_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/  /_/ /_/\___/_/   \____/\___/____/  ",
                $@"                  /____/                                                       "};
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrintASCIICentered(asciiGameLogo);

            Console.ResetColor();
        }
        private void PrintBackgroundLeft()
        {
            string[] asciiKnight = new string[] 
            {
            $@"    .",
            $@"   / \",
            $@"   | |",
            $@"   |.|",
            $@"   |:|      __",
            $@" ,_|:|_,   /  )",
            $@"   (Oo    / _I_",
            $@"    +\ \  || __|",
            $@"       \ \||___|",
            $@"         \ /.:.\-\",
            $@"          |.:. /-----\",
            $@"          |___|::oOo::|",
            $@"          /   |:<_T_>:|",
            $@"         |_____\ ::: /",
            $@"          | |  \ \:/",
            $@"          | |   | |",
            $@"          \ /   | \___",
            $@"          / |   \_____\",
            $@"          `-'"
            };
            Console.ForegroundColor = ConsoleColor.Green;

            PrintASCIIAtPosition(asciiKnight, 5, 7);

            Console.ResetColor();
        }
        private void PrintBackgroungCenter() 
        {
            string[] asciiAxe = new string[] 
            {
            $@"  ,:\      /:.  ",
            $@" //  \_()_/  \\ ",
            $@"||   |    |   ||",
            $@"||   |    |   ||",
            $@"||   |____|   ||",
            $@" \\  / || \  // ",
            $@"  `:/  ||  \;'  ",
            $@"       ||       ",
            $@"       ||       ",
            $@"       XX       ",
            $@"       XX       ",
            $@"       XX       ",
            $@"       XX       ",
            $@"       OO       ",
            $@"       `'       "};

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            PrintASCIIAtPosition(asciiAxe, 42, 10);

            Console.ResetColor();
        }
        private void PrintBackgroundRight()
        {
            string[] asciiDragon = new string[] { $@"             /           /   ",
                                                  $@"            /' .,,,,  ./     ",
                                                  $@"           /';'     ,/       ",
                                                  $@"          / /   ,,//,`'`     ",
                                                  $@"         ( ,, '_,  ,,,' ``   ",
                                                  $@"         |    /@  ,,, ;' `   ",
                                                  $@"        /    .   ,''/' `,``  ",
                                                  $@"       /   .     ./, `,, ` ; ",
                                                  $@"    ,./  .   ,-,',` ,,/''\,' ",
                                                  $@"   |   /; ./,,'`,,'' |   |   ",
                                                  $@"   |     /   ','    /    |   ",
                                                  $@"    \___/'   '     |     |   ",
                                                  $@"      `,,'  |      /     `\  ",
                                                  $@"           /      |        ~\",
                                                  $@"          '       (          "};
            Console.ForegroundColor = ConsoleColor.Red;

            PrintASCIIAtPosition(asciiDragon, Console.WindowWidth - 34, 11);

            Console.ResetColor();
        }
        private void PrintMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string pressAnyButton = "Нажмите любую кнопку, чтобы продолжить...";
            Console.SetCursorPosition((Console.WindowWidth - pressAnyButton.Length) / 2, 30);
            Console.WriteLine(pressAnyButton);
        }
    }
}