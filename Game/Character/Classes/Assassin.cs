using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Assassin : BlankCharacter
    {
        public Assassin(int health, int strengh, int defense, string charName, string className) : base(health, strengh, defense)
        {
            this.className = className;
            this.charName = charName;
        }

        public override void HitEnemy(BlankCharacter enemy)
        {
            Random rnd = new Random();
            if (rnd.Next(2) > 1)
            {
                if (rnd.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} делает рывок за спину {enemy.CharInfo()}");
                    enemy.TakeDamage(totalStrengh + totalStrengh * rnd.Next(50, 100) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
            else
            {
                if (rnd.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} кидает кинжал в {enemy.CharInfo()}");
                    enemy.TakeDamage(totalStrengh + totalStrengh * rnd.Next(30, 60) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
