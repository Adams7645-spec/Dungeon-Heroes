using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BlankDungeon
    {
        protected string LevelName { get; set; }
        protected int PointOfInterestCount { get; set; }
        protected List<List<List<int>>> rooms = new List<List<List<int>>> { };
        public BlankDungeon()
        {
            LevelName = "Path";
            PointOfInterestCount = 0;
        }
        protected void SetRoomGrid(int startX, int lenghtX, int startY, int lenghtY)
        {
            List<List<int>> room = new List<List<int>>();
            List<int> row = new List<int>();

            for (int Y = startY; Y < startY + lenghtY; Y++)
            {
                row = new List<int>();
                for (int X = startX; X < startX + lenghtX; X++)
                {
                    row.Add(0);
                }
                room.Add(row);
            }
            rooms.Add(room);
        }
        public virtual int GetRoomPosX()
        {
            return 0;
        }
        public virtual int GetRoomPosY()
        {
            return 0;
        }
        protected void SetRoom(List<int> room)
        {
            SetRoomGrid(room[0], room[1], room[2], room[3]);
        }
        public int GetAmountOfPoints()
        {
            return PointOfInterestCount;
        }
        public List<List<List<int>>> GetRoomGrids()
        {
            return rooms;
        }
        public virtual void Debug()
        {

        }
    }
}
