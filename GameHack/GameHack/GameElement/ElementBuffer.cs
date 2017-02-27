using GameHack.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameHack.GameElement
{
    class ElementBuffer
    {
        private ElementBuffer() { }
        private static ElementBuffer buffer;
        public bool OnField = false;
        public static ElementBuffer GetInstance()
        {
            if (buffer == null)
                buffer = new ElementBuffer();
            return buffer;
        }

        private Item bufferElement;
        internal void Draw(SpriteBatch spriteBatch)
        {
            if(bufferElement != null)
            {
                bufferElement.Draw(spriteBatch);
            }
        }

        public Item GetElement()
        {
            return bufferElement;
        }
        public void SetElement(Item bufferElement)
        {
            this.bufferElement = bufferElement;
        }

        public bool HaveElement()
        {
            return bufferElement != null;
        }

        internal void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            if(state.RightButton == ButtonState.Pressed && bufferElement != null)
            {
                Panel.GetInstance().ReturnObject(bufferElement);
                bufferElement = null;
            }
            if (bufferElement != null && !OnField)
            {
                bufferElement.rectangle = new Rectangle(state.X, state.Y, 50, 50);
            }
        }
        internal void Destroy()
        {
            bufferElement = null;
            Panel.GetInstance().AutofieldElemets();
        }
    }
}
