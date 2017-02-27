using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameHack.Abstraction
{
    abstract class ButtonObject
    {
        protected Rectangle buttonRectangle;
        private bool enterMouse;
        public ButtonObject(Rectangle buttonRectangle)
        {
            this.buttonRectangle = buttonRectangle;
            enterMouse = false;
        }
        protected bool WasCliked()
        {
            MouseState mouseState = Mouse.GetState();
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;
            if (Intersect(buttonRectangle, mouseX, mouseY))
            {
                if(!enterMouse)
                {
                    enterMouse = true;
                    buttonRectangle.Height += 20;
                    buttonRectangle.Width += 20;
                    buttonRectangle.X -= 10;
                    buttonRectangle.Y -= 10;
                }
                if(mouseState.LeftButton == ButtonState.Pressed)
                return true;
            }
            else if(enterMouse)
            {
                enterMouse = false;
                buttonRectangle.Height -= 20;
                buttonRectangle.Width -= 20;
                buttonRectangle.X += 10;
                buttonRectangle.Y += 10;
            }
            return false;
        }
        public static bool Intersect(Rectangle rectangle, int x, int y)
        {
            return (x >= rectangle.X && x <= (rectangle.X + rectangle.Width)) && y >= rectangle.Y && y <= (rectangle.Y + rectangle.Height);
        }
    }
}
