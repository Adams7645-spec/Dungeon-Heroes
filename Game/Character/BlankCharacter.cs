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

        protected string charName;
        protected string className;

        //Конструктор 
        public BlankCharacter(int baseHealth, int baseStrengh, int baseDefense)
        {
            this.baseHealth = baseHealth;
            this.baseStrengh = baseStrengh;
            this.baseDefense = baseDefense;
            Recalculate();
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
        private void Recalculate()//Пересчитываем статы 
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
