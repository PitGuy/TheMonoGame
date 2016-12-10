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
        protected Rectangle rectangle;
        protected ContentManager content;
        public TypeObj type;
        public StatusObj status;

        public abstract bool SelectedItem(int x, int y);
        public abstract Rectangle GetRectangle();
        public abstract void SetRectangle(Rectangle rec);
        public abstract void Draw();
        public abstract void LoadContent(ContentManager content, SpriteBatch sp);
        public abstract void Update(GameTime gameTime);
    }
    public enum StatusObj { InPanel, Move, InMap }
    public enum TypeObj { Water, Electricity, Air }
}
