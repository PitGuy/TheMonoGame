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
        public bool IsLastListElement = false;      
        public enum Status
        {
            Ok = 0,
            GameOver = 1,
        }

        public Status succesValidation(ItemObj [,]objectList, int startElX, int startElY)
        {
            int currentElX = startElX;
            int currentELY = startElY;
            ItemObj currentObj = objectList[currentElX,currentELY];

            while (!IsLastListElement)
            {
                if (currentObj != null && currentObj.rightPoint && objectList[currentElX + 1,currentELY].leftPoint &&
                    currentObj.GetType() ==  objectList[currentElX + 1, currentELY].GetType())
                {
                    currentObj = objectList[currentElX + 1, currentELY];
                    currentObj.leftPoint = false;
                }
                if (currentObj != null && currentObj.leftPoint && objectList[currentElX - 1, currentELY].rightPoint &&
                    currentObj.GetType() == objectList[currentElX - 1, currentELY].GetType())
                {
                    currentObj = objectList[currentElX - 1, currentELY];
                    currentObj.rightPoint = false;
                }
                if (currentObj != null && currentObj.upPoint && objectList[currentElX, currentELY - 1].downPoint &&
                    currentObj.GetType() == objectList[currentELY - 1, currentELY].GetType())
                {
                    currentObj = objectList[currentElX, currentELY - 1];
                    currentObj.downPoint = false;
                }
                if (currentObj != null && currentObj.downPoint && objectList[currentElX, currentELY + 1].upPoint &&
                    currentObj.GetType() == objectList[currentELY + 1, currentELY].GetType())
                {
                    currentObj = objectList[currentElX, currentELY + 1];
                    currentObj.upPoint = false;
                }
                if (currentObj != null && currentObj.rightPoint && objectList[currentElX + 1, currentELY].IsFinallyObj &&
                    currentObj.GetType() == objectList[currentElX + 1, currentELY].GetType())
                {
                    IsLastListElement = true;
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
