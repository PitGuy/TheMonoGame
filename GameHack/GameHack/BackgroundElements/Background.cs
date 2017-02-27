using GameHack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Register;
using GameHack.Setting;

namespace GameHack.BackgroundElements
{
    class Background : IGameObject
    {
        private Texture2D texture;
        private List<IGameObject> backgroundObjects;
        private Point rezulition;

        public Background(List<IGameObject> backgroundObjects)
        {
            this.backgroundObjects = backgroundObjects;
            this.rezulition = Setup.GetInstance().Rozulition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, rezulition.X, rezulition.Y), Color.White);
            foreach(var bgObj in backgroundObjects)
            {
                bgObj.Draw(spriteBatch);
            }
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(ContentPatch.BACKGROUND);
            foreach (var bgObj in backgroundObjects)
            {
                bgObj.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var bgObj in backgroundObjects)
            {
                bgObj.Update(gameTime);
            }
        }
    }
}
