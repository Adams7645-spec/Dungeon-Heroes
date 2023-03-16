using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Priest : BlankCharacter
    {
        public readonly string[] priestAscii = new string[]
        {
            @"          _..._",
            @"         (,-'-,)",
            @"        / `'''` \",
            @"       |  /_ _\  |",
            @"    .--.\(  _  )/.--.",
            @"   /  .' '-...-' '.  \",
            @"  |  /    _/|\_    \  |",
            @"  /  |  -' \|/ '-  |  \",
            @" /    \__..-'-..__/    \",
            @"(      /         \      )",
            @" '-'._/           \_.'-'",
            @"     /             \",
            @"    (               )",
        };
        public Priest(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Priest";
            charName = GenerateName(random.Next(4, 8));
            charAscii = priestAscii;
        }
        public override void AbilityHitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 5)
                {
                    logger.AddNewLog(AbilityHitEnemyLog(enemy));
                    enemy.TakeDamage(totalHealth * random.Next(10, 30) / 100);
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
                    logger.AddNewLog(AbilityHitEnemyLog(enemy));
                    enemy.TakeDamage(totalHealth + totalHealth * random.Next(30, 50) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
