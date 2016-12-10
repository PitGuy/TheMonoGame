using GameHack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

        public ItemFactory(Panel pn, SpriteBatch sp, GraphicsDevice gd, Rectangle grd)
        {
            waterItems = new List<ItemObj>();
            elecItems = new List<ItemObj>();
            oxyItems = new List<ItemObj>();
            readyItem = new List<ItemObj>();

            panel = pn;
            grid = grd;
            spriteBatch = sp;
            graphicsDevice = gd;
        }

        public ItemObj crateRandomObject()
        {
            ItemObj item;
            switch(new Random().Next(1, 15))
            {
                case 1: item = new WaterObject(waterTexture); break;
                case 2: item = new WaterObject(waterTexture); break;
                case 3: item = new WaterObject(waterTexture); break;
                case 4: item = new WaterObject(waterTexture); break;
                case 5: item = new WaterObject(waterTexture); break;
                case 6: item = new WaterObject(waterTexture); break;
                case 7: item = new WaterObject(waterTexture); break;
                case 8: item = new WaterObject(waterTexture); break;
                case 9: item = new WaterObject(waterTexture); break;
                case 10: item = new WaterObject(waterTexture); break;
                case 11: item = new WaterObject(waterTexture); break;
                case 12: item = new WaterObject(waterTexture); break;
                case 13: item = new WaterObject(waterTexture); break;
                case 14: item = new WaterObject(waterTexture); break;
                case 15: item = new WaterObject(waterTexture); break;
                default: item = new WaterObject(waterTexture); break;
            }
            return item;
        }

        public void Draw()
        {

        }

        public void LoadContent(ContentManager content, SpriteBatch sp)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
