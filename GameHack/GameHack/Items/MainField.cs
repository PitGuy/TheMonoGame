using GameHack.Interfaces;
using GameHack.Register;
using GameHack.Setup;
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
    public class MainField : IGameObject
    {
        Texture2D mainFieldFrameTexture;
        List<Rectangle> mainFieldFramesRaws;
        List<Rectangle> mainFieldFramesColumns;
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;
        const int frameCountWidth = 16;
        const int frameCountHeight = 8;
        int centerX;
        int centerY;

        Sizes size = new Sizes();
        public MainField(GraphicsDevice gd)
        {
            graphicsDevice = gd;
            size.frameHeight = 50;
            size.frameWidth = 50;
            centerX = graphicsDevice.PresentationParameters.BackBufferWidth;
            centerY = graphicsDevice.PresentationParameters.BackBufferHeight;
            centerX /= 2;
            centerY /= 2;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            foreach (var mainFieldFramesRaw in mainFieldFramesRaws)
            {
                //spriteBatch.Draw(mainFieldFrameTexture, mainFieldFramesRaw, Color.White);
            }
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            mainFieldFrameTexture = content.Load<Texture2D>(ContentEnum.MAINFIELDOBJ);
            spriteBatch = sp;
        }
        public void Update(GameTime gameTime)
        {
            mainFieldFramesRaws = new List<Rectangle>();
            mainFieldFramesColumns = new List<Rectangle>();
            int startIndexX = centerX - ((frameCountWidth / 2) * 50);
            int startIndexY = centerY - ((frameCountHeight / 2) * 50);
            int startIndexCopy = startIndexX;

            for (int i = 0; i < frameCountHeight; i++)
            {
                for (int j = 0; j < frameCountWidth; j++)
                {
                    mainFieldFramesRaws.Add(new Rectangle(startIndexX, startIndexY, size.frameWidth, size.frameHeight));
                    startIndexX += 50;
                }
                startIndexX = startIndexCopy;
                startIndexY += 50;
            }
        }
    }
}
