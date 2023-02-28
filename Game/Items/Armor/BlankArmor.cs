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
        public string ArmorName { get => armorName; }

        public BlankArmor(int healthBonus, int strenghBonus, int defenseBonus, string armorName)
        {
            this.healthBonus = healthBonus;
            this.strenghBonus = strenghBonus;
            this.defenseBonus = defenseBonus;
            this.armorName = armorName;
        }
        //armor passive skill 
    }
}
