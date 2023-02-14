using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class TestClass : BlankCharacter
    {
        public TestClass(int health, int strengh, int defense, string charName, string className) : base(health, strengh, defense)
        {
            this.className = className;
            this.charName = charName;
            
        }
    }
}
