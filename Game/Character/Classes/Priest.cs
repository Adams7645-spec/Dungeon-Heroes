using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Priest : BlankCharacter
    {
        public Priest(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Priest";
            charName = GenerateName(random.Next(4, 8));
        }
    }
}
