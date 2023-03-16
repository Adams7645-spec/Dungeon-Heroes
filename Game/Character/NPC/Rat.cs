using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Rat : BlankCharacter
    {
        public readonly string[] RatAscii = new string[]
        {
            @"    __       __     _",
            @"   /-.\     /  \   //",
            @"   \  \|_,_/|  /  ((",
            @"    `\ `    `\'    \\",
            @"    /  _   _  \     ))",
            @"   |  (0\ /0)  |   //",
            @"   \           /  //",
            @"   /`.== 0 ==.`\ ((",
            @"  /   `~~W~~`   \ \\",
            @" |   ,       ,   | ))",
            @" \   \       /   ///",
            @" /`vvvv     vvvv`\/",
            @"|                 |"
        };
        public Rat(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Rat";
            charName = "Rat";
            charAscii = RatAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            logger.AddNewLog(HitEnemyLog(enemy));
            enemy.TakeDamage(totalStrengh);
        }
    }
}
