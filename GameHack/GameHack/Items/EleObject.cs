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
    public class EleObject : ItemObj    {
        public EleObject(Texture2D texture, SpriteBatch sp, GraphicsDevice gd, int sX, int sY)
        {
            oldsizeX = sX;
            oldsizeY = sY;
            this.texture = texture;
            spriteBatch = sp;
            this.GraphicsDevice = gd;
        }
        

        public EleObject() { }
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
        public static EleObject CopyObject(EleObject obj)
        {
            Texture2D texture = default(Texture2D);
            texture = obj.Texture;
            EleObject copy = new EleObject(texture, obj.SpriteBatch, obj.graphicsDevice, obj.oldsizeX, obj.oldsizeY);
            copy.rectangle = new Rectangle(obj.rectangle.X, obj.rectangle.Y, obj.rectangle.Width, obj.rectangle.Height);
            return copy;
        }
        public static EleObject CopyObject(EleObject obj,Texture2D texture)
        {
            Texture2D _texture = default(Texture2D);
            _texture = texture;
            EleObject copy = new EleObject(_texture, obj.SpriteBatch, obj.graphicsDevice, obj.oldsizeX, obj.oldsizeY);
            copy.rectangle = new Rectangle(obj.rectangle.X, obj.rectangle.Y, obj.rectangle.Width, obj.rectangle.Height);
            return copy;
        }
        #endregion
        public void ChangeSize(int width, int height)
        {
            this.rectangle.Width = width;
            this.rectangle.Height = height;
        }
        
        public int sizeX
        {
            get { return (int)((Double)50 * ((Double)graphicsDevice.PresentationParameters.BackBufferWidth / 1600)); }
        }
        public int sizeY
        {
            get { return (int)((Double)50 * ((Double)graphicsDevice.PresentationParameters.BackBufferHeight / 900)); }
        }
        public int oldsizeX;
        public int oldsizeY;
        public override void Draw()
        {
            spriteBatch.Draw(this.texture, rectangle, new Rectangle(0, 0, 200, 200), Color.White);
        }
        public void DrawNew()
        {
            spriteBatch.Draw(this.texture, getNewRectangle(rectangle), new Rectangle(0,0, 200, 200), Color.White);
        }
        public Rectangle getNewRectangle(Rectangle oldRe)
        {
            double kofx = (double) sizeX/ (double)oldsizeX;
            double kofy = (double) sizeY/ (double)oldsizeY;
            return new Rectangle((int)((double)oldRe.X * kofx), (int)((double)oldRe.Y * kofy), (int)((double)oldRe.Width* kofx), (int)((double)oldRe.Height* kofy));
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
