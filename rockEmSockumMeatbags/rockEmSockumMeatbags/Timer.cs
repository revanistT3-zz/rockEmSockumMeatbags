using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace rockEmSockumMeatbags
{
    class Timer
    {
        private int increment;
        private SpriteFont font;
        private Vector2 vec = new Vector2();
        public Timer(ContentManager content, Vector2 vec = new Vector2(), int increment = 60 * 60)
        {
            this.increment = increment;
            this.font = content.Load<SpriteFont>("font");
            this.vec = vec;
        }

        public Boolean update() //true  - time:  0
        {                       //false - time: !0
            increment--;
            return increment == 0;
        }

        public int seconds
        {
            get { return increment / 60; }
        }
        public int minutes
        {
            get { return seconds / 60; }
        }

        public String toString()
        {
            String front = minutes != 0
                ? minutes.ToString() + ":"
                : "";
            return front + seconds.ToString();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Func.safeDraw(spritebatch, () =>
            {
                spritebatch.DrawString(font, toString(), vec, Color.Tomato);
            });
        }
    }
}
