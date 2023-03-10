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

        private int playerOldX;
        private int playerOldY;

        private string playerMarker;
        private ConsoleColor PlayerColor;

        public int PlayerX { get => playerX; set => playerX = value; }
        public int PlayerY { get => playerY; set => playerY = value; }
        public int PlayerOldX { get => playerOldX; set => playerOldX = value; }
        public int PlayerOldY { get => playerOldY; set => playerOldY = value; }
        public string PlayerMarker { get => playerMarker; set => playerMarker = value; }

        public Player(int placeAtX, int placeAtY)
        {
            playerX = placeAtX;
            PlayerY = placeAtY;

            playerOldX = placeAtX;
            playerOldY = placeAtY;

            playerMarker = "O";
            PlayerColor = ConsoleColor.Green;
        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(playerX, playerY);
            Write(playerMarker);
            ResetColor();

            RedrawPrevPos();
        }
        private void RedrawPrevPos()
        {
            SetCursorPosition(playerOldX, playerOldY);
            Write(" ");
        }
    }
}
