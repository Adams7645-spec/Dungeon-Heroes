using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class LevelParser
    {
        public static string[,] ParseLevel(string levelPath)
        {
            string[] lines = File.ReadAllLines(levelPath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;

            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for(int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }

            return grid;
        }
    }
}
