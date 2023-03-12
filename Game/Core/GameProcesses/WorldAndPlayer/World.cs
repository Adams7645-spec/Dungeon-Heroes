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
        List<PointOfInterest> pointList = new List<PointOfInterest>();
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
        public void PlacePointOfInterest()
        {
            List<List<List<int>>> currentRooms = new List<List<List<int>>> { };
            currentRooms = currentDungeon.GetRoomGrids();
            for (int i = 0; i < 50; i++)
            { //currentDungeon.GetAmountOfPoints()
                List<List<int>> randRoom = new List<List<int>> { };
                randRoom = currentRooms[random.Next(currentRooms.Count)];
                int maxLenghtX = randRoom[0].Count;
                int maxLenghtY = randRoom.Count;

                PointOfInterest point = new PointOfInterest(random.Next(randRoom[0][0], maxLenghtX) + currentDungeon.GetRoomPosX(), 
                                                            random.Next(randRoom[0][0], maxLenghtY) + currentDungeon.GetRoomPosY());
                pointList.Add(point);
                point.Draw();
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
