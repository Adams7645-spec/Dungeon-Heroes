using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Goblin : BlankCharacter
    {
        public readonly string[] goblinAscii = new string[]
        {
            @"       ,      ,",
            @"      /(.-''-.)\",
            @"  |\  \/      \/  /|",
            @"  | \ / =.  .= \ / |",
            @"  \( \   o\/o   / )/",
            @"   \_, '-/  \-' ,_/",
            @"     /   \__/   \",
            @"     \ \__/\__/ /",
            @"   ___\ \|--|/ /___",
            @" /`    \      /    `\",
            @"/       '----'       \",
        };
        public Goblin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Goblin";
            charName = "Goblin";
            charAscii = goblinAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            logger.AddNewLog(HitEnemyLog(enemy));
            enemy.TakeDamage(totalStrengh);
        }
    }
}
