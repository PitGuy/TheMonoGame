using GameHack.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GameHack.Items
{
    public class WaterObject : ItemObj    {
        public WaterObject(Texture2D texture, SpriteBatch sp)
        {
            this.texture = texture;
            spriteBatch = sp;
        }
        public WaterObject() { }
        public Rectangle RectanglePr
        {
            get { return this.rectangle; }
            set { rectangle = value; }
        }
        public void ChangePosition(int x, int y)
        {
            this.rectangle.X = x;
            this.rectangle.Y = y;
        }
        #region[Copy]
        public static WaterObject CopyObject(WaterObject obj)
        {
            Texture2D texture = default(Texture2D);
            texture = obj.Texture;
            WaterObject copy = new WaterObject(texture, obj.SpriteBatch);
            copy.rectangle = new Rectangle(obj.rectangle.X, obj.rectangle.Y, obj.rectangle.Width, obj.rectangle.Height);
            return copy;
        }
        public static WaterObject CopyObject(WaterObject obj,Texture2D texture)
        {
            Texture2D _texture = default(Texture2D);
            _texture = texture;
            WaterObject copy = new WaterObject(_texture, obj.SpriteBatch);
            copy.rectangle = new Rectangle(obj.rectangle.X, obj.rectangle.Y, obj.rectangle.Width, obj.rectangle.Height);
            return copy;
        }
        #endregion
        public void ChangeSize(int width, int height)
        {
            this.rectangle.Width = width;
            this.rectangle.Height = height;
        }
        

        public override void Draw()
        {
            spriteBatch.Draw(this.texture, rectangle, Color.White);
        }
        

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
