using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHack.Setup
{
    public class Sizes
    {
        public int frameWidth { get; set; }
        public int frameHeight { get; set; }
        private GraphicsDevice graphicsDevice;
        public Vector2 centerOfWindow
        {
            get
            {
                return new Vector2(graphicsDevice.PresentationParameters.BackBufferWidth / 2, graphicsDevice.PresentationParameters.BackBufferHeight / 2);
            }
        }
    }
}
