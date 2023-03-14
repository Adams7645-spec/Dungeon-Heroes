using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BlankRoom
    {
        public int PosX { get; }
        public int PosY { get; }
        public int LenghtX { get; }
        public int LenghtY { get; }
        public List<List<int>> Grid = new List<List<int>> { };
        public BlankRoom(int roomPosX, int roomPosY, int roomLenghtX, int roomLenghtY)
        {
            this.PosX = roomPosX;
            this.PosY = roomPosY;
            this.LenghtX = roomLenghtX;
            this.LenghtY = roomLenghtY;
        }
        public void AddGrid(List<List<int>> roomGrid)
        {
            Grid = roomGrid;
        }
    }
}
