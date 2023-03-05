using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Player
    {
        private int playerX;
        private int playerY;

        public int PlayerX { get => playerX; set => playerX = value; }
        public int PlayerY { get => playerY; set => playerY = value; }

        private string playerMarker;
        private ConsoleColor PlayerColor;
        public Player(int placeAtX, int placeAtY)
        {
            playerX = placeAtX;
            PlayerY = placeAtY;

            playerMarker = "O";
            PlayerColor = ConsoleColor.Green;
        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(playerX, playerY);
            Write(playerMarker);
            ResetColor();
        }
    }
}
