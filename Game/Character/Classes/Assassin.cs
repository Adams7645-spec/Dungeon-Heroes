using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Assassin : BlankCharacter
    {
        public Assassin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Assassin";
            charName = GenerateName(random.Next(4, 8));
        }

        public override void HitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 8)
                {
                    Console.WriteLine($"{CharInfo()} делает рывок за спину {enemy.CharInfo()}", Console.ForegroundColor = ConsoleColor.Red);
                    enemy.TakeDamage(totalStrengh + totalStrengh * random.Next(50, 100) / 100);
                    Console.ResetColor();
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
            else
            {
                if (random.Next(10) >= 5)
                {
                    Console.WriteLine($"{CharInfo()} кидает кинжал в {enemy.CharInfo()}", Console.ForegroundColor = ConsoleColor.Red);
                    enemy.TakeDamage(totalStrengh + totalStrengh * random.Next(30, 60) / 100);
                    Console.ResetColor();
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
