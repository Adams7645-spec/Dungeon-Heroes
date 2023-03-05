using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BlankWeapon
    {
        protected int weaponBaseDamage;
        protected int damageBonus;
        protected string weaponName;

        public int WeaponBaseDamage { get => weaponBaseDamage; }
        public int DamageBonus { get => damageBonus; }
        public string WeaponName { get => weaponName; }

        public BlankWeapon(int weaponBaseDamage, int damageBonus, string weaponName)
        {
            this.weaponBaseDamage = weaponBaseDamage;
            this.damageBonus = damageBonus;
            this.weaponName = weaponName;
        }

        public virtual void Upgrade(int optionToUpgrade)
        {
            if(optionToUpgrade == 0)
            {
                weaponBaseDamage += Convert.ToInt32(weaponBaseDamage * 0.2);
            }
            else
            {
                damageBonus += Convert.ToInt32(damageBonus * 0.2);
            }
        }
    }
}
