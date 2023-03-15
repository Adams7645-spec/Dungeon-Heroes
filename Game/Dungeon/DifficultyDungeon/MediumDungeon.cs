using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class MediumDungeon : BlankDungeon
    {
        protected List<int> room1 = new List<int> { 5, 17, 4, 2 };
        protected List<int> room2 = new List<int> { 10, 6, 9, 9 };
        protected List<int> room3 = new List<int> { 19, 10, 10, 2 };
        protected List<int> room4 = new List<int> { 26, 11, 17, 2 };
        protected List<int> room5 = new List<int> { 45, 14, 9, 6 };
        protected List<int> room6 = new List<int> { 5, 5, 22, 6 };
        protected List<int> room7 = new List<int> { 11, 13, 25, 2 };
        protected List<int> room8 = new List<int> { 39, 8, 23, 2 };
        public MediumDungeon() : base(54, 4, 31, 31)
        {
            LevelName = "Medium1Level.txt";
            SetRoom(room1);
            SetRoom(room2);
            SetRoom(room3);
            SetRoom(room4);
            SetRoom(room5);
            SetRoom(room6);
            SetRoom(room7);
            SetRoom(room8);
        }
    }
}
