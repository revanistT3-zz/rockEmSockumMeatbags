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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p1;
        Player p2;
        Timer timer;
        GameState state;
        Player winner = null;
        SpriteFont font;
        Projectile testproj;

        public void playing()
        {
            state = timer.update()
                ? GameState.Over
                : state;
        }
        public void drawPlaying()
        {
            p1.drawHud(spriteBatch, new Rectangle(10, 0, 300, 30));
            p2.drawHud(spriteBatch, new Rectangle(GraphicsDevice.Viewport.Width - 310, 0, 300, 30));
            timer.Draw(spriteBatch, new Vector2(GraphicsDevice.Viewport.Width / 2, 0));
        }
        public static void safeDraw(SpriteBatch spriteBatch, Action f)
        {
            spriteBatch.Begin();
            f();
            spriteBatch.End();
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1300;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            testproj = new Projectile(Content, 10, 5, 100, 50, 50, 1, "ball");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            timer = new Timer(this.Content);
            p1 = new Player(this.Content, 50, 50, 50, "left player", 50,1);
            //p1.load;
            p2 = new Player(this.Content, 50, 50, 50, "right player", 50,1);
            font = this.Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           
            switch (state)
            {
                case GameState.Paused:

                    break;
                case GameState.Playing:
                    playing();
                    break;

            }


            testproj.animate(gameTime, "ball");
             testproj.goRight();
             if (testproj.endX(300) == true)
             {
                 Dispose();
             }
             

             

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        void win(Player p)
        {
            state = GameState.Over;
            winner = p;
        }
        void lose(Player p)
        {
            state = GameState.Over;
            winner = p1 == p
                ? p1
                : p2;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            
           


            
            // TODO: Add your drawing code here
            switch (state)
            {
                case GameState.Paused:
                    break;
                case GameState.Playing:
                    drawPlaying();
                    break;
                case GameState.Over:
                    safeDraw(spriteBatch, () => {
                        //spriteBatch.DrawString(font, winner., );
                    });
                    break;
            }
            base.Draw(gameTime);
            testproj.draw(spriteBatch);
        }

        public ContentManager content { get; set; }
    }
}
