using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class RustyKnife : BlankWeapon
    {
        static string Name;
        public RustyKnife(string charname) : base(100, 20, Name)
        {
            Name = $"{charname}'s rusty knife";
        }
    }
}
