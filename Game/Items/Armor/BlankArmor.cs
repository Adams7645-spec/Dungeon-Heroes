using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    class BlankArmor
    {
        protected int healthBonus;
        protected int strenghBonus;
        protected int defenseBonus;

        protected string armorName;

        //
        public int HealthBonus { get => healthBonus; }
        public int StrenghBonus { get => strenghBonus; }
        public int DefenseBonus { get => defenseBonus; }

        public BlankArmor(int healthBonus, int strenghBonus, int defenseBonus)
        {
            this.healthBonus = healthBonus;
            this.strenghBonus = strenghBonus;
            this.defenseBonus = defenseBonus;
        }
        //armor passive skill 
    }
}
