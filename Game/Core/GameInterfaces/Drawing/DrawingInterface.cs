using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class DrawingInterface
    {
        //Вывод центрированного текста
        public void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        //Вывод текста на на определенные координаты в консоли
        public void PositionText(String text, int marginLeft, int marginTop)
        {
            Console.SetCursorPosition(marginLeft, marginTop + 1);
            Console.WriteLine($@"{text}");
            Thread.Sleep(10);
        }
        public void PositionAnyColorText(String text, int marginLeft, int marginTop, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(marginLeft, marginTop + 1);
            Console.WriteLine($@"{text}");
            Thread.Sleep(10);

            Console.ResetColor();
        }

        //Вывод центрированного рисунка ASCII
        public void PrintASCIICentered(string[] asciiPicture)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                CenterText($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }

        //Вывод рисунка ASCII на определенные координаты в консоли
        public void PrintASCIIAtPosition(string[] asciiPicture, int marginLeft, int marginTop)
        {
            for (int i = 0; i < asciiPicture.Length; i++)
            {
                Console.SetCursorPosition(marginLeft, marginTop + i);
                Console.WriteLine($@"{asciiPicture[i]}");
                Thread.Sleep(10);
            }
        }

        //Вывод центрированного желтого информирующего текста вниз экрана
        public void PrintPressAnyKeyLikeText(string Text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((Console.WindowWidth - Text.Length) / 2, 30);
            Console.WriteLine(Text);
            Console.ResetColor();
            Console.ReadKey();
        }

        //Вывод информации о всех персонажах игрока
        public void PrintTeamBrief(List<BlankCharacter> TeamList, int marginLeft, int marginTop)
        {
            int increment = 0;
            for (int i = 0; i < TeamList.Count; i++)
            {
                if (i < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    PositionText($"{TeamList[i].CharInfo()}", marginLeft + increment, marginTop + 0);
                    Console.ResetColor();
                    PositionText($"Сила: {TeamList[i].TotalStrengh}", marginLeft + increment, marginTop + 1);
                    PositionText($"Защита: {TeamList[i].TotalDefense}", marginLeft + increment, marginTop + 2);
                    PositionText($"Опыт: {TeamList[i].CharExp}", marginLeft + increment, marginTop + 3);
                    PositionText($"Уровень: {TeamList[i].CharLevel}", marginLeft + increment, marginTop + 4);

                    increment = 40;
                }
                else
                {
                    if (i == 2)
                    {
                        increment = 0;
                    }
                    else
                    {
                        increment = 40;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    PositionText($"{TeamList[i].CharInfo()}", marginLeft + increment, marginTop + 6);
                    Console.ResetColor();
                    PositionText($"Сила: {TeamList[i].TotalStrengh}", marginLeft + increment, marginTop + 7);
                    PositionText($"Защита: {TeamList[i].TotalDefense}", marginLeft + increment, marginTop + 8);
                    PositionText($"Опыт: {TeamList[i].CharExp}", marginLeft + increment, marginTop + 9);
                    PositionText($"Уровень: {TeamList[i].CharLevel}", marginLeft + increment, marginTop + 10);
                }
            }
        }
        
        //Вывод короткого списка персонажей
        public void PrintShortTeamBrief(List<BlankCharacter> TeamList, int marginLeft, int marginTop)
        {
            for (int i = 0; i < TeamList.Count; i++)
            {
                PositionText($"{TeamList[i].CharInfo()}", marginLeft, marginTop + i);
            }
        }

        //Вывод информации о сложности игрового мира
        public void PrintWorldInfo(int marginLeft, int marginTop)
        {
            DifficultyLevel difficulty = new DifficultyLevel();

            PositionText($"Информация об игровом мире: ", marginLeft, marginTop);
            PositionText($"Выбранный уровень сложности: {difficulty.DifficultyName}", marginLeft, marginTop + 1);
            PositionText($"Уровень врагов: ", marginLeft, marginTop + 2);
            PositionText($"Множитель золота за сложность: {difficulty.AdictionalKillGold}", marginLeft, marginTop + 3);
            PositionText($"Множитель опыта за сложность: {difficulty.AdictionalKillExp}", marginLeft, marginTop + 4);

            //перенести в другое окно
            PositionText($"Совет", marginLeft, marginTop + 5);
        }
        public void PrintCharBrief(List<BlankCharacter> TeamList, int marginLeft, int marginTop, int selectedCharId, int OneGreenTwoRedColor)
        {
            switch (OneGreenTwoRedColor)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            PositionText($"Имя: {TeamList[selectedCharId].CharName}", marginLeft, marginTop + 0);
            Console.ResetColor();
            PositionText($"Здоровье: {TeamList[selectedCharId].TotalHealth}", marginLeft, marginTop + 1);
            PositionText($"Сила: {TeamList[selectedCharId].TotalStrengh}", marginLeft, marginTop + 2);
            PositionText($"Защита: {TeamList[selectedCharId].TotalDefense}", marginLeft, marginTop + 3);
        }
    }
}
