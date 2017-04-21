﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Sweet_Hell
{
    /*
     * James Licata
     * Stephen Rhodenizer
     * Sophia Baker
     */
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        enum GameState { Title, Game, Results, GameOver }
        GameState gameState;
        int enemyNum; // current number of enemies      
        int level;
        int money;
        List<Enemy> enemies = new List<Enemy>(); // list of all enemies
        List<Tower> towers = new List<Tower>(); // list of all towers
        Player player = new Player(); // create player object
        private Tile startTile = null;//the tile that enemies spawn on
        int control = 0;//control variable to help enemy spawning


        private GUI_StatGraphics mapGraph;
        private GUI_Anim towerGraph;
        private GUI_Anim enemyGraph;
        private GUI_StatGraphics listing1;
        private GUI_StatGraphics listing2;
        private GUI_StatGraphics listing3;
        private GUI_StatGraphics storeBack;

        public int[,] tiles;
        Tile[,] mapTile;

        // Mouse states used to track Mouse button press
        MouseState currentMouseState;
        MouseState previousMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1050;
            graphics.PreferredBackBufferHeight = 750;
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
            towers.Add(new Knight_Good_(300,100));
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

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //GUI content----------------------------------------------------------------------------------//
            //font
            font = Content.Load<SpriteFont>("Arial"); //TEMP FONT

            //map                                                                                          
            Texture2D mapImage = Content.Load<Texture2D>("GUI_Assets/mapassets3type.png");
            mapGraph = new GUI_StatGraphics(mapImage, new Point(150, 50), 3, 1, 3, "newExampleMap1.txt");

            //tower                                                                                        
            Texture2D towerImage = Content.Load<Texture2D>("GUI_Assets/towerplaceholder");
            //tower position vector should be tower position property from tower class                     
            towerGraph = new GUI_Anim(towerImage, new Point(150, 50), 3, 1, 3, 1000);

            //enemy                                                                                        
            Texture2D enemyImage = Content.Load<Texture2D>("GUI_Assets/enemyplaceholder");
            //enemy position vector should be enemy position property from enemy class                     
            enemyGraph = new GUI_Anim(enemyImage, new Point(150, 50), 1, 1, 3, 1000);


            //listing                                                                                     
            Texture2D listingImage = Content.Load<Texture2D>("GUI_Assets/storelistingplaceholder");
            listing1 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(450, 500));
            listing2 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(550, 500));
            listing3 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(650, 500));
            //store                                                                                        
            Texture2D backStoreImage = Content.Load<Texture2D>("GUI_Assets/storebackplaceholder");
            storeBack = new GUI_StatGraphics(backStoreImage, new Point(750, 100), 1, 1, 1, new Vector2(0, 500));

            StreamReader load = new StreamReader("newExampleMap1.txt");
            string line;
            int tileRow = 0;
            int tileColumn = 0;
            tiles = new int[10, 15];
            mapTile = new Tile[10, 15];
            while ((line = load.ReadLine()) != null)
            {
                if (line == "")//ignores the \n commands to split up rows in the array
                {
                    continue;
                }
                else
                {
                    char[] rowTiles = line.ToCharArray();
                    foreach (char tile in rowTiles)
                    {
                        int type = 0;
                        string tileStr = tile.ToString();
                        int.TryParse(tileStr, out type);
                        tiles[tileRow, tileColumn] = type;
                        tileColumn++;
                    }
                    tileRow++;
                    if (tileRow > 9) //autobreaks if the loop exceeds number of rows in array
                    {
                        break;
                    }
                    tileColumn = 0;
                }
            }


            //converts recieved int array into tile array
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    mapTile[row, column] = new Tile(row, column, 50, 50, tiles[row, column]);
                }
            }

            //finds the start tile for the enemies 
            foreach (Tile obj in mapTile)
            {
                if (obj.TileValue == 2)
                {
                    startTile = obj;
                }
            }


            // values for first stage
            if (level == 1)
            {
                enemyNum = (level + 1) * 10 / 2;
                money = 1000;

                // adds enemyNum enemy knights to the enemies list
                for (int i = 0; i < enemyNum; i++)
                {
                    enemies.Add(new Knight_Bad_(startTile.Position.Y * 50, startTile.Position.X * 50));
                }

            }

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

                // code for main game -------------------------------------------------------------------
                case GameState.Game:

                    // mouse coordinate code
                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        // additional if statement here checking if mouse is within the coordinates of a clickable object
                        // if mouseclick on tower in shop
                        if (currentMouseState.X >= 460 && currentMouseState.X <= 537 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590) // compares mouseposition to the position of the new tower button
                        {
                            // checks if you have enough money
                            if (money >= towers[0].Cost)
                            {
                                towers.Add(towers[0]);
                                money -= towers[0].Cost;
                            }
                        }

                        if (currentMouseState.X >= 562 && currentMouseState.X <= 637 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590)
                        {
                            if (money >= towers[1].Cost)
                            {
                                towers.Add(towers[1]);
                                money -= towers[1].Cost;
                            }
                        }

                        if (currentMouseState.X >= 661 && currentMouseState.X <= 736 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590)
                        {
                            if (money >= towers[2].Cost)
                            {
                                towers.Add(towers[2]);
                                money -= towers[2].Cost;
                            }
                        }
                    }

                    //spawns enemies
                    /* if (control % 60 == 0)
                     {
                         // adds enemyNum enemy knights to the enemies list
                         if (enemyCount < enemyNum)
                         {
                             enemies.Add(new Knight_Bad_(startTile.Position.Y * 50, startTile.Position.X * 50));
                             enemyCount++;
                             return;
                         }
                     }*/



                    // runs all enemy methods for each enemy
                    try
                    {
                        foreach (var enemy in enemies)
                        {
                            enemy.Move(mapTile, player);
                            enemyGraph.Update(gameTime);

                            // checks if each enemy is in range of each tower
                            foreach (var tower in towers)
                            {
                                if (enemy.Alive == true)
                                {
                                    enemy.TakeDamage(tower.Attack(enemy.Position), player);
                                }
                                else
                                {
                                    enemies.Remove(enemy);
                                    enemyNum--;
                                }

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //does nothing when there aren't enemies in the enemy list
                    }
                    

                    // beat the level
                    /*if (enemyNum == 0) 
                    {
                        gameState = GameState.Results;
                        Nextlevel();
                    }
                    */
                    // you lose
                    if (player.Health <= 0)
                    {
                        gameState = GameState.GameOver;
                    }
                    break;
                // ---------------------------------------------------------------------------------------

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

            switch (gameState)
            {
                case GameState.Title:

                    spriteBatch.DrawString(font, "Titlescreen", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);
                    break;

                case GameState.Game:
                    spriteBatch.DrawString(font, "Position: " + currentMouseState.X + ", " + currentMouseState.Y, new Vector2(800, 0), Color.Black); // displays current mouse position
                    spriteBatch.DrawString(font, "Towers: " + towers.Count, new Vector2(800, 50), Color.Black); // displays current number of towers
                    spriteBatch.DrawString(font, "Enemies: " + enemies.Count, new Vector2(800, 100), Color.Black); // displays current number of enemies
                    spriteBatch.DrawString(font, "Health: " + player.Health, new Vector2(800, 150), Color.Black);//displays Current Health

                    //map drawing                                                                                         
                    mapGraph.MapDraw(spriteBatch);

                    //enemies+towers drawing  
                    if (enemies.Count != 0)
                    {
                        if (enemies[0].Alive == true)
                        {
                            enemyGraph.Draw(gameTime, spriteBatch, new Vector2(enemies[0].Position.X, enemies[0].Position.Y));
                        }
                    }
                   

                    towerGraph.Draw(gameTime, spriteBatch, new Vector2(towers[0].Position.X, towers[0].Position.Y));


                    //storedrawing                                                                                        
                    storeBack.StaticImage(0, 1f, spriteBatch);
                    listing1.StaticImage(1, .66f, spriteBatch);
                    listing2.StaticImage(1, .66f, spriteBatch);
                    listing3.StaticImage(1, .66f, spriteBatch);

                    spriteBatch.DrawString(font, "Knight \n Price: " + towers[0].Cost,
                        new Vector2(465, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Tower Name \n Price: " + 150, //replace with price variable later       
                        new Vector2(565, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Tower Name \n Price: " + 100, //replace with price variable later       
                        new Vector2(665, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);

                    spriteBatch.DrawString(font, "Level: " + level,
                        new Vector2(665, 15), Color.White, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Funds available: " + money,
                        new Vector2(10, 510), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Score: " + player.Points,
                        new Vector2(10, 535), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);

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
