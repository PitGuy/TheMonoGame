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
    public class Panel : IGameObject
    {
        GraphicsDevice graphicsDevice;
        ContentManager content;
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
            foreach (var item in this.items)
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

            int x_n = 0;
            int y_n = 0;
            int width_n = 0;
            int height_n = 0;
            int indexItem = 1;

            List<ItemObj> resetItems = new List<ItemObj>();
            foreach (var item in this.items)
            {
                ItemObj it = item;
                x_n =  x + change_x;
                y_n =  y + change_y + height_n;
                if (width_n == 0) width_n = width - change_x;
                if (height_n == 0) height_n = height / countItem - change_y;

                Rectangle rec = new Rectangle(x_n, y_n, width_n, height_n);
                indexItem++;
                it.SetRectangle(rec);
                resetItems.Add(it);
            }
            this.items = resetItems;
        }
        public void Draw()
        {
            SetSizeItem();
            spriteBatch.Begin();
            spriteBatch.Draw(this.texture, GetPanelPosition(), Color.White);
            rectangle = GetPanelPosition();
            spriteBatch.End();
            foreach (var item in this.items)
            {
                item.LoadContent(content, spriteBatch);
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
            this.content = content;
            this.spriteBatch = sp;
            this.texture = content.Load<Texture2D>(ContentEnum.PANEL);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
