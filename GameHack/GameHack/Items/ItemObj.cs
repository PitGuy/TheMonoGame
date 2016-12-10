using GameHack.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace GameHack.Items
{
    public abstract class ItemObj
    {
        protected GameTime gameTime;
        protected SpriteBatch spriteBatch;
        protected Texture2D texture;
        public Rectangle rectangle;
        public abstract Rectangle GetRectangle();
        public abstract void Draw();
        public abstract void Update(GameTime gameTime);
    }
}
