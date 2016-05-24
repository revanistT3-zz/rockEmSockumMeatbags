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
        public Timer(ContentManager content) : this(content ,60*60)
        {
        }
        public Timer(ContentManager content, int increment)
        {
            this.increment = increment;
            this.font = content.Load<SpriteFont>("font");
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
        public void Draw(SpriteBatch spritebatch, Vector2 vec)
        {
            spritebatch.Begin();
            spritebatch.DrawString(font, toString() , vec, Color.Tomato );
            spritebatch.End();
        }
    }
}
