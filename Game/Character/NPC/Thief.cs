using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Thief : BlankCharacter
    {
        public readonly string[] thiefAscii = new string[]
        {
            @"  .     '     ,",
            @"    _________",
            @" _ /_|_____|_\ _",
            @"   '. \   / .'",
            @"     '.\ /.'",
            @"       '.'",
        };
        public Thief(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Thief";
            charName = "Thief";
            charAscii = thiefAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            logger.AddNewLog(HitEnemyLog(enemy));
            enemy.TakeDamage(totalStrengh);
        }
    }
}
