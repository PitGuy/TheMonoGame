using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameHack.BackgroundElements;
using GameHack.Interfaces;
using System.Collections.Generic;
using GameHack.Buttons;
using GameHack.GameElement;

namespace GameHack
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameLevel : Game
    {
        Background backgroud;
        Planet planet;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameLevel()
        {
            List<IGameObject> bgElements = new List<IGameObject>();
            bgElements.Add(new Stars());
            bgElements.Add(new RunButton());
            bgElements.Add(new SunButton());
            bgElements.Add(new ExitButton());
            bgElements.Add(Panel.GetInstance());
            backgroud = new Background(bgElements);
            planet = new Planet();
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroud.LoadContent(Content);
            planet.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            backgroud.Update(gameTime);
            ElementBuffer.GetInstance().Update(gameTime);
            planet.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            backgroud.Draw(spriteBatch);
            planet.Draw(spriteBatch);
            ElementBuffer.GetInstance().Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
