using System;
using GameHack.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameHack.Register;
using Microsoft.Xna.Framework.Input;
using GameHack.Abstraction;
using GameHack.GameLogic;

namespace GameHack.GameElement
{
    class Panel : IGameObject
    {
        private static Panel panel;
        public static Panel GetInstance()
        {
            if (panel == null)
                panel = new Panel();
            return panel;
        }
        bool[] enterMouse;
        Texture2D texture;
        Rectangle rectangle;
        Item[] items;
        ItemFactory factory;
        private Panel()
        {
            rectangle = new Rectangle(1600 - 100, 300, 100, 300);
            factory = new ItemFactory();
            items = new Item[3];
            enterMouse = new bool[3];
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            foreach(var item in items)
            {
                if(item != null)
                item.Draw(spriteBatch);
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(ContentPatch.PANEL);
            factory.LoadContent(content);
            for (int i = 0; i < 3; i++)
            {
                items[i] = factory.GenerateItem(i);
                items[i].rectangle = new Rectangle(1520, 320 + i * 100, 60, 60);
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;
            ElementBuffer buffer = ElementBuffer.GetInstance();
            if (!buffer.HaveElement())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ButtonObject.Intersect(items[i].rectangle, mouseX, mouseY))
                    {
                        if (!enterMouse[i])
                        {
                            enterMouse[i] = true;
                            items[i].rectangle.Height += 10;
                            items[i].rectangle.Width += 10;
                        }
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            enterMouse[i] = false;
                            items[i].rectangle.Height = 50;
                            items[i].rectangle.Width = 50;
                            buffer.SetElement(items[i]);
                            items[i] = null;
                        }
                    }
                    else if (enterMouse[i])
                    {
                        enterMouse[i] = false;
                        items[i].rectangle.Height -= 10;
                        items[i].rectangle.Width -= 10;
                    }
                }
            }
        }

        internal void AutofieldElemets()
        {
            for (int i = 0; i < 3; i++)
            {
                if (items[i] == null)
                {
                    items[i] = factory.GenerateItem(i);
                    items[i].rectangle = new Rectangle(1520, 320 + i * 100, 60, 60);
                }
            }
        }

        public void ReturnObject(Item item)
        {
            for(int i = 0; i < 3; i++)
            {
                if(items[i] == null)
                {
                    items[i] = item;
                    items[i].rectangle = new Rectangle(1520, 320 + i * 100, 60, 60);
                }
            }
        }
    }
}
