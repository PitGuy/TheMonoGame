using GameHack.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Abstraction;
using GameHack.Register;
using GameHack.GameLogic;
using GameHack.GameElement;

namespace GameHack.Buttons
{
    class RunButton : ButtonObject, IGameObject
    {
        Texture2D texture;
        public RunButton() : base(new Rectangle(1350, 90, 50, 50))
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, buttonRectangle, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(ContentPatch.RUN);
        }

        public void Update(GameTime gameTime)
        {
            if (WasCliked())
            {
                GameProcess.Validate(4, new Point(0, 1), GameField.fields, "E", new Point(8, 1));
                GameProcess.Validate(4, new Point(0, 7), GameField.fields, "W", new Point(1, 0));
                GameProcess.Validate(4, new Point(0, 8), GameField.fields, "O", new Point(10, 1));
            }
        }
    }
}
