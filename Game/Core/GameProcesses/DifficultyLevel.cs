﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class DifficultyLevel
    {
        //МНОЖИТЕЛЬ бонуса стата за сложность 
        private double adictionalNPCHealth = 1;
        private double adictionalNPCStrenght = 1;
        private double adictionalNPCDefense = 1;

        //МНОЖИТЕЛЬ бонуса урона за сложность 
        private double adictionalEventDamage = 1;

        //МНОЖИТЕЛЬ бонуса за сложность 
        private double adictionalChestGold = 1;
        private double adictionalKillGold = 1;
        private double adictionalKillExp = 1;

        //Имя выбранной сложности
        private string difficultyName = "Легкая";

        public double AdictionalNPCHealth { get => adictionalNPCHealth; }
        public double AdictionalNPCStrenght { get => adictionalNPCStrenght; }
        public double AdictionalNPCDefense { get => adictionalNPCDefense; }
        public double AdictionalEventDamage { get => adictionalEventDamage; }
        public double AdictionalChestGold { get => adictionalChestGold; }
        public double AdictionalKillGold { get => adictionalKillGold; }
        public double AdictionalKillExp { get => adictionalKillExp; }
        public string DifficultyName { get => difficultyName; }

        public void SetEasyDiff()
        {
            difficultyName = "Легкая";

            adictionalNPCHealth = 1;
            adictionalNPCStrenght = 1;
            adictionalNPCDefense = 1;
            adictionalEventDamage = 1;
            adictionalChestGold = 1;
            adictionalKillGold = 1;
            adictionalKillExp = 1;
        }
        public void SetMidDiff()
        {
            difficultyName = "Средняя";

            adictionalNPCHealth = 1.5;
            adictionalNPCStrenght = 1.5;
            adictionalNPCDefense = 1.5;
            adictionalEventDamage = 1.5;
            adictionalChestGold = 1.5;
            adictionalKillGold = 1.5;
            adictionalKillExp = 1.5;
        }
        public void SetHardDiff()
        {
            difficultyName = "Тяжелая";

            adictionalNPCHealth = 2.25;
            adictionalNPCStrenght = 2.25;
            adictionalNPCDefense = 2.25;
            adictionalEventDamage = 2.25;
            adictionalChestGold = 2.25;
            adictionalKillGold = 2.25;
            adictionalKillExp = 2.25;
        }
    }
}