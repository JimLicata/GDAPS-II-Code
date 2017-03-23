using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Sweet_Hell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        enum GameState { Title, Game, Results, GameOver}
        GameState gameState;
        int enemyNum; // current number of enemies      
        int level;
        int money;
        List<Map> maps = new List<Map>(); // list of all the maps
        List<Enemy> enemies = new List<Enemy>(); // list of all enemies
        List<Tower> towers = new List<Tower>(); // list of all towers
        Player player = new Player(); // create player object
        Enemy bKnight; // create enemy knight
        Tower gKnight; // create tower knight


        // initializes map
        Map map = new Map();

        // Mouse states used to track Mouse button press
        MouseState currentMouseState;
        MouseState previousMouseState;

        // texture hight and width dimensions
        private int txtHeight = 32; // placeholder value
        private int txtWidth = 32; // placeholder value

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // draws a window that is multiplied by texture dimensions to ensure that thw window is large enough
            graphics.PreferredBackBufferWidth = map.Width * txtWidth;
            graphics.PreferredBackBufferHeight = map.Height * txtHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;
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
            // initialize each enemy and tower
            bKnight = new Knight_Bad_();
            gKnight = new Knight_Good_();
            level = 1;
            


            gameState = GameState.Title;

            


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

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("mainFont");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Get Mouse State then Capture the Button type and Respond Button Press
            Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            switch (gameState)
            {
                // code for initial screen
                case GameState.Title:

                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        // additional if statement here checking if mouse is within the coordinates of a button
                        gameState = GameState.Game;
                    }
                    break;

                // code for main game 
                case GameState.Game:

                    // values for first stage
                    if (level == 1) 
                    {
                        enemyNum = 10;
                        money = 1000;

                        // adds enemyNum enemy knights to the enemies list
                        for (int i = 0; i < enemyNum; i++)
                        {
                            enemies.Add(bKnight);
                        }
                    }

                    // mouse coordinate code
                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        // additional if statement here checking if mouse is within the coordinates of a clickable object
                        // if mouseclick on tower in shop
                        if (currentMouseState.X == 0 && currentMouseState.Y == 0) // compares mouseposition to the position of the new tower button
                        {
                            // checks if you have enough money
                            if (money >= gKnight.Cost)
                            {
                                towers.Add(gKnight);
                                money -= gKnight.Cost;
                            }
                        }
                        
                    }

                    // beat the level
                    if (enemyNum == 0) 
                    {
                        gameState = GameState.Results;
                        Nextlevel();
                    }

                    // you lose
                    if (player.Health <= 0) 
                    {
                        gameState = GameState.GameOver;
                    }
                    break;

                // code for Results screen after successful level completion
                case GameState.Results:
                    // shows player score, money
                    break;

                // code for Game Over
                case GameState.GameOver:
                    // 
                    break;

            }

            // if mouse is clicked, check cooridnates
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                // additional if statement here checking if mouse is within the coordinates of a button
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Position: " + currentMouseState.X + ", " + currentMouseState.Y, new Vector2(0, 0), Color.Black);

            switch(gameState)
            {
                case GameState.Title:
                    spriteBatch.DrawString(font, "Titlescreen", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);
                    break;
            }
                

            spriteBatch.End();
            base.Draw(gameTime);
        }

        // Gets data for the next stage
        public void Nextlevel()
        {
            level++; // increments level
            // enemyNum = some number

            
        }

        
    }
}
