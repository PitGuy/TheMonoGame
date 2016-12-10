using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameHack.Interfaces
{
    interface IGameObject
    {
        void LoadContent();
        void Update();
        void Draw();
    }
}
