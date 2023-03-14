using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class ShieldBearer : BlankCharacter
    {
        public ShieldBearer(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Shielder";
            charName = GenerateName(random.Next(4, 8));
        }
    }
}
