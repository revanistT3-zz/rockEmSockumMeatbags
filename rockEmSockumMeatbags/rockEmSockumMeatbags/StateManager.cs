using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace rockEmSockumMeatbags
{
    class StateManager
    {
        public GameState state { get; private set; }
        private Player p1;
        private Player p2;
        private Player winner = null;
        private Timer timer;
        private SpriteBatch spriteBatch;
        private Vector2 textLocation;
        private Func.F<Action> draw;
        private SpriteFont font;

        public StateManager(Player p1, Player p2, Timer timer, SpriteBatch spriteBatch, Vector2 textLocation, SpriteFont font)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.timer = timer;
            this.spriteBatch = spriteBatch;
            this.textLocation = textLocation;
            this.font = font;
            draw = Func.getDrawFunc(spriteBatch);
        }

        public void win(Player p)
        {
            state = GameState.Over;
            winner = p;
            drawOver();
        }
        public void lose(Player p)
        {
            state = GameState.Over;
            winner = p1 == p
                ? p1
                : p2;
            drawOver();
        }
        public void update()
        {
            state = timer.update()
                ? GameState.Over
                : state;
        }
        public void Draw()
        {
            Func.safeDraw(spriteBatch, () => {
                timer.Draw(spriteBatch);
            });
        }
        public void drawOver()
        {
            String s = winner == null
                ? "It's a Tie!"
                : winner.name + "wins!";
            draw(() => spriteBatch.DrawString(font, s, textLocation, Color.White));
        }
    }
}
