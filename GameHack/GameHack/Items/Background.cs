using GameHack.Interfaces;
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
        GameTime gameTime;

        public Background(SpriteBatch sp, GameTime gt)
        {
            spriteBatch = sp;
            gameTime = gt;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager content)
        {
            backgroundTexture = content.Load<Texture2D>();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
