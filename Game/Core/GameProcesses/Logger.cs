using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Logger
    {
        DrawingInterface drawer = new DrawingInterface();

        //Реализовать передачу записей в массив с последующим выводом на экран 
        List<string> battleLog = new List<string> { };

        public void AddNewLog(string logMessage)
        {
            battleLog.Add(logMessage);
        }
        public void PrintBattleLog(int marginLeft, int marginTop)
        {
            for(int i = 0; i < battleLog.Count; i++)
            {
                drawer.PositionText(battleLog[i], marginLeft, marginTop + i);
            }
        }
        public void ClearLogger()
        {
            for (int i = battleLog.Count; battleLog.Count > 0; i--)
            {
                battleLog.Remove(battleLog[i - 1]);
            }
        }
    }
}
