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
        static StartScreenInterface startScreenInterface = new StartScreenInterface();
        static MainMenuInterface menuInterface = new MainMenuInterface();
        static void Main(string[] args)
        {
            startScreenInterface.SetGameWindow();
            startScreenInterface.ShowStartScreen();
            menuInterface.ShowMainMenuScreen();

            Console.ReadKey();
        }
    }
}
