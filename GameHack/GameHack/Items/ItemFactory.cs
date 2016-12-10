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
using Windows.Devices.Input;

namespace GameHack.Items
{
    public class ItemFactory : IGameObject
    {
        Panel panel;
        Rectangle grid;

        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        Texture2D waterTexture;
        Texture2D waterTextureAng;
        Texture2D elecTexture;
        Texture2D elecTextureAng;
        Texture2D oxyTexture;
        Texture2D oxyTextureAng;

        List<ItemObj> waterItems;
        List<ItemObj> elecItems;
        List<ItemObj> oxyItems;
        List<ItemObj> readyItem;
        ItemObj buffer;

        public ItemFactory(Panel pn, GraphicsDevice gd, Rectangle grd)
        {
            waterItems = new List<ItemObj>();
            elecItems = new List<ItemObj>();
            oxyItems = new List<ItemObj>();
            readyItem = new List<ItemObj>();

            panel = pn;
            grid = grd;
            graphicsDevice = gd;
        }

        public ItemObj createRandomObject()
        {
            ItemObj item;
            switch(new Random().Next(1, 15))
            {
                case 1: item = new WaterObject(waterTexture, spriteBatch); break;
                case 2: item = new WaterObject(waterTexture, spriteBatch); break;
                case 3: item = new WaterObject(waterTexture, spriteBatch); break;
                case 4: item = new WaterObject(waterTexture, spriteBatch); break;
                case 5: item = new WaterObject(waterTexture, spriteBatch); break;
                case 6: item = new WaterObject(waterTexture, spriteBatch); break;
                case 7: item = new WaterObject(waterTexture, spriteBatch); break;
                case 8: item = new WaterObject(waterTexture, spriteBatch); break;
                case 9: item = new WaterObject(waterTexture, spriteBatch); break;
                case 10: item = new WaterObject(waterTexture, spriteBatch); break;
                case 11: item = new WaterObject(waterTexture, spriteBatch); break;
                case 12: item = new WaterObject(waterTexture, spriteBatch); break;
                case 13: item = new WaterObject(waterTexture, spriteBatch); break;
                case 14: item = new WaterObject(waterTexture, spriteBatch); break;
                case 15: item = new WaterObject(waterTexture, spriteBatch); break;
                default: item = new WaterObject(waterTexture, spriteBatch); break;
            }
            return item;
        }

        #region[Events]

        public void MouseClick(Object sender, MouseEventArgs e)
        {
            int mouseX = e.MouseDelta.X;
            int mouseY = e.MouseDelta.Y;
            foreach(var item in readyItem)
            {
                if(this.SelectedItem(item.rectangle, mouseX, mouseY))
                {
                    this.buffer = item;
                }
            }
            readyItem.Remove(this.buffer);
        }

        #endregion
        #region[Help methods]
        public bool SelectedItem(Rectangle rectangle, int x, int y)
        {
            return (x >= rectangle.X && x <= (rectangle.X + rectangle.Width))
                    &&
                    y >= rectangle.Y && y <= (rectangle.Y + rectangle.Height);
        }
        #endregion
        public void Draw()
        {
            SetSizePanelItem();
            spriteBatch.Begin();
            foreach(ItemObj item in readyItem)
            {
                item.Draw();
            }
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            waterTexture = content.Load<Texture2D>(ContentEnum.BLOCK);
            spriteBatch = sp;
            
            readyItem.Add(createRandomObject());
            readyItem.Add(createRandomObject());
            readyItem.Add(createRandomObject());
        }

        public void Update(GameTime gameTime)
        {

        }

        private void SetSizePanelItem()
        {
            Rectangle rectangle = panel.GetPanelPosition();
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int countItem = readyItem.Count;

            int change_x = 10;
            int change_y = 10;

            int x_n = 0;
            int y_n = 0;
            int width_n = 0;
            int height_n = 0;
            int indexItem = 0;

            List<ItemObj> resetItems = new List<ItemObj>();
            foreach (var item in readyItem)
            {
                ItemObj it = item;
                x_n = x + change_x;
                y_n = y + change_y + height_n * indexItem;
                if (width_n == 0) width_n = width - change_x;
                if (height_n == 0) height_n = height / countItem - change_y;

                Rectangle rec = new Rectangle(x_n, y_n, width_n, height_n);
                indexItem++;
                it.rectangle = rec;
                resetItems.Add(it);
            }
            readyItem = resetItems;
        }
    }
}
