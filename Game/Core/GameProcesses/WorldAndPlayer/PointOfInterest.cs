using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Dungeon_Heroes
{
    internal class PointOfInterest
    {
        private ConsoleColor PointColor;
        private string pointMarker;
        public bool IsAvailable { get; set; }
        public int PointPosX { get; }
        public int PointPosY { get; }
        public PointOfInterest(int pointPosX, int pointPosY)
        {
            PointPosX = pointPosX;
            PointPosY = pointPosY;
            IsAvailable = true;

            pointMarker = "?";

            PointColor = ConsoleColor.Magenta;
        }
        public void Draw()
        {
            if (IsAvailable)
            {
                ForegroundColor = PointColor;
                SetCursorPosition(PointPosX, PointPosY);
                Write(pointMarker);
                ResetColor();
            }
        }
    }
}
