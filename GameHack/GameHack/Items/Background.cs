using GameHack.Interfaces;
using GameHack.Register;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHack.Items
{
    public class Background : IGameObject
    {
        Texture2D backgroundTexture;
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        Star starts;

        public Background(GraphicsDevice gd)
        {
            starts = new Star();
            graphicsDevice = gd;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            starts.Draw();
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            backgroundTexture = content.Load<Texture2D>(ContentEnum.BACKGROUND);
            starts.LoadContent(content, sp);
            spriteBatch = sp;
        }

        public void Update(GameTime gameTime)
        {
            starts.Update(gameTime);
        }
        
    }

    class Star : IGameObject
    {
        Texture2D texture;
        SpriteBatch spriteBatch;

        List<Rectangle> stars;

        public Star()
        {
            stars = new List<Rectangle>();
            stars.Add(new Rectangle(1600,50, 10, 10));
            stars.Add(new Rectangle(1800, 100, 10, 10));
            stars.Add(new Rectangle(2200, 75, 10, 10));
        }

        public void Draw()
        {
            foreach (Rectangle start in stars)
            {
                spriteBatch.Draw(texture, start, Color.White);
            }
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            texture = content.Load<Texture2D>(ContentEnum.STAR);
            spriteBatch = sp;
        }

        public void Update(GameTime gameTime)
        {
            List<Rectangle> removeStars = new List<Rectangle>();
            for (int i = 0; i < stars.Count; i++)
            {
                if (stars[i].X - 25 < -25)
                {
                    removeStars.Add(stars[i]);
                }
                else
                {
                    stars[i] = new Rectangle(stars[i].X - Options.STARSPEED_X, stars[i].Y + Options.STARSPEED_Y, stars[i].Width, stars[i].Height);
                }
            }
            foreach (Rectangle rm in removeStars)
            {
                stars.Remove(rm);
            }
            if(new Random().Next(0,50) == 0)
            {
                int size = new Random().Next(5, 20);
                stars.Add(new Rectangle(new Random().Next(1600, 2000), new Random().Next(0, 500), size, size));
            }
           // starts.Add(new Rectangle(300, 300, 20, 20));
        }
    }
}
