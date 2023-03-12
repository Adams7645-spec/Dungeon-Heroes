using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class EasyDungeon : BlankDungeon
    {
        BlankRoom room;
                                        // startX, lenghtX, startY, lenghtY
        protected List<int> room1 = new List<int> { 7, 6 , 6, 7 };
        protected List<int> room2 = new List<int> { 15, 14, 17, 7 };
        public EasyDungeon()
        {
            //класс комнаты 
            LevelName = "Easy1Level.txt";
            PointOfInterestCount = 5;
            room = new BlankRoom(room2[0], room2[2]);
            SetRoom(room1);
            SetRoom(room2);
        }
        public override int GetRoomPosX()
        {
            return room.PosX;
        }
        public override int GetRoomPosY()
        {
            return room.PosX;
        }
        public override void Debug()
        {
        }
    }
}
