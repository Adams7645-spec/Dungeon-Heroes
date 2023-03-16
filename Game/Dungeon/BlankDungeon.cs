using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BlankDungeon
    {
        public int PlayerPosX { get; }
        public int PlayerPosY { get; }
        public int ExitPosX { get; }
        public int ExitPosY { get; }
        public int BossPosX { get; }
        public int BossPosY { get; }
        public bool BossIsActive { get; }
        public string LevelName { get; set; }
        protected int PointOfInterestCount { get; set; }
        public readonly List<BlankRoom> rooms = new List<BlankRoom> { };
        public BlankDungeon(int playerXpos, int playerYpos, int exitPosX, int exitPosY, int bossPosX, int bossPosY)
        {
            LevelName = "Path";
            PlayerPosX = playerXpos;
            PlayerPosY = playerYpos;
            ExitPosX = exitPosX;
            ExitPosY = exitPosY;
            BossPosX = bossPosX;
            BossPosY = bossPosY;
            BossIsActive = true;
            PointOfInterestCount = 0;
        }
        protected void SetRoomGrid(int startX, int lenghtX, int startY, int lenghtY)
        {
            List<List<int>> roomGrid = new List<List<int>>();
            List<int> row = new List<int>();

            for (int Y = startY; Y < startY + lenghtY; Y++)
            {
                row = new List<int>();
                for (int X = startX; X < startX + lenghtX; X++)
                {
                    row.Add(0);
                }
                roomGrid.Add(row);
            }
            BlankRoom newRoom = new BlankRoom(startX, startY, lenghtX, lenghtY);
            newRoom.AddGrid(roomGrid);
            rooms.Add(newRoom);
        }

        protected void SetRoom(List<int> room)
        {
            SetRoomGrid(room[0], room[1], room[2], room[3]);
        }
        public int GetAmountOfPoints()
        {
            return PointOfInterestCount;
        }
    }
}
