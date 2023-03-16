using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Skeleton : BlankCharacter
    {
        public readonly string[] skeletonAscii = new string[]
        {
            @"           _.--''-._",
            @"         .'         '.",
            @" /(     Y             |      )\",
            @"(  \__..'--   -   -- -'..__/  )",
            @" '.     l_..-------.._l      .'",
            @"   '-.__.||_.-'v'-._||`'----'",
            @"         l._       _.'",
            @"           l`^^'^^'j",
            @"            \_____/ ",
        };
        public Skeleton(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Skeleton";
            charName = "Skeleton";
            charAscii = skeletonAscii;
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            logger.AddNewLog(HitEnemyLog(enemy));
            enemy.TakeDamage(totalStrengh);
        }
    }
}
