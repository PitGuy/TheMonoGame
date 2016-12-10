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

        public Background(GraphicsDevice gd)
        {
            graphicsDevice = gd;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0, graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height), Color.White);
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            backgroundTexture = content.Load<Texture2D>(ContentEnum.BACKGROUND);
            spriteBatch = sp;
        }

        public void Update(GameTime gameTime)
        {

        }
        
    }
}
