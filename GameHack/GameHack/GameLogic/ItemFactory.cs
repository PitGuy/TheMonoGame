using System;
using GameHack.GameElement;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using GameHack.Register;

namespace GameHack.GameLogic
{
    internal class ItemFactory
    {
        Random random;

        #region texture
        Texture2D textureW11;
        Texture2D textureW1_1;
        Texture2D textureW_1_1;
        Texture2D textureW_11;
        Texture2D textureW01;
        Texture2D textureW0_1;
        Texture2D textureW10;
        Texture2D textureWO;
        Texture2D textureWE;
        Texture2D textureO11;
        Texture2D textureO1_1;
        Texture2D textureO_1_1;
        Texture2D textureO_11;
        Texture2D textureO01;
        Texture2D textureO0_1;
        Texture2D textureO10;
        Texture2D textureOE;
        Texture2D textureOW;
        Texture2D textureE11;
        Texture2D textureE1_1;
        Texture2D textureE_1_1;
        Texture2D textureE_11;
        Texture2D textureE01;
        Texture2D textureE0_1;
        Texture2D textureE10;
        Texture2D textureEW;
        Texture2D textureEO;
        #endregion

        public ItemFactory()
        {
            random = new Random();
        }
        internal Item GenerateItem(int index)
        {
            int rand = random.Next(1, 10);
            rand += index * 9;
            switch (rand)
            {
                case 1: return new Item(new Point(1, 1), "W", textureW11); 
                case 2: return new Item(new Point(1, -1), "W", textureW1_1); 
                case 3: return new Item(new Point(-1, -1), "W", textureW_1_1); 
                case 5: return new Item(new Point(-1, 1), "W", textureW_11); 
                case 4: return new Item(new Point(0, 1), "W", textureW01); 
                case 6: return new Item(new Point(0, -1), "W", textureW0_1);
                case 7: return new Item(new Point(1, 0), "W", textureW10);
                case 8: return new Item(new Point(0, 0), "W", textureWO, "O");
                case 9: return new Item(new Point(0, 0), "W", textureWE, "E");
                case 10: return new Item(new Point(1, 1), "O", textureO11);
                case 11: return new Item(new Point(1, -1), "O", textureO1_1);
                case 12: return new Item(new Point(-1, -1), "O", textureO_1_1);
                case 13: return new Item(new Point(-1, 1), "O", textureO_11);
                case 14: return new Item(new Point(0, 1), "O", textureO01);
                case 15: return new Item(new Point(0, -1), "O", textureO0_1);
                case 16: return new Item(new Point(1, 0), "O", textureO10);
                case 17: return new Item(new Point(0, 0), "O", textureOE, "E");
                case 18: return new Item(new Point(0, 0), "O", textureOW, "W");
                case 19: return new Item(new Point(1, 1), "E", textureE11);
                case 20: return new Item(new Point(1, -1), "E", textureE1_1);
                case 21: return new Item(new Point(-1, -1), "E", textureE_1_1);
                case 22: return new Item(new Point(-1, 1), "E", textureE_11);
                case 23: return new Item(new Point(0, 1), "E", textureE01);
                case 24: return new Item(new Point(0, -1), "E", textureE0_1);
                case 25: return new Item(new Point(1, 0), "E", textureE10);
                case 26: return new Item(new Point(0, 0), "E", textureEW, "W");
                case 27: return new Item(new Point(0, 0), "E", textureEO, "O");
                default: return new Item(new Point(0, 0), "E", textureEO, "O");
            }
        }
        public void LoadContent(ContentManager content)
        {
            this.textureW11 = content.Load<Texture2D>(ContentPatch.WT1);
            this.textureW1_1 = content.Load<Texture2D>(ContentPatch.WT2);
            this.textureW_1_1 = content.Load<Texture2D>(ContentPatch.WT3);
            this.textureW_11 = content.Load<Texture2D>(ContentPatch.WT4);
            this.textureW01 = content.Load<Texture2D>(ContentPatch.WT5);
            this.textureW0_1 = content.Load<Texture2D>(ContentPatch.WT6);
            this.textureW10 = content.Load<Texture2D>(ContentPatch.WT7);
            this.textureWO = content.Load<Texture2D>(ContentPatch.WOT);
            this.textureWE = content.Load<Texture2D>(ContentPatch.WET);
            this.textureE11 = content.Load<Texture2D>(ContentPatch.ET1);
            this.textureE1_1 = content.Load<Texture2D>(ContentPatch.ET2);
            this.textureE_1_1 = content.Load<Texture2D>(ContentPatch.ET3);
            this.textureE_11 = content.Load<Texture2D>(ContentPatch.ET4);
            this.textureE01 = content.Load<Texture2D>(ContentPatch.ET5);
            this.textureE0_1 = content.Load<Texture2D>(ContentPatch.ET6);
            this.textureE10 = content.Load<Texture2D>(ContentPatch.ET7);
            this.textureEW = content.Load<Texture2D>(ContentPatch.EWT);
            this.textureEO = content.Load<Texture2D>(ContentPatch.EOT);
            this.textureO11 = content.Load<Texture2D>(ContentPatch.OT1);
            this.textureO1_1 = content.Load<Texture2D>(ContentPatch.OT2);
            this.textureO_1_1 = content.Load<Texture2D>(ContentPatch.OT3);
            this.textureO_11 = content.Load<Texture2D>(ContentPatch.OT4);
            this.textureO01 = content.Load<Texture2D>(ContentPatch.OT5);
            this.textureO0_1 = content.Load<Texture2D>(ContentPatch.OT6);
            this.textureO10 = content.Load<Texture2D>(ContentPatch.OT7);
            this.textureOE = content.Load<Texture2D>(ContentPatch.OET);
            this.textureOW = content.Load<Texture2D>(ContentPatch.OWT);
        }
    }
}