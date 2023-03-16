using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class BossDragon : BlankCharacter
    {
        public readonly string[] dragonAscii = new string[]
        {
            @"                      ,-,-    ",
            @"                     / / |   ",
            @"   ,-'             _/ / /    ",
            @"  (-_          _,-' ` _/     ",
            @"   '#:      ,-'_,-.    \  _    ",
            @"    #'    _(_-'_()\     \' |   ",
            @"  ,--_,--'                 |   ",
            @" / ''                      L-'\ ",
            @" \,--^---v--v-._        /   \ | ",
            @"   \_________________,-'      | ",
            @"                    \           ",
            @"                     \          ",
            @"                      \         "
        };
        public BossDragon(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "BossDragon";
            charName = "Dragon";
            charAscii = dragonAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} дышит огнем на {enemy.CharInfo()}", Console.ForegroundColor = ConsoleColor.Red);
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
                if (random.Next(10) >= 10)
                {
                    Console.WriteLine($"{CharInfo()} создает вокруг себя огненные доспехи", Console.ForegroundColor = ConsoleColor.Red);
                    enemy.TakeDamage(totalDefense + totalDefense * random.Next(20, 40) / 100);
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
