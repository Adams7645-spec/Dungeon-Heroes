using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Game
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            BlankCharacter character = new TestClass
                (random.Next(150, 150), random.Next(80, 80), random.Next(120, 120));
            //TestClass b2 = new TestClass
            //    (random.Next(8, 17), random.Next(2, 10), random.Next(3, 12));
            BlankArmor defaultArmor = new TestArmor(40, 10, 30);
            BlankWeapon defaultWeapon = new BlankWeapon(50, 30, "Test");

            character.GetNewArmor(defaultArmor);
            character.GetNewWeapon(defaultWeapon);
            Console.WriteLine($"{character.BaseCharBrief()}");
            Console.WriteLine($"{character.CharBrief()}");

            //while (true)
            //{
            //    b1.HitEnemy(b2);
            //    if (b2.IsDead())
            //    {
            //        Console.WriteLine($"{b1.CharInfo()} победил!");
            //        break;
            //    }
            //    b2.HitEnemy(b1);
            //    if (b1.IsDead())
            //    {
            //        Console.WriteLine($"{b2.CharInfo()} победил!");
            //        break;
            //    }
            //}
            Console.ReadKey();
        }
    }
}
