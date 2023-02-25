using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class GameProcess
    {
        Random random = new Random();
        DifficultyLevel difficulty = new DifficultyLevel();
        MainMenuInterface menu = new MainMenuInterface();
        DrawingInterface drawer = new DrawingInterface();

        List<BlankCharacter> PlayerTeam = new List<BlankCharacter> { };
        public void Game()
        {
            Console.Clear();
            ShowGameLore();
            CreatePlayerTeam();
            ShowBeginningScreen();

            //testing fights
            FightWithEnemyEvent();

            Console.Read();

            menu.ShowMainMenuScreen();
        }
        private void ShowGameLore()
        {
            //окно с вводящей в курс дела информацией 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] gameLore = new string[] 
                { 
                    "Путешественник, добро пожаловать в Dungeon Heroes!" ,
                    "Dungeon Heroes - это приключенческое RPG", 
                    "Здесь Вам предстоит собрать команду из 4 приключенцев",
                    "И вместе с ними отправиться в путешестивие по землям Голангана.",
                    "Будьте предельно внимательны, Ваше путешествие будет отнюдь не простым",
                    "Проходите подземелья, улучшайте снаряжение Ваших героев и повышайте уровень",
                    "Ведь только так Вы сможете одолеть Фотбора, вечного правителя Голангана."
                };

            for(int i = 0; i < (gameLore.Length) * 2; i += 2)
            {
                drawer.PositionText(gameLore[i / 2], 14, 8 + i);
            }
            Console.ResetColor();

            drawer.PrintPressAnyKeyLikeText("Нажмите, чтобы перейти к созданию персонажей");
        }
        private void CreatePlayerTeam()
        {
            Console.Clear();
            List<string> options = new List<string> { "Выбрать Assassin", "Выбрать Gunslinger",
                                                      "Выбрать Paladin", "Выбрать Priest",
                                                      "Выбрать ShieldBearer"};
            UserOptionsInteraction interaction = new UserOptionsInteraction(options);

            for (int i = 0; PlayerTeam.Count < 4; i++)
            {
                drawer.PositionText($"Персонаж №{i + 1}", (Console.WindowWidth - 11) / 2, 3);
                drawer.PositionText($"Выберите желаемого персонажа:", (Console.WindowWidth - 29) / 2, 4);

                interaction.SelectOption(41, 12);

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
        private void ShowBeginningScreen()
        {
            Console.Clear();
            drawer.PrintTeamBrief(PlayerTeam, 20, 3);
            drawer.PrintWorldInfo(20, 18);
            drawer.PrintPressAnyKeyLikeText("Нажмите, чтобы начать приключение!");
        }
        private void FightWithEnemyEvent()
        {
            Console.Clear();

            List<string> ChooseAlly = new List<string> { };
            List<string> ChooseEnemy = new List<string> { };

            UserOptionsInteraction interactionChooseAlly = new UserOptionsInteraction(ChooseAlly);
            UserOptionsInteraction interactionChooseEnemy = new UserOptionsInteraction(ChooseEnemy);

            //Заполнение команды соперников 
            List<BlankCharacter> EnemyTeam = new List<BlankCharacter> { };
            while (EnemyTeam.Count < difficulty.MaxEnemyAtRoom)
            {
                //Добавить больше противников и сделать рандомную генерацию
                BlankCharacter enemy = new SampleNPC1(
                    Convert.ToInt32(random.Next(300, 400) * difficulty.AdictionalNPCHealth), 
                    Convert.ToInt32(random.Next(30, 45) * difficulty.AdictionalNPCStrenght), 
                    Convert.ToInt32(random.Next(50, 60) * difficulty.AdictionalNPCDefense));
                EnemyTeam.Add(enemy);
            }

            //Создаем список для выбора персонажа при помощи опций

            //Механика сражения
            drawer.PositionText("На вас напали!", 30, 5);

            while (EnemyTeam.Count != 0)
            {
                Console.Clear();
                for (int i = 0; ChooseAlly.Count < PlayerTeam.Count; i++)
                {
                    ChooseAlly.Add(PlayerTeam[i].CharInfo());
                }
                for (int i = 0; ChooseEnemy.Count < EnemyTeam.Count; i++)
                {
                    ChooseEnemy.Add(EnemyTeam[i].CharInfo());
                }

                interactionChooseAlly.SelectOption(50, 5);
                interactionChooseEnemy.SelectOption(50, 10);

                while (true)
                {
                    PlayerTeam[interactionChooseAlly.OptionCounter].HitEnemy(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                    Thread.Sleep(25);
                    EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemy(PlayerTeam[interactionChooseAlly.OptionCounter]);
                    if (EnemyTeam[interactionChooseEnemy.OptionCounter].IsDead())
                    {
                        Console.WriteLine($"{PlayerTeam[interactionChooseAlly.OptionCounter].CharInfo()} победил!");
                        EnemyTeam.Remove(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                        break;
                    }
                }
            }
            drawer.PositionText("Вы победили всех врагов!", 40, 30);
        }
    }
}
