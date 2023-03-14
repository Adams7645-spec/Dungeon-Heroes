using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Assassin : BlankCharacter
    {
        public Assassin(int health, int strengh, int defense) : base(health, strengh, defense)
        {
            className = "Assassin";
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
                if (random.Next(10) >= 8)
                {
                    enemy.TakeDamage(totalStrengh + totalStrengh * random.Next(50, 100) / 100);
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
                    enemy.TakeDamage(totalStrengh + totalStrengh * random.Next(30, 60) / 100);
                }
                else
                {
                    base.HitEnemy(enemy);
                }
            }
        }
    }
}
