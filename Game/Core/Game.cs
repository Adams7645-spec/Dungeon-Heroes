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
                (random.Next(650, 750), random.Next(60, 80), random.Next(100, 120));
            BlankCharacter assassin = new Assassin
                (random.Next(450, 550), random.Next(110, 130), random.Next(100, 120));

            BlankArmor defaultArmor = new TestArmor(40, 10, 30);
            BlankWeapon defaultWeapon = new BlankWeapon(50, 30, "Test");

            //character.GetNewArmor(defaultArmor);
            //character.GetNewWeapon(defaultWeapon);
            //Console.WriteLine($"{character.CharBrief()}");

            assassin.GetNewArmor(defaultArmor);
            assassin.GetNewWeapon(defaultWeapon);
            assassin.RecalculateAll();
            Console.WriteLine($"{assassin.CharBrief()}");

            //Проблема повышения уровня в пересчете изменяемого базового стата. Заменить на константу 

            //while (true)
            //{
            //    character.HitEnemy(assassin);
            //    if (assassin.IsDead())
            //    {
            //        Console.WriteLine($"{character.CharInfo()} победил!");
            //        break;
            //    }
            //    assassin.HitEnemy(character);
            //    if (character.IsDead())
            //    {
            //        Console.WriteLine($"{assassin.CharInfo()} победил!");
            //        break;
            //    }
            //}
            Console.ReadKey();
        }
    }
}
