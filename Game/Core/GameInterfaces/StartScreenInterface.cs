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
        DrawingInterface drawer = new DrawingInterface();

        //Устанавливаем параметры игрового окна
        public void SetGameWindow()
        {
            Console.Title = "Dungeon Heroes";
            Console.SetWindowSize(100, 35);
            Console.CursorVisible = false;
        }

        //Вывод начального экрана
        public void ShowStartScreen()
        {
            PrintGameLogo();
            PrintBackgroundLeft();
            PrintBackgroundRight();
            PrintBackgroungCenter();
            drawer.PrintPressAnyKeyLikeText("Нажмите любую кнопку, чтобы продолжить...");
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

            drawer.PrintASCIICentered(asciiGameLogo);

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

            drawer.PrintASCIIAtPosition(asciiKnight, 5, 7);

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

            drawer.PrintASCIIAtPosition(asciiAxe, 42, 10);

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

            drawer.PrintASCIIAtPosition(asciiDragon, Console.WindowWidth - 34, 11);

            Console.ResetColor();
        }
    }
}