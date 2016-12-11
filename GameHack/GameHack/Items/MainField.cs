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
    public class MainField : IGameObject
    {
        Texture2D mainFieldFrameTexture;
        List<Rectangle> mainFieldFramesRaws;
        List<Rectangle> mainFieldFramesColumns;
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;
        const int frameCountWidth = 15;
        const int frameCountHeight = 10;
        int startIndexX;
        int startIndexY;

        int sizeOfPlaceX;
        int sizeOfPlaceY;
        public MainField(GraphicsDevice gd)
        {
            graphicsDevice = gd;

            sizeOfPlaceX = 30;
            sizeOfPlaceY = 30;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            foreach (var mainFieldFramesRaw in mainFieldFramesRaws)
            {
                spriteBatch.Draw(mainFieldFrameTexture, mainFieldFramesRaw, Color.White);
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
            startIndexX = graphicsDevice.PresentationParameters.BackBufferWidth;
            startIndexY = graphicsDevice.PresentationParameters.BackBufferHeight;
            startIndexX = startIndexX / 16 * 4 / sizeOfPlaceX * sizeOfPlaceX + sizeOfPlaceX;
            startIndexY = startIndexY / 9 * 3 / sizeOfPlaceY * sizeOfPlaceY;

            mainFieldFramesRaws = new List<Rectangle>();
            mainFieldFramesColumns = new List<Rectangle>();
            int startIndexXCopy = startIndexX;
            int startIndexYCopy = startIndexY;

            for (int i = 0; i < frameCountHeight; i++)
            {
                for (int j = 0; j < frameCountWidth; j++)
                {
                    mainFieldFramesRaws.Add(new Rectangle(startIndexXCopy, startIndexYCopy, sizeOfPlaceX, sizeOfPlaceY));
                    startIndexXCopy += sizeOfPlaceX;
                }
                startIndexXCopy = startIndexX;
                startIndexYCopy += sizeOfPlaceY;
            }

            sizeOfPlaceX = (int)((Double)30 * ((Double)graphicsDevice.PresentationParameters.BackBufferWidth / 1600));
            sizeOfPlaceY = (int)((Double)30 * ((Double)graphicsDevice.PresentationParameters.BackBufferHeight / 900));
        }
    }
}
