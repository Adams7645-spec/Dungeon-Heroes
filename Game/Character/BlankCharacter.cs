using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    class BlankCharacter
    {
        static protected Random random = new Random();

        //Поля
        //Базовые статы
        protected int baseHealth;
        protected int baseStrengh;
        protected int baseDefense;

        //Итоговые статы
        protected int totalHealth;
        protected int totalStrengh;
        protected int totalDefense;

        //Бонусные статы
        protected int weaponDamageBonus;

        protected int armorDamageBonus;
        protected int armorHealthBonus;
        protected int armorDefenseBonus;

        //Несчетные данные персонажа
        protected int charLevel;
        protected int charExp;

        protected string charName;
        protected string className;

        //Конструктор 
        public BlankCharacter(int baseHealth, int baseStrengh, int baseDefense)
        {
            this.baseHealth = baseHealth;
            this.baseStrengh = baseStrengh;
            this.baseDefense = baseDefense;
        }

        //Генератор имен
        static protected string GenerateName(int lenght) //Перенести генерацию в класс Game
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

        //Методы для сражения
        //Для реализации урона от способности переопределяем HitEnemy и TakeDamage
        public virtual void HitEnemy(BlankCharacter enemy)
        {
            Console.WriteLine($"{CharInfo()} атакует {enemy.CharInfo()}");
            enemy.TakeDamage(totalStrengh);
        }
        public virtual void TakeDamage(int damage)
        {
            totalHealth -= damage;
            Console.WriteLine($"{CharInfo()} получил урон {damage}");
        }
        //Методы вывода информации о персонаже
        public string CharBrief()//Основной вывод информации
        {
            return $"Class: {className}\n" +
                $"Name: {charName}\n" +
                $"\n" +
                $"Health: {totalHealth}\n" +
                $"Strengh: {totalStrengh}\n" +
                $"Defense: {totalDefense}\n" +
                $"Level: {charLevel}\n" +
                $"Exp: {charExp}" +
                $"\n" +
                $"Is dead: {IsDead()}";
        }
        public string BaseCharBrief()//Вывод для тестов правильности пересчета статов при получении брони/оружия
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

        //Взаимодействие с персонажем
        //Метод необходимо вызывать при взаимодействии со статами персонажа 
        public void RecalculateAll()//Пересчитываем статы 
        {
            RecalculateLevel();
            RecalculateStats();
        }
        public void RecalculateStats()
        {
            //Пересчет итоговых статов
            totalHealth = baseHealth + +armorHealthBonus;
            totalStrengh = baseStrengh + weaponDamageBonus + armorDamageBonus;
            totalDefense = baseDefense + armorDefenseBonus;
        }
        public void RecalculateLevel()
        {
            int levelUpHealth = baseHealth / 10;
            int levelUpStrengh = baseStrengh / 10;
            int levelUpDefense = baseDefense / 10;

            //Пересчет уровня персонажа 
            while (true)
            {
                if (charExp >= 100)
                {
                    charLevel += 1;
                    charExp -= 100;

                    baseHealth += levelUpHealth;
                    baseStrengh += levelUpStrengh;
                    baseDefense += levelUpDefense;
                }
                else
                {
                    break;
                }
            }
        }
        public void GetNewArmor(BlankArmor armor)
        {
            armorDamageBonus = baseStrengh * armor.StrenghBonus / 100;
            armorHealthBonus = baseHealth * armor.HealthBonus / 100;
            armorDefenseBonus = baseDefense * armor.DefenseBonus / 100;

            RecalculateAll();
        }
        public void GetNewWeapon(BlankWeapon weapon)
        {
            weaponDamageBonus = (baseStrengh + weapon.WeaponBaseDamage / 100) * weapon.DamageBonus / 100;

            RecalculateAll();
        }
        public void GetNewLevel()
        {
            int levelUpHealth = 60;
            int levelUpStrengh = 6;
            int levelUpDefense = 10;
            int levelThreshold = 100;

            if (charExp >= levelThreshold)
            {
                baseHealth += levelUpHealth;
                baseStrengh += levelUpStrengh;
                baseDefense += levelUpDefense;
            }
        }
        public void GetExp(int exp)
        {
            charExp += exp;
        }
    }
}
