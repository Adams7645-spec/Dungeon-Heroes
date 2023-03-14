using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;
        private BlankDungeon currentDungeon;
        public List<PointOfInterest> pointList = new List<PointOfInterest>();
        Random random = new Random();
        public World(string[,] grid, BlankDungeon dungeon)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
            currentDungeon = dungeon;
        }
        public void DrawAtPosition(int marginLeft, int marginTop, ConsoleColor color)
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    Console.ForegroundColor = color;
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x + marginLeft, y + marginTop);
                    Console.Write(element);

                    Console.ResetColor();
                }
            }
        }
        public void GeneratePointOfInterest()
        {
            List<BlankRoom> currentRooms = new List<BlankRoom> { };
            currentRooms = currentDungeon.rooms;

            for (int i = 0; i < currentDungeon.rooms.Count; i++)
            {
                PointOfInterest point = new PointOfInterest(random.Next(currentRooms[i].PosX, currentRooms[i].LenghtX + currentRooms[i].PosX), 
                                                            random.Next(currentRooms[i].PosY, currentRooms[i].LenghtY + currentRooms[i].PosY));
                pointList.Add(point);
                point.Draw();
            }
        }
        public void PrintPointOfInterest()
        {
            for(int i = 0; i < pointList.Count; i++)
            {
                pointList[i].Draw();
            }
        }
        public bool IsPositionWalkable(int posX, int posY)
        {
            if (posX < 0 || posX >= Cols || posY < 0 || posY >= Rows)
            {
                return false;
            }
            return Grid[posY, posX] == " " || Grid[posY, posX] == "X" || Grid[posY, posX] == "!" || Grid[posY, posX] == "?";
        }
    }
}
