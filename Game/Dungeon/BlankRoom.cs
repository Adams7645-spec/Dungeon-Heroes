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
        public BlankRoom(int roomPosX, int roomPosY)
        {
            this.PosX = roomPosX;
            this.PosY = roomPosY;
        }
    }
}
