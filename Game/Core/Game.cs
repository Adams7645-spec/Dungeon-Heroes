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
        static string GenerateName(int lenght) //Перенести генерацию в класс Game
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            int b = 0;
            while (b < lenght)
            {
                Name += consonants[random.Next(consonants.Length)];
                b++;
                Name += vowels[random.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        static void Main(string[] args)
        {
            BlankCharacter character = new TestClass
                (random.Next(500, 750), random.Next(60, 80), random.Next(100, 120), GenerateName(random.Next(4,8)), "TestClass");
            BlankCharacter assassin = new Assassin(random.Next(450, 550), random.Next(100, 120), random.Next(100, 120), GenerateName(random.Next(4, 8)), "Assassin");
            BlankArmor defaultArmor = new TestArmor(40, 10, 30);
            BlankWeapon defaultWeapon = new BlankWeapon(50, 30, "Test");

            character.GetNewArmor(defaultArmor);
            character.GetNewWeapon(defaultWeapon);
            Console.WriteLine($"{character.CharBrief()}");

            assassin.GetNewArmor(defaultArmor);
            assassin.GetNewWeapon(defaultWeapon);
            Console.WriteLine($"{assassin.CharBrief()}");

            while (true)
            {
                character.HitEnemy(assassin);
                if (assassin.IsDead())
                {
                    Console.WriteLine($"{character.CharInfo()} победил!");
                    break;
                }
                assassin.HitEnemy(character);
                if (character.IsDead())
                {
                    Console.WriteLine($"{assassin.CharInfo()} победил!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
