using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class TestWeapon : BlankWeapon
    {
        public TestWeapon(int weaponBaseDamage, int damageBonus, string weaponName) : base(weaponBaseDamage, damageBonus, weaponName)
        {
            this.weaponBaseDamage = weaponBaseDamage;
            this.damageBonus = damageBonus;
            this.weaponName = weaponName;
        }
    }
}
