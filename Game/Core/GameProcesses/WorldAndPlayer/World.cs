using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class World
    {
        
        private string[,] Grid;
        private int Rows;
        private int Cols;
        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }
        public void DrawAtPosition(int marginLeft, int marginTop, ConsoleColor color)
        {
            for (int y = 0; y < Rows; y++)
            {
                for(int x = 0; x < Cols; x++)
                {
                    Console.ForegroundColor = color;
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x + marginLeft, y + marginTop);
                    Console.Write(element);

                    Console.ResetColor();
                }
            }
        }
        public bool IsPositionWalkable(int posX, int posY)
        {
            if (posX < 0 || posX >= Cols || posY < 0|| posY >= Rows)
            {
                return false;
            }
            return Grid[posY, posX] == " " || Grid[posY, posX] == "X" || Grid[posY, posX] == "!" || Grid[posY, posX] == "?";
        }
    }
}
