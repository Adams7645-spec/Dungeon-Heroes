using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class TestClass : BlankCharacter
    {
        public TestClass(int baseHealth, int baseStrengh, int baseDefense) : base(baseHealth, baseStrengh, baseDefense)
        {
            this.baseHealth = baseHealth;
            this.baseStrengh = baseStrengh;
            this.baseDefense = baseDefense;
        }
    }
}
