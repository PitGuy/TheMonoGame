using GameHack.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameHack.GameElement
{
    class Item
    {
        public Rectangle rectangle;
        private Texture2D texture;
        public String resourceType;
        public String resourceType2;
        public Point ElementType;
        public int turn = 1;
        
        public Item(Point etype, String resourceType, Texture2D texture, String resourceType2 = null)
        {
            ElementType = etype;
            this.resourceType = resourceType;
            this.resourceType2 = resourceType2;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, new Rectangle(0,turn * 200, 200, 200), Color.White);
        }
    }
}
