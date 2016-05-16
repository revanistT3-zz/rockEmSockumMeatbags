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
    class Player
    {
        private Texture2D healthBar;
        private SpriteFont font;
        private int health = 100;
        private int damage = 10;
        private int speed = 5;
        private string name = "";
        private int attackspeed = 2;

        public Player(ContentManager content, int health, int damage, int speed, string name, int attackspeed)
        {
            this.health = health;
            this.damage = damage;
            this.speed = speed;
            this.name = name;
            this.attackspeed = attackspeed;
            this.healthBar = content.Load<Texture2D>("blank");
            this.font = content.Load<SpriteFont>("font");
            // private int strength = 0;
            //private int stamina = 0;
            //private int agility = 0;
            // private int wisdom = 0;
            //  private int accuracy = 0;
        }
        public int getHealth()
        {
            return health;
        }
        public int hit(int damage)
        {
            health -= damage;
            return getHealth();
        }
        public void changeSpeed(int slow)
        {
            speed += slow;

        }
        public void drawHud(SpriteBatch spritebatch, Rectangle area)
        {
            spritebatch.Begin();
            spritebatch.Draw(healthBar, 
                new Rectangle(area.X, area.Y, area.Width, area.Height/2), 
                Color.Red);
            spritebatch.DrawString(font, name,new Vector2(area.X, area.Y + area.Height) , Color.White);
            spritebatch.End();
        }

    }
}
