using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class TestArmor : BlankArmor
    {
        public TestArmor(int healthBonus, int strenghBonus, int defenseBonus) : base(healthBonus, strenghBonus, defenseBonus)
        {
            this.healthBonus = healthBonus;
            this.strenghBonus = strenghBonus;
            this.defenseBonus = defenseBonus;
        }
    }
}
