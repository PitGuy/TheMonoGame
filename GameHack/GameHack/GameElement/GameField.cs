using GameHack.Abstraction;
using GameHack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Setting;
using Microsoft.Xna.Framework.Input;

namespace GameHack.GameElement
{
    class GameField : IGameObject
    {
        private Rectangle fieldRectangle;
        public static Item[,] fields;
        Setup setup;
        public GameField()
        {
            fieldRectangle = new Rectangle(550, 250, 500, 500);
            setup = Setup.GetInstance();
            fields = new Item[setup.SizeGameField.X, setup.SizeGameField.Y];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var field in fields)
            {
                if(field != null)
                field.Draw(spriteBatch);
            }
        }

        public void LoadContent(ContentManager content) { }

        public void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            int x = state.X;
            int y = state.Y;
            ElementBuffer buffer = ElementBuffer.GetInstance();
            if (fieldRectangle.Intersects(new Rectangle(x,y, 1, 1)) && buffer.HaveElement())
            {
                Item bufferElement = buffer.GetElement();
                Rectangle position = GetPosition(x, y);
                bufferElement.rectangle  = position;
                if (state.LeftButton == ButtonState.Pressed)
                {
                    Point index = GetIndexs(x, y);
                    if (fields[index.X,index.Y] == null)
                    {
                        fields[index.X, index.Y] = bufferElement;
                        buffer.Destroy();
                    }
                }
            }
            else if(buffer.OnField)
            {
                buffer.OnField = false;
            }
        }

        private Rectangle GetPosition(int x, int y)
        {
            return new Rectangle((x / 50 * 50), (y / 50 * 50), 50, 50);
        }

        private Point GetIndexs(int x, int y)
        {
            if (x < 550 || x > 1050 || y < 250 || y > 750)
            {
                return new Point(-1, -1);
            }
            else
            {
                x = x - 550;
                y = y - 250;
                return new Point(x / 50, y / 50);
            }
        }
    }
}
