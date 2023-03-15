using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class OldChainMail : BlankArmor
    {
        static private string Name;
        public OldChainMail(string charname) : base(200, 20, 50, Name)
        {
            Name = $"{charname}'s old chain mail";
        }
    }
}
