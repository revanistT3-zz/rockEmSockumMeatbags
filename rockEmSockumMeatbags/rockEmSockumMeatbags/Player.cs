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
        private int health = 0;
        private int damage = 0;
        private int speed = 0;
        private string name = "";
        private int attackspeed = 0;

        public Player(ContentManager content, int health, int damage, int speed, string name, int attackspeed)
        {
           this.health = health;
            this.damage =damage;
            this.speed = speed;
            this.name = name;
            this.attackspeed = attackspeed;
        }

    }
}
