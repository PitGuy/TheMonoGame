using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameHack.Interfaces
{
    interface IGameObject
    {
        void LoadContent(ContentManager content, SpriteBatch sp);
        void Update(GameTime gameTime);
        void Update(GameTime gameTime, ContentManager content);
        void Draw();
    }
}
