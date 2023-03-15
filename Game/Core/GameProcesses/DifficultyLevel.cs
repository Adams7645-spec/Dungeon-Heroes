using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class DifficultyLevel
    {
        //МНОЖИТЕЛЬ бонуса стата за сложность 
        static private double adictionalNPCHealth = 1;
        static private double adictionalNPCStrenght = 1;
        static private double adictionalNPCDefense = 1;

        //Максимальное кол-во врагов в комнате
        static private int maxEnemyAtRoom = 2;

        //МНОЖИТЕЛЬ бонуса урона за сложность 
        static private double adictionalEventDamage = 1;

        //МНОЖИТЕЛЬ бонуса за сложность 
        static private double adictionalChestGold = 1;
        static private double adictionalKillGold = 1;
        static private double adictionalKillExp = 1;

        //Имя выбранной сложности
        static private string difficultyName = "Легкий";

        public double AdictionalNPCHealth { get => adictionalNPCHealth; }
        public double AdictionalNPCStrenght { get => adictionalNPCStrenght; }
        public double AdictionalNPCDefense { get => adictionalNPCDefense; }
        public double AdictionalEventDamage { get => adictionalEventDamage; }
        public double AdictionalChestGold { get => adictionalChestGold; }
        public double AdictionalKillGold { get => adictionalKillGold; }
        public double AdictionalKillExp { get => adictionalKillExp; }
        public string DifficultyName { get => difficultyName; }
        public double MaxEnemyAtRoom { get => maxEnemyAtRoom; }

        public void SetEasyDiff()
        {
            difficultyName = "Легкий";

            adictionalNPCHealth = 1;
            adictionalNPCStrenght = 1;
            adictionalNPCDefense = 1;
            adictionalEventDamage = 1;

            adictionalChestGold = 1;
            adictionalKillGold = 1;
            adictionalKillExp = 1;

            maxEnemyAtRoom = 2;
        }
        public void SetMidDiff()
        {
            difficultyName = "Средний";

            adictionalNPCHealth = 1.5;
            adictionalNPCStrenght = 1.5;
            adictionalNPCDefense = 1.5;
            adictionalEventDamage = 1.5;

            adictionalChestGold = 1.5;
            adictionalKillGold = 1.5;
            adictionalKillExp = 1.5;

            maxEnemyAtRoom = 4;
        }
        public void SetHardDiff()
        {
            difficultyName = "Тяжелый";

            adictionalNPCHealth = 2.25;
            adictionalNPCStrenght = 2.25;
            adictionalNPCDefense = 2.25;
            adictionalEventDamage = 2.25;

            adictionalChestGold = 2.25;
            adictionalKillGold = 2.25;
            adictionalKillExp = 2.25;

            maxEnemyAtRoom = 5;
        }
    }
}
