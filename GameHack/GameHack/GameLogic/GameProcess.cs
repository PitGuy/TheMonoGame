using GameHack.Items;
using GameHack.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHack.GameLogic
{
    public class GameProcess
    {
        public bool IsLastListEl = false;
        
        public enum Status
        {
            Ok = 0,
            GameOver = 1,
        }

        public Status succesValidation(ItemObj [][]objectList, int startElX, int startElY)
        {
            int currentElX = startElX;
            int currentELY = startElY;
            ItemObj currentObj = objectList[currentElX][currentELY];

            while(!IsLastListEl)
            {
                if (currentObj.rightPoint && objectList[currentElX + 1][currentELY].leftPoint)
                {
                    currentObj = objectList[currentElX + 1][currentELY]; 
                }
                if (currentObj.leftPoint && objectList[currentElX - 1][currentELY].rightPoint)
                {
                    currentObj = objectList[currentElX - 1][currentELY];
                }
                if (currentObj.upPoint && objectList[currentElX][currentELY - 1].downPoint)
                {
                    currentObj = objectList[currentElX][currentELY - 1];
                }
                if (currentObj.downPoint && objectList[currentElX][currentELY + 1].upPoint)
                {
                    currentObj = objectList[currentElX][currentELY + 1];
                }
                else
                {
                    return Status.GameOver;
                }
            }
            return Status.Ok;
        }
        
    }
}
