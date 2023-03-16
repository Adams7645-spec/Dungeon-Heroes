using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BossDemon : BlankCharacter
    {
        public readonly string[] demonAscii = new string[]
        {
            @"      `  `",
            @"      \    \",
            @"       \\___\\___ /\",
            @"      /____      \   \",
            @"     / /\  \   /\ \   |",
            @"    | |_@|_ \ // \ \ /",
            @"   //\       ||_ | |/",
            @"  / /  \__|     /  /",
            @" |__-     /   \/ /",
            @"   /___/     / /",
            @"   \       /  |",
            @"    |    /    \___",
            @"     \_/          \",
        };
        public BossDemon(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "BossDemon";
            charName = "Galos";
            charAscii = demonAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} высасывает жизненные силы из {enemy.CharInfo()}", Console.ForegroundColor = ConsoleColor.Red);
                    enemy.TakeDamage(totalStrengh + totalStrengh * random.Next(30, 80) / 100);
                    Console.ResetColor();
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
            else
            {
                if (random.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} уходит в мир теней", Console.ForegroundColor = ConsoleColor.Red);
                    enemy.TakeDamage(totalDefense + totalDefense * random.Next(40, 60) / 100);
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
