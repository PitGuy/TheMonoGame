using System;
using GameHack.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Abstraction;
using GameHack.Register;
using GameHack.GameElement;

namespace GameHack.Buttons
{
    class SunButton : ButtonObject, IGameObject
    {
        Texture2D texture;

        public SunButton() : base(new Rectangle(100, 100, 100, 100))
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, buttonRectangle, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(ContentPatch.SUN);
        }

        public void Update(GameTime gameTime)
        {
            ElementBuffer buffer = ElementBuffer.GetInstance();
            if(WasCliked() && buffer.HaveElement())
            {
                buffer.Destroy();
            }
        }
    }
}
