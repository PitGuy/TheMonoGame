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
        public void AddItem(ItemObj item)
        {
            this.items.Add(item);
        }
        public void DeleteItem(ItemObj item)
        {
            this.items.Remove(item);
        }
        public void SelectItem(int x, int y)
        {
            foreach(var item in this.items)
            {
                if (item.SelectedItem(x, y))
                {
                    bufforItem = item;
                }
            }
        }
        private void SetSizeItem()
        {
            int x = this.rectangle.X;
            int y = this.rectangle.Y;
            int width = this.rectangle.Width;
            int height = this.rectangle.Height;
            countItem = this.items.Count;

            int change_x = 10;
            int change_y = 10;

            List<ItemObj> resetItems = new List<ItemObj>();
            foreach (var item in this.items)
            {
                ItemObj it = item;
                Rectangle rec = new Rectangle(x + change_x, y + change_y, width / countItem - 2 * change_x, height - 2 * change_y);
                change_x += 10;
            }
            this.items = resetItems;
        }
        public void Draw()
        {
            SetSizeItem();
            spriteBatch.Draw(this.texture, GetPanelPosition(), Color.White);
            foreach(var item in this.items)
            {
                item.Draw();
            }

        }

        private Rectangle GetPanelPosition()
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
            throw new NotImplementedException();
        }
    }
}
