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
        static World mainWorld;
        static Player mainPlayer;
        static BlankDungeon currentDungeon;

        //Общее золото команды
        int generalGold;
        static string[,] grid;

        //Указать корневую папку с локациями
        static string baseLevelDir = @"C:\Users\aspin\source\repos\Dungeon Heroes\Game\Dungeon\LevelDungeon\";
        static string levelName;
        static string levelPath;

        int newGold;
        int newExp;

        List<BlankCharacter> PlayerTeam = new List<BlankCharacter> { };
        List<BlankWeapon> WeaponList = new List<BlankWeapon> { };
        List<BlankArmor> ArmorList = new List<BlankArmor> { };
        List<string> ChooseAlly = new List<string> { };
        public void Game()
        {
            ShowGameLore();
            CreatePlayerTeam();
            ShowBeginningScreen();
            StartAdventure();
        }

        //основной метод
        private void StartAdventure()
        {
            //Реализовать выбор уровня при завершении путешествия (выхода с предыдущей локации)
            List<string> selectDungeon = new List<string> 
            {
                "Тоскливое логово (легко)",
                "Подземелья Призрачного Ворона (средне)",
                "Лабиринт скорби (тяжело)"
            };
            UserOptionsInteraction selectDungeonOption = new UserOptionsInteraction(selectDungeon);

            Console.Clear();

            drawer.PositionAnyColorText("Выберите подземелье:", 35, 5, ConsoleColor.Yellow);
            selectDungeonOption.SelectOption(30, 10);
            switch (selectDungeonOption.OptionCounter)
            {
                case 0:
                    currentDungeon = new EasyDungeon();
                    levelName = currentDungeon.LevelName;
                    break;
                case 1:
                    currentDungeon = new MediumDungeon();
                    levelName = currentDungeon.LevelName;
                    break;
                case 2:
                    currentDungeon = new HardDungeon();
                    levelName = currentDungeon.LevelName;
                    break;
            }

            levelPath = baseLevelDir + levelName;
            grid = LevelParser.ParseLevel(levelPath);

            mainWorld = new World(grid, currentDungeon);
            mainPlayer = new Player(currentDungeon.PlayerPosX, currentDungeon.PlayerPosY);
            mainWorld.GeneratePointOfInterest();

            Console.Clear();

            UpdateAllFrame();

            while (true)
            {
                DrawActiveFrame();
                HandlePlayerInput();
            }
        }

        //Полное обновление кадра
        private void UpdateAllFrame()
        {
            Console.Clear();

            string[] teamInfoFrame = new string[]
            {
                "┌───────────────────────────────┐",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "└───────────────────────────────┘",
            };
            string[] miscInfoFrame = new string[]
            {
                "┌───────────────────────────────┐",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "└───────────────────────────────┘",
            };
            string[] controlInfoFrame = new string[]
            {
                "┌───────────────────────────────┐",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "│                               │",
                "└───────────────────────────────┘",
            };

            drawer.PrintASCIIAtPosition(teamInfoFrame, 64, 0);
            drawer.PrintASCIIAtPosition(miscInfoFrame, 64, 11);
            drawer.PrintASCIIAtPosition(controlInfoFrame, 64, 19);

            drawer.PositionAnyColorText("Ваша команда:", 67, 1, ConsoleColor.Green);
            drawer.PrintShortTeamBrief(PlayerTeam, 67, 2);

            drawer.PositionText("Ваше золото: ", 67, 12);
            drawer.PositionAnyColorText($"{generalGold}", 80, 12, ConsoleColor.Yellow);

            drawer.PositionText("Ваш уровень: ", 67, 13);
            drawer.PositionAnyColorText($"{PlayerTeam[0].CharLevel}", 80, 13, ConsoleColor.Blue);

            drawer.PositionText("Управление: ", 67, 20);
            drawer.PositionText("WASD - передвижение", 67, 21);
            drawer.PositionText("Enter - взаимодействие", 67, 22);

            mainWorld.DrawAtPosition(0, 0, ConsoleColor.DarkYellow);
            mainWorld.PrintPointOfInterest();
            mainPlayer.Draw();
        }

        //Отрисовка динамических элементов интерфейса
        private void DrawActiveFrame()
        {
            //отрисовка персонажей и всего того, что требует частого обновления экрана
            mainPlayer.Draw();
        }

        //Чтение клавиш пользователя
        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.W:
                    if (mainWorld.IsPositionWalkable(mainPlayer.PlayerX, mainPlayer.PlayerY - 1))
                    {
                        mainPlayer.PlayerOldX = mainPlayer.PlayerX;
                        mainPlayer.PlayerOldY = mainPlayer.PlayerY;
                        mainPlayer.PlayerMarker = "▲";
                        mainPlayer.PlayerY -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (mainWorld.IsPositionWalkable(mainPlayer.PlayerX, mainPlayer.PlayerY + 1))
                    {
                        mainPlayer.PlayerOldX = mainPlayer.PlayerX;
                        mainPlayer.PlayerOldY = mainPlayer.PlayerY;
                        mainPlayer.PlayerMarker = "▼";
                        mainPlayer.PlayerY += 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (mainWorld.IsPositionWalkable(mainPlayer.PlayerX - 1, mainPlayer.PlayerY))
                    {
                        mainPlayer.PlayerOldX = mainPlayer.PlayerX;
                        mainPlayer.PlayerOldY = mainPlayer.PlayerY;
                        mainPlayer.PlayerMarker = "◄";
                        mainPlayer.PlayerX -= 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (mainWorld.IsPositionWalkable(mainPlayer.PlayerX + 1, mainPlayer.PlayerY))
                    {
                        mainPlayer.PlayerOldX = mainPlayer.PlayerX;
                        mainPlayer.PlayerOldY = mainPlayer.PlayerY;
                        mainPlayer.PlayerMarker = "►";
                        mainPlayer.PlayerX += 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    InteractWithPosition();
                    break;
            }
        }

        //Метод взаимодействия с точками интереса
        private void InteractWithPosition()
        {
            //реализовать взаимодействие с точкой интереса 
            //сравнивать координаты с координатами точек из mainWorld.pointList
            if (mainPlayer.PlayerX == currentDungeon.ExitPosX && mainPlayer.PlayerY == currentDungeon.ExitPosY)
            {
                StartAdventure();
            }
            if(mainPlayer.PlayerX == currentDungeon.BossPosX && mainPlayer.PlayerY == currentDungeon.BossPosY && currentDungeon.BossIsActive)
            {
                FightWithBossEvent();
            }
            for (int i = 0; i < mainWorld.pointList.Count; i++)
            {
                if (mainPlayer.PlayerX == mainWorld.pointList[i].PointPosX && mainPlayer.PlayerY == mainWorld.pointList[i].PointPosY)
                {
                    RandomizeEvent();
                    mainWorld.pointList.Remove(mainWorld.pointList[i]);
                }
            }
        }

        //Вызов случайного ивента
        private void RandomizeEvent()
        {
            int Event = random.Next(4);

            switch (Event)
            {
                case 0:
                    FightWithEnemyEvent();
                    break;
                case 1:
                    FoundTreasureEvent();
                    break;
                case 2:
                    FoundNothingEvent();
                    break;
                case 3:
                    PlayerTrapedEvent();
                    break;
            }
        }

        //окно с вводящей в курс дела информацией 
        private void ShowGameLore()
        {
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

        //Создаем команду из доступных персонажей 
        private void CreatePlayerTeam()
        {

            Console.Clear();
            List<string> options = new List<string> { "Выбрать Assassin", "Выбрать Gunslinger",
                                                      "Выбрать Paladin", "Выбрать Priest",
                                                      "Выбрать ShieldBearer"};
            UserOptionsInteraction interaction = new UserOptionsInteraction(options);

            for (int i = 0; PlayerTeam.Count < 4; i++)
            {
                drawer.PositionAnyColorText($"Персонаж №{i + 1}", (Console.WindowWidth - 11) / 2, 3, ConsoleColor.Cyan);
                drawer.PositionAnyColorText($"Выберите желаемого персонажа:", (Console.WindowWidth - 29) / 2, 4, ConsoleColor.Cyan);

                interaction.SelectOption(41, 12);

                switch (interaction.OptionCounter)
                {
                    case 0:
                        BlankCharacter assassin = new Assassin
                            (random.Next(450, 550), random.Next(110, 130), random.Next(60, 70));
                        CreatePlayerGear(assassin);
                        PlayerTeam.Add(assassin);
                        break;
                    case 1:
                        BlankCharacter gunslinger = new Gunslinger
                            (random.Next(550, 650), random.Next(80, 90), random.Next(90, 100));
                        CreatePlayerGear(gunslinger);
                        PlayerTeam.Add(gunslinger);
                        break;
                    case 2:
                        BlankCharacter Paladin = new Paladin
                            (random.Next(800, 900), random.Next(75, 100), random.Next(120, 140));
                        CreatePlayerGear(Paladin);
                        PlayerTeam.Add(Paladin);
                        break;
                    case 3:
                        BlankCharacter Priest = new Priest
                            (random.Next(500, 600), random.Next(50, 65), random.Next(40, 50));
                        CreatePlayerGear(Priest);
                        PlayerTeam.Add(Priest);
                        break;
                    case 4:
                        BlankCharacter ShieldBearer = new ShieldBearer
                            (random.Next(1000, 1100), random.Next(40, 50), random.Next(130, 150));
                        CreatePlayerGear(ShieldBearer);
                        PlayerTeam.Add(ShieldBearer);
                        break;
                }

                drawer.PositionText($"{i + 1}){PlayerTeam[i].CharInfo()}", 5, 10 + i);
            }
            drawer.PrintPressAnyKeyLikeText("Персонажи выбраны! Нажмите, чтобы продолжить...");
        }

        //Добавляем персонажу стартовый набор вещей
        private void CreatePlayerGear(BlankCharacter character)
        {
            BlankWeapon baseWeapon = new RustyKnife(character.CharName);
            BlankArmor baseArmor = new LetherArmor(character.CharName);

            character.GetNewWeapon(baseWeapon);
            character.GetNewArmor(baseArmor);

            WeaponList.Add(baseWeapon);
            ArmorList.Add(baseArmor);
        }

        //Окно начала приключения
        private void ShowBeginningScreen()
        {
            Console.Clear();
            drawer.PrintTeamBrief(PlayerTeam, 20, 3);
            drawer.PrintWorldInfo(20, 18);
            drawer.PrintPressAnyKeyLikeText("Нажмите, чтобы начать приключение!");
        }

        //Событие сражения с врагом/вражеской командой
        private void FightWithEnemyEvent()
        {
            Logger logger = new Logger();

            List<string> ChooseEnemy = new List<string> { };
            List<string> ChooseAction = new List<string> { "Атака", "Способность", "Побег!" };

            //Заполнение команды противников 
            List<BlankCharacter> EnemyTeam = new List<BlankCharacter> { };

            while (EnemyTeam.Count < difficulty.MaxEnemyAtRoom)
            {
                int RandEnemy = random.Next(4);
                switch (RandEnemy)
                {
                    case 0:
                        BlankCharacter goblin = new Goblin(
                            Convert.ToInt32(random.Next(400, 500) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(60, 70) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(100, 110) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(goblin);
                        break;
                    case 1:
                        BlankCharacter rat = new Rat(
                            Convert.ToInt32(random.Next(150, 225) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(25, 30) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(10, 20) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(rat);
                        break;
                    case 2:
                        BlankCharacter skeleton = new Skeleton(
                            Convert.ToInt32(random.Next(325, 400) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(40, 60) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(30, 50) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(skeleton);
                        break;
                    case 3:
                        BlankCharacter thief = new Thief(
                            Convert.ToInt32(random.Next(425, 500) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(80, 95) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(20, 30) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(thief);
                        break;
                }
            }

            drawer.PrintFightFrame(28, 12, ConsoleColor.DarkRed, ConsoleColor.DarkRed);

            Console.Clear();

            //Механика сражения
            while (EnemyTeam.Count != 0)
            {
                if (PlayerTeam.Count == 0)
                {
                    PlayerDied();
                }

                RebuildTeam(ChooseEnemy, EnemyTeam);
                RebuildTeam(ChooseAlly, PlayerTeam);

                Console.Clear();

                //Экземпляры класса интерактивного выбора опций 
                UserOptionsInteraction interactionChooseAlly = new UserOptionsInteraction(ChooseAlly);
                UserOptionsInteraction interactionChooseEnemy = new UserOptionsInteraction(ChooseEnemy);

                //Создаем список для выбора персонажа при помощи опций
                drawer.PositionAnyColorText("Выберите вашего бойца: ", 5 , 3, ConsoleColor.Green);
                interactionChooseAlly.SelectOption(10, 5);
                
                drawer.PositionAnyColorText("Начать сражение с противником:", 65, 3, ConsoleColor.Red);
                interactionChooseEnemy.SelectOption(60, 5);
                
                //Цикл боя до момента смерти союзника/противника
                while (true)
                {
                    Console.Clear();
                    drawer.PrintASCIIAtPosition(PlayerTeam[interactionChooseAlly.OptionCounter].charAscii, 5, 14, ConsoleColor.Green, 0);
                    drawer.PrintASCIIAtPosition(EnemyTeam[interactionChooseEnemy.OptionCounter].charAscii, 70, 14, ConsoleColor.DarkRed, 0);

                    logger.PrintBattleLog(37, 10);

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
                            if (random.Next(0, 100) > 80)
                            {
                                drawer.PrintPressAnyKeyLikeText("Вам удалось сбежать!");
                                Console.Clear();
                                UpdateAllFrame();
                                return;
                            }
                            else
                            {
                                drawer.PrintPressAnyKeyLikeText("Побег провалился!");
                            }
                            break;
                    }

                    Thread.Sleep(25);

                    if (EnemyTeam[interactionChooseEnemy.OptionCounter].IsDead())
                    {
                        drawer.PositionAnyColorText($"{PlayerTeam[interactionChooseAlly.OptionCounter].CharInfo()} победил!", 33, 25, ConsoleColor.Green);
                        drawer.PrintPressAnyKeyLikeText($"{EnemyTeam[interactionChooseEnemy.OptionCounter].CharInfo()} повержен!");
                        EnemyTeam.Remove(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                        break;
                    }

                    EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemy(PlayerTeam[interactionChooseAlly.OptionCounter]);
                    logger.AddNewLog(EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemyLog(PlayerTeam[interactionChooseAlly.OptionCounter]));
                }
                logger.ClearLogger();
            }
            newExp = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 50) / 2 + 200;
            newGold = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 25);
            generalGold += newGold * PlayerTeam.Count;
            for (int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].GetExp(newExp);
                PlayerTeam[i].GetNewLevel();
            }
            PostBattleMenu();
        }
        private void FightWithBossEvent()
        {
            Logger logger = new Logger();

            List<string> ChooseEnemy = new List<string> { };
            List<string> ChooseAction = new List<string> { "Атака", "Способность", "Побег!" };

            //Заполнение команды противников 
            List<BlankCharacter> EnemyTeam = new List<BlankCharacter> { };

            while (EnemyTeam.Count < 1)
            {
                int RandBoss = random.Next(3);
                switch (RandBoss)
                {
                    case 0:
                        BlankCharacter demon = new BossDemon(
                            Convert.ToInt32(random.Next(1500, 1650) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(70, 90) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(50, 100) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(demon);
                        break;
                    case 1:
                        BlankCharacter dragon = new BossDragon(
                            Convert.ToInt32(random.Next(1150, 1300) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(150, 175) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(100, 110) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(dragon);
                        break;
                    case 2:
                        BlankCharacter giant = new BossUnicorn(
                            Convert.ToInt32(random.Next(1800, 2000) * difficulty.AdictionalNPCHealth),
                            Convert.ToInt32(random.Next(50, 65) * difficulty.AdictionalNPCStrenght),
                            Convert.ToInt32(random.Next(100, 110) * difficulty.AdictionalNPCDefense));
                        EnemyTeam.Add(giant);
                        break;
                }
            }

            drawer.PrintBossFrame(28, 12, ConsoleColor.DarkRed, ConsoleColor.DarkRed);

            Console.Clear();

            //Механика сражения
            while (EnemyTeam.Count != 0)
            {
                if (PlayerTeam.Count == 0)
                {
                    PlayerDied();
                }

                RebuildTeam(ChooseEnemy, EnemyTeam);
                RebuildTeam(ChooseAlly, PlayerTeam);

                Console.Clear();

                //Экземпляры класса интерактивного выбора опций 
                UserOptionsInteraction interactionChooseAlly = new UserOptionsInteraction(ChooseAlly);
                UserOptionsInteraction interactionChooseEnemy = new UserOptionsInteraction(ChooseEnemy);

                //Создаем список для выбора персонажа при помощи опций
                drawer.PositionAnyColorText("Выберите вашего бойца: ", 5, 3, ConsoleColor.Green);
                interactionChooseAlly.SelectOption(10, 5);

                drawer.PositionAnyColorText("Начать сражение с противником:", 65, 3, ConsoleColor.Red);
                interactionChooseEnemy.SelectOption(60, 5);

                //Цикл боя до момента смерти союзника/противника
                while (true)
                {
                    Console.Clear();
                    drawer.PrintASCIIAtPosition(PlayerTeam[interactionChooseAlly.OptionCounter].charAscii, 5, 14, ConsoleColor.Green, 0);
                    drawer.PrintASCIIAtPosition(EnemyTeam[interactionChooseEnemy.OptionCounter].charAscii, 70, 14, ConsoleColor.DarkRed, 0);

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
                            if (random.Next(0, 100) > 80)
                            {
                                drawer.PrintPressAnyKeyLikeText("Вам удалось сбежать!");
                                Console.Clear();
                                UpdateAllFrame();
                                return;
                            }
                            else
                            {
                                drawer.PrintPressAnyKeyLikeText("Побег провалился!");
                            }
                            break;
                    }

                    Thread.Sleep(25);

                    if (EnemyTeam[interactionChooseEnemy.OptionCounter].IsDead())
                    {
                        drawer.PositionAnyColorText($"{PlayerTeam[interactionChooseAlly.OptionCounter].CharInfo()} победил!", 33, 25, ConsoleColor.Green);
                        drawer.PrintPressAnyKeyLikeText($"{EnemyTeam[interactionChooseEnemy.OptionCounter].CharInfo()} повержен!");
                        EnemyTeam.Remove(EnemyTeam[interactionChooseEnemy.OptionCounter]);
                        break;
                    }

                    EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemy(PlayerTeam[interactionChooseAlly.OptionCounter]);
                    logger.AddNewLog(EnemyTeam[interactionChooseEnemy.OptionCounter].HitEnemyLog(PlayerTeam[interactionChooseAlly.OptionCounter]));
                }
                logger.ClearLogger();
            }

            newExp = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 50) / 2 + 200;
            newGold = Convert.ToInt32(difficulty.AdictionalKillExp * difficulty.MaxEnemyAtRoom * 25);
            generalGold += newGold * PlayerTeam.Count;
            for (int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].GetExp(newExp);
                PlayerTeam[i].GetNewLevel();
            }

            PostBattleMenu();
        }
        private void PlayerDied()
        {
            Console.Clear();
            drawer.PrintDeadFrame(14, 12, ConsoleColor.DarkRed, ConsoleColor.DarkRed, ConsoleColor.Red);
            menu.ShowMainMenuScreen();
        }

        //Событие появления сокровища
        private void FoundTreasureEvent()
        {
            //Вывести окно с информацией об ивенте - Вы нашли сокровище! Добавлено золота:
            newGold = random.Next(50, 250);
            generalGold += newGold;
            drawer.PrintGoldFrame(28, 12, ConsoleColor.DarkYellow, ConsoleColor.DarkYellow);
            UpdateAllFrame();
        }

        //Событие попадания в ловушку
        private void PlayerTrapedEvent() 
        {
            //Вывести окно с информацией об ивенте - Вы попали в ловушку! Здоровье персонажей уменьшено на 25%
            for (int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].TakeDamage(Convert.ToInt32(PlayerTeam[i].TotalHealth * 0.15));
            }
            drawer.PrintTrapFrame(28, 12, ConsoleColor.DarkMagenta, ConsoleColor.Magenta);
            UpdateAllFrame();
        }

        //Пустое событие
        private void FoundNothingEvent()
        {
            //Вывести окно с информацией об ивенте - Вы ничего здесь не нашли!
            drawer.PrintNothingFrame(24, 12, ConsoleColor.White, ConsoleColor.White);
            UpdateAllFrame();
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

            drawer.PositionAnyColorText("Вы победили всех врагов!", 40, 5, ConsoleColor.Yellow);

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
                        Console.Clear();
                        UpdateAllFrame();
                        break;
                }
            }
        }
        
        //Пересчет статов команды
        private void RecalculateTeam()
        {
            for(int i = 0; i < PlayerTeam.Count; i++)
            {
                PlayerTeam[i].RecalculateStats();
            }
        }

        //Прокачка снаряжения
        private void EnhanceGear()
        {
            Console.Clear();

            List<string> strArmorList = new List<string> { };
            List<string> strWeaponList = new List<string> { };

            List<string> option = new List<string> { "Прокачка оружия", "Прокачка брони" };
            List<string> weaponBonusList = new List<string> { "Прокачать базовую силу", "Прокачать бонус силы" };
            List<string> armorBonusList = new List<string> { "Прокачать базовое здоровье", "Прокачать базовую силу", "Прокачать базовую защиту" };

            RebuildTeam(ChooseAlly, PlayerTeam);
            RebuildGear(strArmorList, strWeaponList, WeaponList, ArmorList);

            UserOptionsInteraction interactionChooseOption = new UserOptionsInteraction(option);

            UserOptionsInteraction interactionChooseArmor = new UserOptionsInteraction(strArmorList);
            UserOptionsInteraction interactionChooseWeapon = new UserOptionsInteraction(strWeaponList);

            UserOptionsInteraction interactionChooseArmorBonus = new UserOptionsInteraction(armorBonusList);
            UserOptionsInteraction interactionChooseWeaponBonus = new UserOptionsInteraction(weaponBonusList);

            Console.Clear();
            drawer.PositionText("Выберите оружие или броню для улучшения", 35, 2);

            interactionChooseOption.SelectOption(10, 5);
            switch (interactionChooseOption.OptionCounter)
            {
                case 0:
                    interactionChooseWeapon.SelectOption(40, 5);
                    interactionChooseWeaponBonus.SelectOption(70, 5);
                    WeaponList[interactionChooseWeapon.OptionCounter].Upgrade(interactionChooseWeaponBonus.OptionCounter);
                    generalGold -= 50;
                    drawer.PositionAnyColorText($"Оружие {strWeaponList[interactionChooseWeapon.OptionCounter]} усилено!", 35, 15, ConsoleColor.Green);
                    break;
                case 1:
                    interactionChooseArmor.SelectOption(40, 5);
                    interactionChooseArmorBonus.SelectOption(70, 5);
                    ArmorList[interactionChooseArmor.OptionCounter].Upgrade(interactionChooseArmorBonus.OptionCounter);
                    generalGold -= 50;
                    drawer.PositionAnyColorText($"Броня {strArmorList[interactionChooseArmor.OptionCounter]} усилено!", 35, 15, ConsoleColor.Green);
                    break;
            }
        }

        //Пересборка строкового списка имен/строковой информации из списка с объектами класса персонажа/оружия/брони
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
        private void RebuildGear(List<string> strArmorList, List<string> strWeaponList, List<BlankWeapon> weapon, List<BlankArmor> armor)
        {
            while (strArmorList.Count != 0)
            {
                strArmorList.Remove(strArmorList[0]);
            }
            for (int i = 0; i < armor.Count; i++)
            {
                strArmorList.Add(armor[i].ArmorName);
            }

            while (strWeaponList.Count != 0)
            {
                strWeaponList.Remove(strWeaponList[0]);
            }
            for (int i = 0; strWeaponList.Count < weapon.Count; i++)
            {
                strWeaponList.Add(weapon[i].WeaponName);
            }
        }
    }
}
