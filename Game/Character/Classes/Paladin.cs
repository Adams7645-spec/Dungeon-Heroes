using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Paladin : BlankCharacter
    {
        public Paladin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Paladin";
            charName = GenerateName(random.Next(4, 8));
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            base.HitEnemy(enemy);
        }
        public override void AbilityHitEnemy(BlankCharacter enemy)
        {
            if (random.Next(2) > 1)
            {
                if (random.Next(10) >= 5)
                {
                    logger.AddNewLog(AbilityHitEnemyLog(enemy));
                    enemy.TakeDamage(totalHealth * random.Next(20, 45) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
            else
            {
                if (random.Next(10) >= 7)
                {
                    logger.AddNewLog(AbilityHitEnemyLog(enemy));
                    enemy.TakeDamage(totalStrengh + totalHealth * random.Next(20, 35) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
