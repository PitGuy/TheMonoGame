﻿using GameHack.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GameHack.Items
{
    public class WaterObject : ItemObj    {
        public WaterObject(Rectangle rectangle, StatusObj status, TypeObj type)
        {
            this.rectangle = rectangle;
            this.status = status;
            this.type = type;
            this.type = TypeObj.Water;
        }

        public void ChangePosition(int x, int y)
        {
            this.rectangle.X = x;
            this.rectangle.Y = y;
        }
        public void ChangeSize(int width, int height)
        {
            this.rectangle.Width = width;
            this.rectangle.Height = height;
        }

        public override bool SelectedItem(int x, int y)
        {
            return (x >= this.rectangle.X && x <= (this.rectangle.X + this.rectangle.Width)) 
                    &&
                    y>=this.rectangle.Y && y <= (this.rectangle.Y + this.rectangle.Height);
        }

        public override Rectangle GetRectangle()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            spriteBatch.Draw(this.texture, rectangle, Color.White);
        }

        public override void LoadContent(ContentManager content, SpriteBatch sp)
        {
            this.spriteBatch = sp;
            texture = content.Load<Texture2D>("");
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}