using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class TestClass : BlankCharacter
    {
        public TestClass(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "TestClass";
            charName = GenerateName(random.Next(4, 8));
        }
    }
}
