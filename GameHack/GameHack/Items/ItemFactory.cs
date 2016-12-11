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
using Microsoft.Xna.Framework.Input;

namespace GameHack.Items
{
    public class ItemFactory : IGameObject
    {
        Panel panel;
        Rectangle grid;

        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        Texture2D waterTextureG;
        Texture2D waterTexture;
        Texture2D waterTextureAng1;
        Texture2D waterTextureAng2;
        Texture2D waterTextureAng3;
        Texture2D waterTextureAng4;
        Texture2D elecTexture;
        Texture2D elecTextureAng;
        Texture2D oxyTextureG;
        Texture2D oxyTextureV;
        Texture2D oxyTextureAng1;
        Texture2D oxyTextureAng2;
        Texture2D oxyTextureAng3;
        Texture2D oxyTextureAng4;
        Texture2D fakeTexture;

        ItemObj[,] arrItem = new ItemObj[8,6];
        List<ItemObj> waterItems;
        List<ItemObj> elecItems;
        List<ItemObj> oxyItems;
        List<ItemObj> readyItem;
        private ItemObj buffer;
        public ItemObj Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }
        ItemObj fakeItem;

        bool cancelMoveItem = false;
        bool isSelect = false;

        bool clickedLeftMouseClick = false;
        bool clickedRightMouseClick = false;
        bool clickedLeftMouseClickBuilt = false;

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
            Random rand = new Random();
            switch (rand.Next(1,24))
            {
                case 1: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 2: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 3: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 4: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 5: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 6: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 7: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 8: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 9: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 10: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 11: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 12: item = new WaterObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 13: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 14: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 15: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 16: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 17: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 18: item = new EleObject(waterTexture, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 19: item = new OxyObject(oxyTextureG, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 20: item = new OxyObject(oxyTextureV, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 21: item = new OxyObject(oxyTextureAng1, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 22: item = new OxyObject(oxyTextureAng2, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 23: item = new OxyObject(oxyTextureAng3, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                case 24: item = new OxyObject(oxyTextureAng4, spriteBatch, graphicsDevice, sizeX, sizeY); break;
                default: item = null; break;
            }
            return item;
        }

        public int sizeX
        {
            get { return (int)((Double)50 * ((Double)graphicsDevice.PresentationParameters.BackBufferWidth / 1600)); }
        }
        public int sizeY
        {
            get { return (int)((Double)50 * ((Double)graphicsDevice.PresentationParameters.BackBufferHeight / 900)); }
        }
        #region[Events]
        Rectangle get_position_mouse(MouseState mouse)
        {
            int x = mouse.Position.X;
            int y = mouse.Position.Y;
            if (x > graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + sizeX && x < graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + 9 * sizeX && y > graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY && y < graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY + 6 * sizeY)
            {
                x = x / sizeX * sizeX;
                y = y / sizeY * sizeY;
            }
            return new Rectangle(x, y, sizeX, sizeY);
        }
        Point getIndex(MouseState mouse)
        {
            int x = mouse.Position.X;
            int y = mouse.Position.Y;
            int newX = (x - graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX - sizeX) / 50;
            int newY = (y - graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY) /50;
            return new Point(newX, newY);
        }
        Boolean get_position_mouseCheck(MouseState mouse)
        {
            int x = mouse.Position.X;
            int y = mouse.Position.Y;
            if (x > graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + sizeX && x < graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + 9 * sizeX && y > graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY && y < graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY + 6 * sizeY)
            {
                return true;
            }
            return false;
        }
        public void LeftMouseClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && !this.clickedLeftMouseClick && get_position_mouse(mouseState).Intersects(panel.GetPanelPosition()))
            {
                int mouseX = mouseState.X;
                int mouseY = mouseState.Y;
                List<ItemObj> newReadyItem = new List<ItemObj>();
                foreach (var item in readyItem)
                {
                    if (this.SelectedItem(item.rectangle, mouseX, mouseY))
                    {
                        if (item is WaterObject)
                        {
                            this.buffer = WaterObject.CopyObject(item as WaterObject);
                            this.Buffer = item;
                            fakeItem = WaterObject.CopyObject(item as WaterObject, fakeTexture);
                        }
                        else if(item is EleObject)
                        {
                            this.buffer = EleObject.CopyObject(item as EleObject);
                            this.Buffer = item;
                            fakeItem = EleObject.CopyObject(item as EleObject, fakeTexture);
                        }
                        else if (item is OxyObject)
                        {
                            this.buffer = OxyObject.CopyObject(item as OxyObject);
                            this.Buffer = item;
                            fakeItem = OxyObject.CopyObject(item as OxyObject, fakeTexture);
                        }
                        newReadyItem.Add(fakeItem);
                        this.cancelMoveItem = false;
                        this.isSelect = true;
                        this.clickedLeftMouseClick = true;
                        this.clickedRightMouseClick = false;
                        this.clickedLeftMouseClickBuilt = false;
                    }
                    else
                    {
                        newReadyItem.Add(item);
                    }
                }
                readyItem = new List<ItemObj>();
                readyItem = newReadyItem;
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && this.clickedLeftMouseClick && get_position_mouseCheck(mouseState) && !this.clickedLeftMouseClickBuilt && !touch(get_position_mouse(mouseState), waterItems))
            {
                ItemObj newItem = null;
                if (buffer is WaterObject)
                {
                    newItem = WaterObject.CopyObject(buffer as WaterObject);
                    waterItems.Add(newItem);
                }
                else if (buffer is EleObject)
                {
                    newItem = EleObject.CopyObject(buffer as EleObject);
                    elecItems.Add(newItem);
                }
                else if (buffer is OxyObject)
                {
                    newItem = OxyObject.CopyObject(buffer as OxyObject);
                    oxyItems.Add(newItem);
                }
                Point point = getIndex(mouseState);
                arrItem[point.X, point.Y] = newItem;
                buffer = null;
                for(int i = 0; i < readyItem.Count; i++)
                {
                    if(readyItem[i].Texture == fakeTexture)
                    {
                        readyItem[i] = createRandomObject();
                    }
                }
                this.clickedLeftMouseClickBuilt = true;

                this.clickedLeftMouseClick = false;
                this.clickedRightMouseClick = false;
            }
            
            
        }

        bool touch(Rectangle a, List<ItemObj> b)
        {
            foreach (ItemObj tmp in b)
            {
                if (a.Intersects((tmp as WaterObject).getNewRectangle(tmp.rectangle)))
                    return true;
            }
            return false;
        }

        public void RightMouseClick(MouseState mouseState)
        {
            if (this.buffer != null && mouseState.RightButton == ButtonState.Pressed && !clickedRightMouseClick)
            {
                //this.fakeItem = this.buffer;
                this.fakeItem = this.Buffer;
                this.cancelMoveItem = true;
                this.isSelect = false;
                this.fakeItem = null;
                List<ItemObj> oldreadyItem = new List<ItemObj>();
                foreach (var item in this.readyItem)
                {
                    if (item.Texture == this.fakeTexture)
                    {
                        oldreadyItem.Add(buffer);
                    }
                    else
                    {
                        oldreadyItem.Add(item);
                    }
                }
                this.clickedLeftMouseClick = false;
                this.clickedRightMouseClick = true;
                this.readyItem = oldreadyItem;
            }
        }
        public void MouseMove(MouseState mouseState)
        {
            if (!this.cancelMoveItem && this.Buffer != null)
            {
                Rectangle mouseRC = get_position_mouse(mouseState);
                this.Buffer.rectangle.X = mouseRC.X;
                this.Buffer.rectangle.Y = mouseRC.Y;
                this.Buffer.rectangle.Width = mouseRC.Width;
                this.Buffer.rectangle.Height = mouseRC.Height;
            }
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
            foreach (WaterObject item in waterItems)
            {
                item.DrawNew();
            }
            foreach (EleObject item in elecItems)
            {
                item.DrawNew();
            }
            foreach (OxyObject item in oxyItems)
            {
                item.DrawNew();
            }
            foreach (ItemObj item in readyItem)
            {
                item.Draw();
            }
            if (!this.cancelMoveItem && Buffer != null)
            {
                Buffer.Draw();
            }
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {
            waterTexture = content.Load<Texture2D>(ContentEnum.BLOCK);
            oxyTextureG = content.Load<Texture2D>(ContentEnum.OXYG);
            oxyTextureV = content.Load<Texture2D>(ContentEnum.OXYV);
            oxyTextureAng1 = content.Load<Texture2D>(ContentEnum.OXYLD);
            oxyTextureAng2 = content.Load<Texture2D>(ContentEnum.OXYLT);
            oxyTextureAng3 = content.Load<Texture2D>(ContentEnum.OXYRT);
            oxyTextureAng4 = content.Load<Texture2D>(ContentEnum.OXYRD);
            fakeTexture = content.Load<Texture2D>(ContentEnum.FAKE);
            spriteBatch = sp;
            readyItem.Add(createRandomObject());
            readyItem.Add(createRandomObject());
            readyItem.Add(createRandomObject());
        }

        private void SetSizePanelItem()
        {
            Rectangle rectangle = panel.GetPanelPosition();
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int countItem = readyItem.Count;

            int change_x = 20;
            int change_y = 20;

            int x_n = 0;
            int y_n = 0;
            int width_n = 0;
            int height_n = 0;
            int chngeHeight = 0;
            int indexItem = 0;

            List<ItemObj> resetItems = new List<ItemObj>();
            foreach (var item in readyItem)
            {
                ItemObj it = item;
                x_n = x + change_x;
                y_n = y + change_y + height/countItem * indexItem;
                if (width_n == 0) width_n = width - change_x-20;
                if (height_n == 0) height_n = height / countItem - change_y-20;

                Rectangle rec = new Rectangle(x_n, y_n, width_n, height_n);
                indexItem++;
                chngeHeight += 25;
                it.rectangle = rec;
                resetItems.Add(it);
            }
            readyItem = resetItems;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            this.RightMouseClick(mouseState);
            this.LeftMouseClick(mouseState);
            this.MouseMove(mouseState);
        }
    }
}
