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

        int generalGold;
        int newGold;
        int newExp;

        List<BlankCharacter> PlayerTeam = new List<BlankCharacter> { };
        List<BlankWeapon> WeaponList = new List<BlankWeapon> { };
        List<BlankArmor> ArmorList = new List<BlankArmor> { };
        List<string> ChooseAlly = new List<string> { };
        public void Game()
        {
            Console.Clear();
            ShowGameLore();
            CreatePlayerTeam();
            ShowBeginningScreen();

            //Реализовать основной метод Adventure, где мы можем бродить по карте, искать сокровища или врагов

            FightWithEnemyEvent();

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
            Logger logger = new Logger();

            List<string> ChooseEnemy = new List<string> { };
            List<string> ChooseAction = new List<string> { "Атака", "Способность", "Побег!" };

            //Заполнение команды противников 
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

            Console.Clear();

            //Механика сражения
            drawer.PositionText("На вас напали!", 30, 5);
            while (EnemyTeam.Count != 0)
            {
                RebuildTeam(ChooseEnemy, EnemyTeam);
                RebuildTeam(ChooseAlly, PlayerTeam);

                Console.Clear();

                //Экземпляры класса интерактивного выбора опций 
                UserOptionsInteraction interactionChooseAlly = new UserOptionsInteraction(ChooseAlly);
                UserOptionsInteraction interactionChooseEnemy = new UserOptionsInteraction(ChooseEnemy);

                //Создаем список для выбора персонажа при помощи опций
                drawer.PositionGreenColorText("Выберите вашего бойца: ", 5 , 3);
                interactionChooseAlly.SelectOption(10, 5);

                drawer.PositionRedColorText("Начать сражение с противником:", 65, 3);
                interactionChooseEnemy.SelectOption(60, 5);

                //Цикл боя до момента смерти союзника/противника
                while (true)
                {
                    Console.Clear();

                    logger.PrintBattleLog(30, 10);

                    UserOptionsInteraction interactionChooseAction = new UserOptionsInteraction(ChooseAction);

                    drawer.PrintCharBrief(PlayerTeam, 6, 3, interactionChooseAlly.OptionCounter, 1);
                    drawer.PrintCharBrief(EnemyTeam, 75, 3, interactionChooseEnemy.OptionCounter, 2);

                    if (PlayerTeam[interactionChooseAlly.OptionCounter].IsDead())
                    {
                        PlayerTeam.Remove(PlayerTeam[interactionChooseAlly.OptionCounter]);
                        break;
                    }

                    interactionChooseAction.SelectOption(45, 3);

                    switch (interactionChooseAction.OptionCounter)
                    {
                        case 0:
                            PlayerTeam[interactionChooseAlly.OptionCounter].HitEnemy(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                            logger.AddNewLog(PlayerTeam[interactionChooseAlly.OptionCounter].HitEnemyLog(EnemyTeam[interactionChooseEnemy.OptionCounter]));
                            break;
                        case 1:
                            PlayerTeam[interactionChooseAlly.OptionCounter].AbilityHitEnemy(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                            logger.AddNewLog(PlayerTeam[interactionChooseAlly.OptionCounter].AbilityHitEnemyLog(EnemyTeam[interactionChooseEnemy.OptionCounter]));
                            break;
                        case 2:
                            drawer.PrintPressAnyKeyLikeText("Вам удалось сбежать!");
                            return;
                    }

                    Thread.Sleep(25);

                    if (EnemyTeam[interactionChooseEnemy.OptionCounter].IsDead())
                    {
                        drawer.PositionGreenColorText($"{PlayerTeam[interactionChooseAlly.OptionCounter].CharInfo()} победил!", 33, 25);
                        drawer.PrintPressAnyKeyLikeText($"{EnemyTeam[interactionChooseEnemy.OptionCounter].CharInfo()} повержен!");
                        EnemyTeam.Remove(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                        break;
                    }

                    EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemy(PlayerTeam[interactionChooseAlly.OptionCounter]);
                    logger.AddNewLog(EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemyLog(PlayerTeam[interactionChooseAlly.OptionCounter]));
                }
                logger.ClearLogger();
            }
            PostBattleMenu();
        }

        //Вывод окна с информацией после сражения
        private void PostBattleMenu()
        {
            Console.Clear();

            List<string> postBattleMenu = new List<string> 
            {
                "Отдохнуть и починить снаряжение",
                "Улучшить снаряжение",
                "Продолжить путешествие"
            };
            UserOptionsInteraction interaction = new UserOptionsInteraction(postBattleMenu);

            newExp = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 50) / 2 + 200;
            newGold = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 25);

            for (int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].GetExp(newExp);
                PlayerTeam[i].GetMoney(newGold);

                generalGold += PlayerTeam[i].CharMoney;
            }

            drawer.PositionYelowColorText("Вы победили всех врагов!", 40, 5);

            drawer.PositionText($"Команда получила {newGold} золота", 5, 12);
            drawer.PositionText($"Персонажи заработали в бою {newExp} опыта", 5, 14);
            drawer.PositionText($"Текущий уровень персонажей составляет {PlayerTeam[0].CharLevel}", 5, 16);
            drawer.PositionText($"Текущее командное золото составляет {generalGold}", 5, 18);

            bool isSelected = false;
            while (!isSelected)
            {
                interaction.SelectOption(38, 25);
                switch (interaction.OptionCounter)
                {
                    case 0:
                        RecalculateTeam();
                        break;
                    case 1:
                        EnhanceGear();
                        break;
                    case 2:
                        //Продолжить путешествие
                        isSelected = true;
                        break;
                }
            }
        }
        private void RecalculateTeam()
        {
            for(int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].RecalculateStats();
            }
        }
        private void EnhanceGear()
        {
            Console.Clear();

            List<string> gearList = new List<string> { };

            RebuildTeam(ChooseAlly, PlayerTeam);
            RebuildGear(gearList, WeaponList, ArmorList);

            UserOptionsInteraction interactionChooseChar = new UserOptionsInteraction(ChooseAlly);
            UserOptionsInteraction interactionChooseGear = new UserOptionsInteraction(gearList);

            drawer.PositionText("Выберите персонажа, оружие или броню которого хотите улучшить", 35, 5);
            interactionChooseChar.SelectOption(45, 17);

            Console.Clear();
            drawer.PositionText("Выберите оружие или броню для улучшения", 35, 5);
            interactionChooseGear.SelectOption(45, 17);
        }

        //Пересборка строкового списка имен/строковой информации из списка с объектами класса персонажа  
        private void RebuildTeam(List<string> strNamesList, List<BlankCharacter> blankCharList)
        {
            while (strNamesList.Count != 0)
            {
                strNamesList.Remove(strNamesList[0]);
            }
            for (int i = 0; strNamesList.Count < blankCharList.Count; i++)
            {
                strNamesList.Add(blankCharList[i].CharInfo());
            }
        }
        private void RebuildGear(List<string> strGearList, List<BlankWeapon> weapon, List<BlankArmor> armor)
        {
            while (strGearList.Count != 0)
            {
                strGearList.Remove(strGearList[0]);
            }
            for (int i = 0; strGearList.Count < weapon.Count; i++)
            {
                strGearList.Add(weapon[i].WeaponName);
            }
            for (int i = 0; i < armor.Count; i++)
            {
                strGearList.Add(armor[i].ArmorName);
            }
        }
    }
}
