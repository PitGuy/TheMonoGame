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

namespace GameHack.Items
{
    public class Panel:IGameObject
    {
        GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        private Rectangle rectangle;
        private Texture2D texture;

        private List<ItemObj> items;
        private ItemObj bufforItem;
        private int countItem;
       
        public Panel(GraphicsDevice graphicsDevice)
        {
            this.items = new List<ItemObj>();
            this.graphicsDevice = graphicsDevice;
            rectangle = GetPanelPosition();
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.texture, GetPanelPosition(), Color.White);
            foreach(var item in this.items)
            {
                item.Draw();
            }
            spriteBatch.End();
        }

        public Rectangle GetPanelPosition()
        {
            int x = graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 13;
            int y = graphicsDevice.PresentationParameters.BackBufferHeight / 9;
            int width = graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 3;
            int height = graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 7;
            return new Rectangle(x, y, width, height);
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            this.spriteBatch = sp;
            this.texture = content.Load<Texture2D>(ContentEnum.PANEL);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            
        }
    }
}
