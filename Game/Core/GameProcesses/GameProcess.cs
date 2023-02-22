using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class GameProcess
    {
        Random random = new Random();
        MainMenuInterface menu = new MainMenuInterface();
        DrawingInterface drawer = new DrawingInterface();

        List<BlankCharacter> PlayerTeam = new List<BlankCharacter> { };
        public void Game()
        {
            Console.Clear();
            PlayerCreation();

            menu.ShowMainMenuScreen();
        }
        private void PlayerCreation()
        {
            List<string> options = new List<string> { "Выбрать Assassin", "Выбрать Gunslinger",
                                                      "Выбрать Paladin", "Выбрать Priest",
                                                      "Выбрать ShieldBearer"};
            UserOptionsInteraction interaction = new UserOptionsInteraction(options);

            for (int i = 0; PlayerTeam.Count < 4; i++)
            {
                drawer.PositionText($"Персонаж №{i + 1}", (Console.WindowWidth - 11) / 2, 3);
                drawer.PositionText($"Выберите желаемого персонажа:", (Console.WindowWidth - 29) / 2, 4);

                interaction.SelectOption();

                switch (interaction.OptionCounter)
                {
                    case 0:
                        BlankCharacter assassin = new Assassin
                            (random.Next(450, 550), random.Next(110, 130), random.Next(60, 70));
                        PlayerTeam.Add(assassin);
                        break;
                    case 1:
                        BlankCharacter gunslinger = new Gunslinger
                            (random.Next(650, 750), random.Next(60, 80), random.Next(90, 100));
                        PlayerTeam.Add(gunslinger);
                        break;
                    case 2:
                        BlankCharacter Paladin = new Paladin
                            (random.Next(800, 900), random.Next(75, 100), random.Next(120, 140));
                        PlayerTeam.Add(Paladin);
                        break;
                    case 3:
                        BlankCharacter Priest = new Priest
                            (random.Next(500, 600), random.Next(50, 65), random.Next(40, 50));
                        PlayerTeam.Add(Priest);
                        break;
                    case 4:
                        BlankCharacter ShieldBearer = new ShieldBearer
                            (random.Next(1000, 1100), random.Next(40, 50), random.Next(130, 150));
                        PlayerTeam.Add(ShieldBearer);
                        break;
                }

                drawer.PositionText($"{i + 1}){PlayerTeam[i].CharInfo()}", 5, 10 + i);
            }
            drawer.PrintPressAnyKeyLikeText("Персонажи выбраны! Нажмите, чтобы продолжить...");
        }

        //while (true)
        //{
        //    gunslinger.HitEnemy(assassin);
        //    if (assassin.IsDead())
        //    {
        //        Console.WriteLine($"{gunslinger.CharInfo()} победил!");
        //        break;
        //    }
        //    Thread.Sleep(25);
        //    assassin.HitEnemy(gunslinger);
        //    if (gunslinger.IsDead())
        //    {
        //        Console.WriteLine($"{assassin.CharInfo()} победил!");
        //        break;
        //    }
        //}
    }
}
