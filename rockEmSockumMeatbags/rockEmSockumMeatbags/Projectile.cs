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
        private Texture2D[] skins;
        private int texchan1 = 0; 
          private int x = 0;

        public Projectile(ContentManager content, int speed, int locationX, int locationY, int width, int height, int damage, string skin)
        {
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.locationX = locationX;
            this.locationY = locationY;
            this.damage = damage;
            this.skin = skin;
            proj.X = locationX;
            proj.Y = locationY;
            proj.Width = width;
            proj.Height = height;
            
            if (skin== "ball")
                 {
                    x = 4;
                    
                }
                  skins = new Texture2D[x];
                    skins [0] =content.Load<Texture2D>("bs1");
                        skins [1] =content.Load<Texture2D>("bs2");
                        skins [2] =content.Load<Texture2D>("bs3");
                        skins[3] = content.Load<Texture2D>("bs4");
            
        }
        public Boolean endX(int endX)
        {
            if (proj.X <= (0 - width)) 
            {
                return true;
            }
            else if (proj.X >= (endX + width))
            {
                return true;
            }
            else return false;
        }
        public Boolean endY(int endY)
        {
            if (proj.Y == 0 - height || proj.Y == endY + height)
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
            spritebatch.Draw(skins[texchan1], proj, Color.White);
            spritebatch.End();
        }
        public void animate(GameTime gameTime, string skin)
        {
            TimeSpan lasttime1 = new TimeSpan();
            TimeSpan increment1 = new TimeSpan(0, 0, 0, 5, 100);
            
           // if (gameTime.TotalGameTime - lasttime1 > increment1)
          //  {
                texchan1++;
                if (texchan1 >= x)
                {
                    texchan1 = 0;
                }
                //lasttime1 = gameTime.TotalGameTime;
          //  }
        }
        public Boolean hitPlayer(Rectangle playersRectangle)
        {
            if (proj.Intersects(playersRectangle))
            {
                return true;
                
            }
            return false;

        }
        public void goRight()
        {
            proj.X += speed;
        }
        public void goLeft()
        {
            proj.X -= speed;
        }
    }
}