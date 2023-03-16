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
            //Комментарий к ошибке парсера

            //Заменить в классе GameProcess путь к папке с текстовыми файлами уровней
            //Текстовые файлы уровней находятся в папке \Dungeon Heroes\Game\Dungeon\LevelDungeon\
            //Полный путь до папки можно скопировать в свойствах текстовых уровней

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
