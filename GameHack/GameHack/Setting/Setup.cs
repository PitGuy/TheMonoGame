using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHack.Setting
{
    class Setup
    {
        private static Setup setup;
        private Setup() {
        }
        internal static Setup GetInstance()
        {
            if (setup == null)
                setup = new Setup();
            return setup;
        }
        #region Main
        public Point Rozulition = new Point(1600, 900);
        #endregion
        #region Stars
        public Point StartsSpeed = new Point(20, 15);
        public int StartsGenerateFrequency = 1;
        #endregion
        #region GameField
        public Point SizeGameField = new Point(10, 10);
        #endregion
    }
}
