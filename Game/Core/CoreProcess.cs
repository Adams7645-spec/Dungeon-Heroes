using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class CoreProcess
    {
        static StartScreenInterface startScreen = new StartScreenInterface();
        static MainMenuInterface menu = new MainMenuInterface();
        static void Main(string[] args)
        {
            startScreen.SetGameWindow();
            startScreen.ShowStartScreen();
            menu.ShowMainMenuScreen();

            Console.ReadKey();
        }
    }
}
