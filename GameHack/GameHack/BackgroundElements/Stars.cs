using GameHack.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Register;
using GameHack.Setting;

namespace GameHack.BackgroundElements
{
    class Stars : IGameObject
    {
        Texture2D texture;
        Point size;
        List<Rectangle> stars;
        Point speed;
        Point rezulition;
        Random random;
        int frequency;
        public Stars()
        {
            stars = new List<Rectangle>();
            speed = Setup.GetInstance().StartsSpeed;
            rezulition = Setup.GetInstance().Rozulition;
            size = new Point(25,25);
            random = new Random();
            frequency = Setup.GetInstance().StartsGenerateFrequency;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle start in stars)
            {
                spriteBatch.Draw(texture, start, Color.White);
            }
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(ContentPatch.STAR);
        }

        public void Update(GameTime gameTime)
        {
            List<Rectangle> startsToRemove = new List<Rectangle>();
            for (int i = 0; i < stars.Count; i++)
            {
                if (stars[i].X - speed.X < 0 || stars[i].Y + speed.Y > rezulition.Y)
                {
                    startsToRemove.Add(stars[i]);
                }
                else
                {
                    stars[i] = new Rectangle(stars[i].X - speed.X, stars[i].Y + speed.Y, stars[i].Width, stars[i].Height);
                }
            }
            foreach (Rectangle toRemove in startsToRemove)
            {
                stars.Remove(toRemove);
            }
            if (random.Next(1, 20 - frequency) == 1)
            {
                int size = 25;

                int x = random.Next(1, 10);
                if (x > 5)
                    stars.Add(new Rectangle(rezulition.X, rezulition.Y / 10 * random.Next(1, 10), size, size));
                else
                    stars.Add(new Rectangle(rezulition.X / 10 * random.Next(1, 10), 0, size, size));
            }
        }
    }
}
