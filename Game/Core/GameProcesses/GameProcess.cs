﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class GameProcess
    {
        MainMenuInterface menu = new MainMenuInterface();
        public void Game()
        {
            Console.Clear();

            Console.WriteLine("Игра началась! Это плейсхолдер");

            Console.ReadKey();

            menu.ShowMainMenuScreen();
        }

        //BlankCharacter gunslinger = new Gunslinger
        //    (random.Next(650, 750), random.Next(60, 80), random.Next(100, 120));
        //BlankCharacter assassin = new Assassin
        //    (random.Next(450, 550), random.Next(110, 130), random.Next(100, 120));

        //BlankArmor defaultArmor = new TestArmor(40, 10, 30);
        //BlankWeapon defaultWeapon = new BlankWeapon(50, 30, "Test");

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