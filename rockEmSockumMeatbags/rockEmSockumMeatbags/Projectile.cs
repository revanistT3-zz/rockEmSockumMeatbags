using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace rockEmSockumMeatbags
{
    class Projectile
    {
        private int speed = 5;
        private int size = 1;
        private bool end = false;
        private int locationX = 0;
        private int locationY = 0;
        private int width = 0;
        private int height = 0;
        private Rectangle proj = new Rectangle(0, 0, 0, 0);
        private int damage;
        private string skin = "";

        public Projectile(ContentManager content, int speed, int locationX, int locationY, int width, int height, int damage, string skin)
        {
            this.speed = speed;
            this.locationX = locationX;
            this.locationY = locationY;
            this.width = width;
            this.height = height;
            this.damage = damage;
            this.skin = skin;
            proj.X = locationX;
            proj.Y = locationY;
            proj.Width = width;
            proj.Height = height;
        }
        public Boolean endX(int endX)
        {
            if (locationX == 0 - width || locationX == endX + width)
            {
                return true;
            }
            else return false;
        }
        public Boolean endY(int endY)
        {
            if (locationY == 0 - height || locationY == endY + height)
            {
                return true;
            }
            else return false;  
        }
        public void goToLocation(int x, int y)
        {
            locationX = x;
            locationY = y;        
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            
            spritebatch.End();
        }
        public void animate(GameTime gameTime, string skin)
        {
            TimeSpan lasttime1 = new TimeSpan();
            TimeSpan increment1 = new TimeSpan(0, 0, 0, 0, 100);
            int texchan1 = 0;   
            if (gameTime.TotalGameTime - lasttime1 > increment1)
            {
                texchan1++;
                if (texchan1 > 1)
                {
                    texchan1 = 0;

                }
                lasttime1 = gameTime.TotalGameTime;
            }
        }
        public Boolean hitPlayer(Player player)
        {
            return false;
            //if (proj.Intersects
        }

    }
}