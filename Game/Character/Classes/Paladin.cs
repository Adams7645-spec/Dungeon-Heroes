using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Paladin : BlankCharacter
    {
        public Paladin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Paladin";
            charName = GenerateName(random.Next(4, 8));
        }
    }
}
