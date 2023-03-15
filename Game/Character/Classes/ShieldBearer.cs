using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class ShieldBearer : BlankCharacter
    {
        public ShieldBearer(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Shielder";
            charName = GenerateName(random.Next(4, 8));
        }
        public override void AbilityHitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 3)
                {
                    logger.AddNewLog(AbilityHitEnemyLog(enemy));
                    enemy.TakeDamage(totalDefense * random.Next(50, 100) / 100);
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
                    enemy.TakeDamage(totalDefense + totalDefense * random.Next(100, 120) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
