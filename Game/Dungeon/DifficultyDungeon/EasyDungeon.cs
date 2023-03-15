using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class EasyDungeon : BlankDungeon
    {
                                        // startX, lenghtX, startY, lenghtY
        protected List<int> room1 = new List<int> { 7, 5 , 6, 6 };
        protected List<int> room2 = new List<int> { 16, 13, 17, 7 };
        protected List<int> room3 = new List<int> { 28, 18, 9, 4 };
        protected List<int> room4 = new List<int> { 36, 8, 19, 4 };
        protected List<int> room5 = new List<int> { 50, 6, 27, 2 };

        public EasyDungeon() : base(8,5,5,21)
        {
            //класс комнаты 
            LevelName = "Easy1Level.txt";
            SetRoom(room1);
            SetRoom(room2);
            SetRoom(room3);
            SetRoom(room4);
            SetRoom(room5);
        }
    }
}
