using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class LetherArmor : BlankArmor
    {
        static private string Name;
        public LetherArmor(string charname) : base(50, 5, 20, Name)
        {
            Name = $"{charname}'s lether armor";
        }
    }
}
