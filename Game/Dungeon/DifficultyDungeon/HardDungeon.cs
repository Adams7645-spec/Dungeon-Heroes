using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class HardDungeon : BlankDungeon
    {
        protected List<int> room1 = new List<int> { 5, 11, 8, 5 };
        protected List<int> room2 = new List<int> { 20, 7, 7, 5 };
        protected List<int> room3 = new List<int> { 29, 7, 12, 4 };
        protected List<int> room4 = new List<int> { 42, 13, 7, 3 };
        protected List<int> room5 = new List<int> { 5, 11, 18, 3 };
        protected List<int> room6 = new List<int> { 18, 19, 29, 2 };
        protected List<int> room7 = new List<int> { 54, 5, 22, 3 };
        protected List<int> room8 = new List<int> { 54, 5, 31, 1 };
        protected List<int> room9 = new List<int> { 7, 7, 24, 3 };
        public HardDungeon() : base(11,5)
        {
            LevelName = "Hard1Level.txt";
            SetRoom(room1);
            SetRoom(room2);
            SetRoom(room3);
            SetRoom(room4);
            SetRoom(room5);
            SetRoom(room6);
            SetRoom(room7);
            SetRoom(room8);
            SetRoom(room9);
        }
    }
}
