using GameHack.Items;
using GameHack.Register;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameHack
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        MouseState mouseState;
        MainField mainField;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Panel panel;
        ItemFactory factory;

        Background background;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            background = new Background(GraphicsDevice);
            panel = new Panel(GraphicsDevice);
            factory = new ItemFactory(panel, GraphicsDevice, new Rectangle());
            mainField = new MainField(GraphicsDevice);
            this.mouseState = Mouse.GetState();
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
            background.LoadContent(Content, spriteBatch);
            mainField.LoadContent(Content, spriteBatch);
            panel.LoadContent(Content, spriteBatch);
            factory.LoadContent(Content, spriteBatch);
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
            // TODO: Add your update logic here
            this.mouseState = Mouse.GetState();
            background.Update(gameTime);
            mainField.Update(gameTime);
            panel.Update(gameTime);
            factory.RightMouseClick(mouseState);
            factory.LeftMouseClick(mouseState);
            factory.MouseMove(mouseState);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);
            // TODO: Add your drawing code here
            background.Draw();
            mainField.Draw();
            panel.Draw();
            factory.Draw();
            base.Draw(gameTime);
        }
    }
}
