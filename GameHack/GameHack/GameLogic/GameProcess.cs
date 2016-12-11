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
        public enum Status
        {
            Ok = 0,
            GameOver = 1
        }

        public Status succesValidation(ItemObj prevObject, ItemObj currentObject)
        {
            if (currentObject.leftPoint && prevObject.rightPoint)
                return Status.Ok;
            else if (currentObject.rightPoint && prevObject.leftPoint)
                return Status.Ok;
            else if (currentObject.upPoint && prevObject.downPoint)
                return Status.Ok;
            else if (currentObject.downPoint && prevObject.upPoint)
                return Status.Ok;

            return Status.GameOver;
        }
    }
}
