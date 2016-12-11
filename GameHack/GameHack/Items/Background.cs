using GameHack.Interfaces;
using GameHack.Register;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace GameHack.Items
{
    public class Background : IGameObject
    {
        Texture2D backgroundTexture;
        Texture2D marsTexture;
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        ExitItem exit;
        StartItem run;

        int heightExitImage = 0;
        int widthExitImage = 0;

        int heightRunImage = 0;
        int widthRunImage = 0;

        Star starts;

        bool moveMouseOnExit = false;
        bool moveMouseOnRun = false;

        public Background(GraphicsDevice gd)
        {
            starts = new Star();
            graphicsDevice = gd;
        }

        public bool SelectedItem(Rectangle rectangle, int x, int y)
        {
            return (x >= rectangle.X && x <= (rectangle.X + rectangle.Width))
                    &&
                    y >= rectangle.Y && y <= (rectangle.Y + rectangle.Height);
        }
        public void MouseMove_Exit(MouseState mouseState)
        {
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;
            
            if (this.SelectedItem(exit.rectangle, mouseX, mouseY))
            {
                if (!moveMouseOnExit) {
                    exit.rectangle.Height +=20;
                    exit.rectangle.Width +=20;
                    moveMouseOnExit = true;
                }
            }
            else
            {
                exit.rectangle.Height = heightExitImage;
                exit.rectangle.Width = widthExitImage;
                moveMouseOnExit = false ;
            }
        }
        public void LeftMouseClick_Exit(MouseState mouseState)
        {
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (this.SelectedItem(exit.rectangle, mouseX, mouseY))
                {
                    CoreApplication.Exit();
                }
            }
        }



        public void MouseMove_Run(MouseState mouseState)
        {
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            if (this.SelectedItem(run.rectangle, mouseX, mouseY))
            {
                if (!moveMouseOnRun)
                {
                    run.rectangle.Height += 20;
                    run.rectangle.Width += 20;
                    moveMouseOnRun = true;
                }
            }
            else
            {
                run.rectangle.Height = heightExitImage;
                run.rectangle.Width = widthExitImage;
                moveMouseOnRun = false;
            }
        }
        public void LeftMouseClick_Run(MouseState mouseState)
        {
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (this.SelectedItem(run.rectangle, mouseX, mouseY))
                {
                    
                }
            }
        }



        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            starts.Draw();
            spriteBatch.Draw(marsTexture, GetMarsPosition(), Color.White);
            exit.Draw();
            run.Draw();
            spriteBatch.End();
        }

        private Rectangle GetMarsPosition()
        {
            int x = graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 2;
            int y = graphicsDevice.PresentationParameters.BackBufferHeight / 9;
            int width = graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 9;
            int height = graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 7;
            return new Rectangle(x, y, width, height);
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            backgroundTexture = content.Load<Texture2D>(ContentEnum.BACKGROUND);
            marsTexture = content.Load<Texture2D>(ContentEnum.MARS);
            starts.LoadContent(content, sp);
            spriteBatch = sp;
            exit = new ExitItem(new Rectangle(graphicsDevice.PresentationParameters.BackBufferWidth-50*3, graphicsDevice.PresentationParameters.BackBufferHeight/10, 50, 50), sp);

            run = new StartItem(new Rectangle(graphicsDevice.PresentationParameters.BackBufferWidth - 50 * 5, graphicsDevice.PresentationParameters.BackBufferHeight / 10, 50, 50), sp);

            heightExitImage = exit.rectangle.Height;
            widthExitImage = exit.rectangle.Width;

            heightRunImage = run.rectangle.Height;
            widthRunImage = run.rectangle.Width;
            exit.LoadContent(content, sp);
            run.LoadContent(content, sp);
        }

        public void Update(GameTime gameTime)
        {
            starts.Update(gameTime);
            MouseState mouseState = Mouse.GetState();
            LeftMouseClick_Exit(mouseState);
            MouseMove_Exit(mouseState);

            LeftMouseClick_Run(mouseState);
            MouseMove_Run(mouseState);
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            
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
                if (stars[i].X - Options.STARSPEED_X < -Options.STARSPEED_X)
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
            if(new Random().Next(0,10) == 0)
            {
                int size = new Random().Next(25, 25);
                int x = new Random().Next(1, 10);
                if(x > 5)
                    stars.Add(new Rectangle(1600, new Random().Next(1, 9) * 100, size, size));
                else
                    stars.Add(new Rectangle(x * new Random().Next(10, 300), 0, size, size));
            }
        }
    }
}
