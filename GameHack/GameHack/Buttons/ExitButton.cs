using GameHack.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Abstraction;
using GameHack.Register;

namespace GameHack.Buttons
{
    class ExitButton : ButtonObject, IGameObject
    {
        Texture2D texture;
        public ExitButton() : base(new Rectangle(1450, 90, 50, 50))
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, buttonRectangle, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(ContentPatch.EXIT);
        }

        public void Update(GameTime gameTime)
        {
            if(WasCliked())
            {
                //TO-DO EXIT
            }
        }
    }
}
