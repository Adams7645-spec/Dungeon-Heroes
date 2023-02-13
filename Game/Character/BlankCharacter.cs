using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    class BlankCharacter
    {
        static Random random = new Random();

        //fields 
        protected int baseHealth;
        protected int baseStrengh;
        protected int baseDefense;

        protected int totalHealth;
        protected int totalStrengh;
        protected int totalDefense;

        protected int weaponDamageBonus;

        protected int armorDamageBonus;
        protected int armorHealthBonus;
        protected int armorDefenseBonus;

        protected int charLevel;

        protected string charName;
        protected string className;

        //constructor
        public BlankCharacter(int baseHealth, int baseStrengh, int baseDefense)
        {
            this.baseHealth = baseHealth;
            this.baseStrengh = baseStrengh;
            this.baseDefense = baseDefense;

            totalHealth = baseHealth + armorHealthBonus;
            totalStrengh = baseStrengh + weaponDamageBonus + armorDamageBonus;
            totalDefense = baseDefense + armorDefenseBonus;

            charName = GenerateName(random.Next(4, 8));
        }
        //name generator 
        public static string GenerateName(int lenght)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            int b = 0;
            while (b < lenght)
            {
                Name += consonants[random.Next(consonants.Length)];
                b++;
                Name += vowels[random.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        //fighting methods 
        //Для реализации урона от способности переопределяем HitEnemy и TakeDamage
        public virtual void HitEnemy(BlankCharacter enemy)
        {
            Console.WriteLine($"{CharInfo()} атакует {enemy.CharInfo()}");
            enemy.TakeDamage(totalStrengh);
        }
        public virtual void TakeDamage(int damage)
        {
            totalHealth -= damage - (damage * totalDefense / 100);
            Console.WriteLine($"{CharInfo()} получил урон {damage}");
        }
        //character information  methods
        public string CharBrief()
        {
            return $"Class: {className}\n" +
                $"Name: {charName}\n" +
                $"\n" +
                $"Health: {totalHealth}\n" +
                $"Strengh: {totalStrengh}\n" +
                $"Defense: {totalDefense}\n" +
                $"\n" +
                $"Is dead: {IsDead()}";
        }
        public string BaseCharBrief()
        {
            return $"Class: {className}\n" +
                $"Name: {charName}\n" +
                $"\n" +
                $"Health: {baseHealth}\n" +
                $"Strengh: {baseStrengh}\n" +
                $"Defense: {baseDefense}\n" +
                $"\n" +
                $"Is dead: {IsDead()}";
        }
        public string CharInfo()
        {
            return $"[{className}] {charName} [{totalHealth}]";
        }
        public bool IsDead()
        {
            return totalHealth <= 0;
        }
        //Character interaction 
        private void Recalculate()//calculate stats
        {
            totalHealth = baseHealth + armorHealthBonus;
            totalStrengh = baseStrengh + weaponDamageBonus + armorDamageBonus;
            totalDefense = baseDefense + armorDefenseBonus;
        }
        public void GetNewArmor(BlankArmor armor)
        {
            armorDamageBonus = baseStrengh * armor.StrenghBonus / 100;
            armorHealthBonus = baseHealth * armor.HealthBonus / 100;
            armorDefenseBonus = baseDefense * armor.DefenseBonus / 100;

            Recalculate();
        }
        public void GetNewWeapon(BlankWeapon weapon)
        {
            weaponDamageBonus = (baseStrengh + weapon.WeaponBaseDamage / 100) * weapon.DamageBonus / 100;
            
            Recalculate();
        }
    }
}
