using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class ShortSword : BlankWeapon
    {
        static string Name;
        public ShortSword(string charname) : base(150, 20, Name)
        {
            Name = $"{charname}'s short sword";
        }
    }
}
