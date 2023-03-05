using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    public class PointOfInterest
    {
        int posX;
        int posY;
        private ConsoleColor PlayerColor;
        string pointMarker;
        public PointOfInterest(int PosX, int PosY)
        {
            posX = PosX;
            posY = PosY;

            pointMarker = "!";
            PlayerColor = ConsoleColor.DarkYellow;
        }
        public void DrawAtPosition(int pointX, int pointY)
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(pointX, pointY);
            Console.Write(pointMarker);
            Console.ResetColor();
        }
    }
}
