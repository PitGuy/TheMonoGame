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
        Random rand;

        Panel panel;
        Rectangle grid;

        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        Texture2D waterTexture1;
        Texture2D waterTexture2;
        Texture2D waterTexture3;
        Texture2D waterTexture4;
        Texture2D waterTexture5;
        Texture2D waterTexture6;
        Texture2D elecTexture1;
        Texture2D elecTexture2;
        Texture2D elecTexture3;
        Texture2D elecTexture4;
        Texture2D elecTexture5;
        Texture2D elecTexture6;
        Texture2D oxyTextureG;
        Texture2D oxyTextureV;
        Texture2D oxyTextureAng1;
        Texture2D oxyTextureAng2;
        Texture2D oxyTextureAng3;
        Texture2D oxyTextureAng4;
        Texture2D fakeTexture;

        public static ItemObj[,] arrItem = new ItemObj[15,10];
        List<ItemObj> waterItems;
        List<ItemObj> elecItems;
        List<ItemObj> oxyItems;
        List<ItemObj> readyItem;
        private ItemObj buffer;
        private SunItem sun;

        private int heightSun = 0;
        private int widthSun = 0;

        bool intersecSun = false;
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

        WaterObject startWater;
        WaterObject endWater;

        EleObject eleStart;
        EleObject eleEnd;

        OxyObject oxyStart;
        OxyObject oxyEnd;

        public ItemFactory(Panel pn, GraphicsDevice gd, Rectangle grd)
        {
            rand = new Random();

            waterItems = new List<ItemObj>();
            elecItems = new List<ItemObj>();
            oxyItems = new List<ItemObj>();
            readyItem = new List<ItemObj>();

            panel = pn;
            grid = grd;
            graphicsDevice = gd;
        }

        public ItemObj createRandomWatterObject()
        {
            ItemObj item;
            switch (rand.Next(1, 7))
            {
                case 1: item = new WaterObject(waterTexture5, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true, true); break;
                case 2: item = new WaterObject(waterTexture6, spriteBatch, graphicsDevice, sizeX, sizeY, true, true, false, false); break;
                case 3: item = new WaterObject(waterTexture1, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, false, true); break;
                case 4: item = new WaterObject(waterTexture2, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, true, false); break;
                case 5: item = new WaterObject(waterTexture3, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, false, true); break;
                case 6: item = new WaterObject(waterTexture4, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, true, false); break;
                case 7: item = new WaterObject(waterTexture5, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true, true); break;
                default: item = null; break;
            }
            return item;
        }
        public ItemObj createRandomEleObject()
        {
            ItemObj item;
            switch (rand.Next(1, 7))
            {
                case 1: item = new EleObject(elecTexture1, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true , true); break;
                case 2: item = new EleObject(elecTexture2, spriteBatch, graphicsDevice, sizeX, sizeY, true, true, false, false); break;
                case 4: item = new EleObject(elecTexture3, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, false, true); break;
                case 5: item = new EleObject(elecTexture4, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, true, false); break;
                case 6: item = new EleObject(elecTexture1, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true, true); break;
                case 7: item = new EleObject(elecTexture5, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, true, false); break;
                case 3: item = new EleObject(elecTexture6, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, false, true); break;
                default: item = null; break;
            }
            return item;
        }
        public ItemObj createRandomOxyObject()
        {
            ItemObj item;
            switch (rand.Next(1, 7))
            {
                case 1: item = new OxyObject(oxyTextureG, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true, true); break;
                case 2: item = new OxyObject(oxyTextureV, spriteBatch, graphicsDevice, sizeX, sizeY, true, true, false, false); break;
                case 3: item = new OxyObject(oxyTextureAng1, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, true, false); break;
                case 4: item = new OxyObject(oxyTextureAng2, spriteBatch, graphicsDevice, sizeX, sizeY, false, true, false, true); break;
                case 5: item = new OxyObject(oxyTextureAng3, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, true, false); break;
                case 6: item = new OxyObject(oxyTextureAng4, spriteBatch, graphicsDevice, sizeX, sizeY, true, false, false, true); break;
                case 7: item = new OxyObject(oxyTextureG, spriteBatch, graphicsDevice, sizeX, sizeY, false, false, true, true); break;
                default: item = null; break;
            }
            return item;
        }
        public int sizeX
        {
            get { return (int)((Double)30 * ((Double)graphicsDevice.PresentationParameters.BackBufferWidth / 1600)); }
        }
        public int sizeY
        {
            get { return (int)((Double)30 * ((Double)graphicsDevice.PresentationParameters.BackBufferHeight / 900)); }
        }
        #region[Events]
        Rectangle get_position_mouse(MouseState mouse)
        {
            int x = mouse.Position.X;
            int y = mouse.Position.Y;
            if (x > graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + sizeX && x < graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 6 / sizeX * sizeX + 9 * sizeX && y > graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY && y < graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 4 / sizeY * sizeY + 7 * sizeY)
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
            int newX = (x - graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX - sizeX) / 30;
            int newY = (y - graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY) /30;
            return new Point(newX, newY);
        }
        Boolean get_position_mouseCheck(MouseState mouse)
        {
            int x = mouse.Position.X;
            int y = mouse.Position.Y;
            if (x > graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 4 / sizeX * sizeX + sizeX && x < graphicsDevice.PresentationParameters.BackBufferWidth / 16 * 6 / sizeX * sizeX + 9 * sizeX && y > graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 3 / sizeY * sizeY && y < graphicsDevice.PresentationParameters.BackBufferHeight / 9 * 4 / sizeY * sizeY + 7 * sizeY)
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
            else if (mouseState.LeftButton == ButtonState.Pressed && this.clickedLeftMouseClick && get_position_mouseCheck(mouseState) && !this.clickedLeftMouseClickBuilt && !touch(get_position_mouse(mouseState), waterItems) && !touch(get_position_mouse(mouseState), oxyItems) && !touch(get_position_mouse(mouseState), elecItems))
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
                arrItem[point.X, point.Y > 5 ? point.Y - 1 : point.Y] = newItem;
                buffer = null;
                for(int i = 0; i < readyItem.Count; i++)
                {
                    if(readyItem[i].Texture == fakeTexture)
                    {
                        if(readyItem[i] is WaterObject)
                        readyItem[i] = createRandomWatterObject();
                        else if (readyItem[i] is EleObject)
                            readyItem[i] = createRandomEleObject();
                        else if (readyItem[i] is OxyObject)
                            readyItem[i] = createRandomOxyObject();
                    }
                }
                this.clickedLeftMouseClickBuilt = true;

                this.clickedLeftMouseClick = false;
                this.clickedRightMouseClick = false;
            }
            else if (this.SelectedItem(this.sun.rectangle, mouseState.X, mouseState.Y))
            {
                buffer = null;
                for (int i = 0; i < readyItem.Count; i++)
                {
                    if (readyItem[i].Texture == fakeTexture)
                    {
                        if (readyItem[i] is WaterObject)
                            readyItem[i] = createRandomWatterObject();
                        else if (readyItem[i] is EleObject)
                            readyItem[i] = createRandomEleObject();
                        else if (readyItem[i] is OxyObject)
                            readyItem[i] = createRandomOxyObject();
                    }
                }
                this.clickedLeftMouseClick = false;
                this.clickedRightMouseClick = false;
            }
        }

        bool touch(Rectangle a, List<ItemObj> b)
        {
            foreach (ItemObj tmp in b)
            {
                if (tmp is WaterObject && a.Intersects((tmp as WaterObject).getNewRectangle(tmp.rectangle)))
                    return true;
                if (tmp is EleObject && a.Intersects((tmp as EleObject).getNewRectangle(tmp.rectangle)))
                    return true;
                if (tmp is OxyObject && a.Intersects((tmp as OxyObject).getNewRectangle(tmp.rectangle)))
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
            /*if (this.SelectedItem(this.sun.rectangle, mouseState.X, mouseState.Y) && !this.intersecSun)
            {
                this.sun.rectangle.Height += 20;
                this.sun.rectangle.Width += 20;
                this.intersecSun = true;

            }
            else { 
                this.sun.rectangle.Height = this.heightSun;
                this.sun.rectangle.Width = this.widthSun;
                this.intersecSun = false;
            }*/
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
            sun.Draw();
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
            waterTexture1 = content.Load<Texture2D>(ContentEnum.WOT1);
            waterTexture2 = content.Load<Texture2D>(ContentEnum.WOT2);
            waterTexture3 = content.Load<Texture2D>(ContentEnum.WOT3);
            waterTexture4 = content.Load<Texture2D>(ContentEnum.WOT4);
            waterTexture5 = content.Load<Texture2D>(ContentEnum.WOT5);
            waterTexture6 = content.Load<Texture2D>(ContentEnum.WOT6);
            oxyTextureG = content.Load<Texture2D>(ContentEnum.OXY1);
            oxyTextureV = content.Load<Texture2D>(ContentEnum.OXY2);
            oxyTextureAng1 = content.Load<Texture2D>(ContentEnum.OXY3);
            oxyTextureAng2 = content.Load<Texture2D>(ContentEnum.OXY4);
            oxyTextureAng3 = content.Load<Texture2D>(ContentEnum.OXY5);
            oxyTextureAng4 = content.Load<Texture2D>(ContentEnum.OXY6);
            elecTexture1 = content.Load<Texture2D>(ContentEnum.ELECTRONIC1);
            elecTexture2 = content.Load<Texture2D>(ContentEnum.ELECTRONIC2);
            elecTexture3 = content.Load<Texture2D>(ContentEnum.ELECTRONIC3);
            elecTexture4 = content.Load<Texture2D>(ContentEnum.ELECTRONIC4);
            elecTexture5 = content.Load<Texture2D>(ContentEnum.ELECTRONIC5);
            elecTexture6 = content.Load<Texture2D>(ContentEnum.ELECTRONIC6);
            oxyTextureG = content.Load<Texture2D>(ContentEnum.OXY4);
            oxyTextureV = content.Load<Texture2D>(ContentEnum.OXY1);
            oxyTextureAng1 = content.Load<Texture2D>(ContentEnum.OXY2);
            oxyTextureAng2 = content.Load<Texture2D>(ContentEnum.OXY3);
            oxyTextureAng3 = content.Load<Texture2D>(ContentEnum.OXY6);
            oxyTextureAng4 = content.Load<Texture2D>(ContentEnum.OXY5);
            fakeTexture = content.Load<Texture2D>(ContentEnum.FAKE);
            spriteBatch = sp;
            this.sun = new SunItem(new Rectangle(100, 100, 100, 100), sp);
            this.heightSun = sun.rectangle.Height;
            this.widthSun = sun.rectangle.Width;
            this.sun.LoadContent(content, sp);
            readyItem.Add(createRandomWatterObject());
            readyItem.Add(createRandomEleObject());
            readyItem.Add(createRandomOxyObject());

            startWater = new WaterObject(waterTexture5, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            startWater.rectangle = new Rectangle(420, 300, 30, 30);
            endWater = new WaterObject(waterTexture5, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            endWater.rectangle = new Rectangle(840, 480, 30, 30);
            endWater.IsFinallyObj = true;
            waterItems.Add(startWater);
            waterItems.Add(endWater);
            arrItem[0, 0] = startWater;
            arrItem[14, 6] = endWater;

            eleStart = new EleObject(elecTexture1, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            eleStart.rectangle = new Rectangle(420, 390, 30, 30);
            eleEnd = new EleObject(elecTexture1, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            eleEnd.rectangle = new Rectangle(840, 390, 30, 30);
            eleEnd.IsFinallyObj = true;
            elecItems.Add(eleStart);
            elecItems.Add(eleEnd);
            arrItem[0, 4] = eleStart;
            arrItem[14, 3] = eleEnd;

            oxyStart = new OxyObject(oxyTextureG, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            oxyStart.rectangle = new Rectangle(420, 480, 30, 30);
            oxyEnd = new OxyObject(oxyTextureG, spriteBatch, graphicsDevice, 30, 30, false, false, true, true);
            oxyEnd.rectangle = new Rectangle(840, 330, 30, 30);
            oxyEnd.IsFinallyObj = true;
            oxyItems.Add(oxyStart);
            oxyItems.Add(oxyEnd);
            arrItem[0, 7] = oxyStart;
            arrItem[14, 1] = oxyEnd;
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
