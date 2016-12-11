using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GameHack.Register;

namespace GameHack.Items
{
    public class SunItem : ItemObj
    {
        public SunItem(Rectangle rectangle, SpriteBatch spriteBatch)
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
            this.texture = content.Load<Texture2D>(ContentEnum.SUN);
        }
    }
}
