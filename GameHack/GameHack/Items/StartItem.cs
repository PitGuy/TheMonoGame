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
    public class StartItem : ItemObj
    {
        public StartItem(Rectangle rectangle, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.rectangle = rectangle;
        }
        public override void Draw()
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
            //spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

        }
        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            this.texture = content.Load<Texture2D>(ContentEnum.START);
        }
    }

}
