using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Goblin : BlankCharacter
    {
        public Goblin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Goblin";
            charName = "Goblin";
        }
        public override void HitEnemy(BlankCharacter enemy)
        {
            logger.AddNewLog(HitEnemyLog(enemy));
            enemy.TakeDamage(totalStrengh);
        }
    }
}
