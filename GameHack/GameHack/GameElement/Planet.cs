using GameHack.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Register;

namespace GameHack.GameElement
{
    class Planet : IGameObject
    {
        Texture2D texture;
        Rectangle rectangle;
        GameField gamefield; 
        public Planet()
        {
            rectangle = new Rectangle(400, 100, 800, 800);
            gamefield = new GameField();
        }
        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(ContentPatch.PLANET);
        }

        public void Update(GameTime gameTime)
        {
            gamefield.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            gamefield.Draw(spriteBatch);
        }


    }
}
