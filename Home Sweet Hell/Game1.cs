﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        static int enemyNum; // current number of enemies      
        int level;
        int money;
        List<Enemy> enemies = new List<Enemy>(); // list of all enemies
        List<Tower> towers = new List<Tower>(); // list of all towers
        Player player = new Player(); // create player object
        private Tile startTile1 = null;//the tile that enemies spawn on for level 1
        private Tile startTile2 = null;//the tile that enemies spawn on for level 2
        private TowerPlacement tp;
        static int enemyCount = 0;//control variable to help enemy spawning
        static int enemyOnBoard = 0;
        bool isBought = false; // checks whether a tower is waiting to be placed or not
        private int enemiesKilled = 0; // counts number of enemies killed
        private int totalEnemiesKilled = 0; // total number of killed enemies

        // is the tower bought a knight or a lancer
        private bool isKnight;
        private bool isLancer;

        private int mX; // mouse x position
        private int mY; // mouse y position

        bool isThisPushing = true; //checks to see if sourceTree was being cooperative

        bool howToMenu = false; //is how to menu up?
        int howToPage = 1; //page should start at 1


        private GUI_StatGraphics mapGraph;
        private GUI_StatGraphics mapGraph2;
        private GUI_StatGraphics menuScreen;
        private GUI_StatGraphics howTo1;
        private GUI_StatGraphics howTo2;
        //private GUI_Anim towerGraph;
        //private GUI_Anim enemyGraph;
        private GUI_Anim[] towerGraphs;
        private GUI_Anim[] enemyGraphs;
        private Texture2D enemyImage;
        Texture2D towerImage;
        Texture2D lancerImage;
        Texture2D beeImage;
        private GUI_Anim[] towerGraphsPlaceholders;

        private GUI_StatGraphics listing1;
        private GUI_StatGraphics listing2;
        private GUI_StatGraphics listing3;
        private GUI_StatGraphics storeBack;
        private GUI_Anim boughtSym;

        public int[,] level1Tiles;
        public int[,] level2Tiles;
        Tile[,] level1MapTile;
        Tile[,] level2MapTile;


        // Mouse states used to track Mouse button press
        MouseState currentMouseState;
        MouseState previousMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 750;
            graphics.PreferredBackBufferHeight = 600;
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
            //towers.Add(new Knight_Good_(300, 100));
            level = 1;
            player.Health = 25;
            player.Points = 0;
            totalEnemiesKilled = 0;
            enemyNum = 10;
            enemies.Clear();
            towers.Clear();


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
            towerGraphs = new GUI_Anim[30];
            enemyGraphs = new GUI_Anim[75];
            towerGraphsPlaceholders = new GUI_Anim[2];


            //font
            font = Content.Load<SpriteFont>("Arial"); //TEMP FONT

            //menu screen
            Texture2D menuImage = Content.Load<Texture2D>("GUI_Assets/menuscreen.png");
            menuScreen = new GUI_StatGraphics(menuImage, new Point(750, 600), 1, 1, 1, new Vector2(0, 0));

            //how to
            Texture2D howToImg1 = Content.Load<Texture2D>("GUI_Assets/htp1.png");
            howTo1 = new GUI_StatGraphics(howToImg1, new Point(600, 400), 1, 1, 1, new Vector2(75, 50));
            Texture2D howToImg2 = Content.Load<Texture2D>("GUI_Assets/htp2.png");
            howTo2 = new GUI_StatGraphics(howToImg2, new Point(600, 400), 1, 1, 1, new Vector2(75, 50));

            //map                                                                                          
            Texture2D mapImage = Content.Load<Texture2D>("GUI_Assets/mapassets3type.png");
            Texture2D mapOverlay1 = Content.Load<Texture2D>("GUI_Assets/lv1_overlay.png");
            mapGraph = new GUI_StatGraphics(mapImage, mapOverlay1, new Point(150, 50), 3, 1, 3, "newExampleMap1.txt");
            mapGraph2 = new GUI_StatGraphics(mapImage, mapOverlay1, new Point(150, 50), 3, 1, 3, "FinalExampleMap2.txt");

            //tower                                                                                        
            towerImage = Content.Load<Texture2D>("GUI_Assets/towerplaceholder");
            lancerImage = Content.Load<Texture2D>("GUI_Assets/lancer");
            //enemy
            enemyImage = Content.Load<Texture2D>("GUI_Assets/enemyplaceholder");
            beeImage = Content.Load<Texture2D>("GUI_Assets/bees");

            towerGraphsPlaceholders[0] = new GUI_Anim(towerImage, new Point(100, 150), 6, 3, 2, 1000, 0);
            towerGraphsPlaceholders[1] = new GUI_Anim(lancerImage, new Point(100, 150), 6, 3, 2, 1000, 0);


            //listing                                                                                     
            Texture2D listingImage = Content.Load<Texture2D>("GUI_Assets/storelistingplaceholder");
            listing1 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(450, 500));
            listing2 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(550, 500));
            listing3 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(650, 500));
            //store                                                                                        
            Texture2D backStoreImage = Content.Load<Texture2D>("GUI_Assets/storebackplaceholder");
            storeBack = new GUI_StatGraphics(backStoreImage, new Point(750, 100), 1, 1, 1, new Vector2(0, 500));
            //bought
            Texture2D boughtImage = Content.Load<Texture2D>("GUI_Assets/bought");
            boughtSym = new GUI_Anim(boughtImage, new Point(25, 25), 1, 1, 1, 1, 0);

            #region Load Map 1
            StreamReader load1 = new StreamReader("newExampleMap1.txt");
            string line1;
            int tile1Row = 0;
            int tile1Column = 0;
            level1Tiles = new int[10, 15];
            level1MapTile = new Tile[10, 15];
            while ((line1 = load1.ReadLine()) != null)
            {
                if (line1 == "")//ignores the \n commands to split up rows in the array
                {
                    continue;
                }
                else
                {
                    char[] rowTiles = line1.ToCharArray();
                    foreach (char tile in rowTiles)
                    {
                        int type = 0;
                        string tileStr = tile.ToString();
                        int.TryParse(tileStr, out type);
                        level1Tiles[tile1Row, tile1Column] = type;
                        tile1Column++;
                    }
                    tile1Row++;
                    if (tile1Row > 9) //autobreaks if the loop exceeds number of rows in array
                    {
                        break;
                    }
                    tile1Column = 0;
                }
            }


            //converts recieved int array into tile array
            for (int row = 0; row < level1Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < level1Tiles.GetLength(1); column++)
                {
                    level1MapTile[row, column] = new Tile(row, column, 50, 50, level1Tiles[row, column]);
                }
            }

            //finds the start tile for the enemies 
            foreach (Tile obj in level1MapTile)
            {
                if (obj.TileValue == 2)
                {
                    startTile1 = obj;
                }
            }


            // values for first stage
            if (level == 1)
            {
                enemyNum = (level + 1) * 10 / 2;
                money = 1000;

            }
            #endregion

            #region Load Map 2
            StreamReader load2 = new StreamReader("FinalExampleMap2.txt");
            string line2;
            int tile2Row = 0;
            int tile2Column = 0;
            level2Tiles = new int[10, 15];
            level2MapTile = new Tile[10, 15];
            while ((line2 = load2.ReadLine()) != null)
            {
                if (line2 == "")//ignores the \n commands to split up rows in the array
                {
                    continue;
                }
                else
                {
                    char[] rowTiles = line2.ToCharArray();
                    foreach (char tile in rowTiles)
                    {
                        int type = 0;
                        string tileStr = tile.ToString();
                        int.TryParse(tileStr, out type);
                        level2Tiles[tile2Row, tile2Column] = type;
                        tile2Column++;
                    }
                    tile2Row++;
                    if (tile2Row > 9) //autobreaks if the loop exceeds number of rows in array
                    {
                        break;
                    }
                    tile2Column = 0;
                }
            }
            //converts recieved int array into tile array
            for (int row = 0; row < level2Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < level2Tiles.GetLength(1); column++)
                {
                    level2MapTile[row, column] = new Tile(row, column, 50, 50, level2Tiles[row, column]);
                }
            }

            //finds the start tile for the enemies 
            foreach (Tile obj in level2MapTile)
            {
                if (obj.TileValue == 2)
                {
                    startTile2 = obj;
                }
            }

            #endregion

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
                        //check to see if how-to screen is up
                        //if true 
                        //check to see if within coordinates of exit button
                        //else check if within coordinates of triangle
                        if (howToMenu == true)
                        {
                            if (currentMouseState.X >= 553 && currentMouseState.X <= 605 && currentMouseState.Y >= 65 && currentMouseState.Y <= 115)
                            {
                                howToMenu = false; //exit out of how-to
                            }
                            else if (currentMouseState.X >= 573 && currentMouseState.X <= 606 && currentMouseState.Y >= 393 && currentMouseState.Y <= 430)
                            {
                                if (howToPage == 1)
                                { howToPage = 2; /*switch */}
                                else
                                { howToPage = 1; }

                            }
                        }

                        //if false
                        // additional if statement here checking if mouse is within the coordinates of play button
                        // Another condition, for coordinates of how-to button
                        //
                        else
                        {
                            if (currentMouseState.X >= 475 && currentMouseState.X <= 700) //same x coordinates for each
                            {
                                if (currentMouseState.Y >= 368 && currentMouseState.Y <= 484)
                                {
                                    gameState = GameState.Game; //game start
                                }
                                else if (currentMouseState.Y >= 230 && currentMouseState.Y <= 341)
                                {
                                    howToMenu = true; //open how to menu
                                }
                            }
                        }



                    }
                    break;

                // code for main game -------------------------------------------------------------------
                case GameState.Game:
                    if (towers.Count == 0)
                    {
                        if (level <= 5)
                        {
                            tp = new TowerPlacement(currentMouseState.X, currentMouseState.Y, mapGraph);
                        }
                        else
                        if (level > 5)
                        {
                            tp = new TowerPlacement(currentMouseState.X, currentMouseState.Y, mapGraph2);
                        }

                    }

                    // mouse coordinate code
                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        // additional if statement here checking if mouse is within the coordinates of a clickable object

                        if (isBought == true)
                        {
                            tp.MX = currentMouseState.X;
                            tp.MY = currentMouseState.Y;
                            {

                                tp.MX = currentMouseState.X;
                                tp.MY = currentMouseState.Y;
                                tp.Done = tp.checkPosition();

                                if (tp.Done == true && isKnight == true) // if player clicks on proper tile, places tower and breaks out of loop
                                {
                                    Knight_Good_ tmpKnight = new Knight_Good_(currentMouseState.X - 26, currentMouseState.Y - 25);
                                    towers.Add(tmpKnight);
                                    isBought = false;
                                    isKnight = false;
                                    towerGraphs[towers.Count - 1] = new GUI_Anim(towerImage, new Point(100, 150), 6, 3, 2, 1000, 0);
                                }

                                else if (tp.Done == true && isLancer == true)
                                {
                                    Lancer tmpLancer = new Lancer(currentMouseState.X - 26, currentMouseState.Y - 25);
                                    towers.Add(tmpLancer);
                                    isBought = false;
                                    isLancer = false;
                                    towerGraphs[towers.Count - 1] = new GUI_Anim(lancerImage, new Point(100, 150), 6, 3, 2, 1000, 0);
                                }
                            }
                        }

                        // if mouseclick on knight tower in shop
                        if (currentMouseState.X >= 460 && currentMouseState.X <= 537 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590 && isBought == false) // compares mouseposition to the position of the new tower button
                        {
                            // checks if you have enough money
                            if (money >= 100)
                            {
                                mX = currentMouseState.X;
                                mY = currentMouseState.Y;
                                money -= 100;
                                isBought = true;
                                isKnight = true;
                            }
                        }

                        // if mouseclick on lancer tower in shop
                        if (currentMouseState.X >= 562 && currentMouseState.X <= 637 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590 && isBought == false && level > 5)
                        {
                            if (money >= 150)
                            {
                                mX = currentMouseState.X;
                                mY = currentMouseState.Y;
                                money -= 150;
                                isBought = true;
                                isLancer = true;
                            }
                        }


                        /*
                        if (currentMouseState.X >= 661 && currentMouseState.X <= 736 && currentMouseState.Y >= 505 && currentMouseState.Y <= 590 && isBought == false)
                        {
                            if (money >= towers[2].Cost)
                            {
                                towers.Add(towers[2]);
                                money -= towers[2].Cost;
                            }
                        }
                        */


                    }

                    // runs all enemy methods for each enemy
                    Tile[,] mapTile = new Tile[0, 0];
                    Tile startTile = null;

                    if (level <= 5)
                    {

                        mapTile = level1MapTile;
                        startTile = startTile1;
                    }
                    if (level > 5)
                    {

                        mapTile = level2MapTile;
                        startTile = startTile2;
                    }




                    //enemy position vector should be enemy position property from enemy class                     
                    //enemyGraph = new GUI_Anim(enemyImage, new Point(150, 50), 1, 1, 3, 1000, 1);
                    //beeGraph = new GUI_Anim(beeImage, new Point(150, 50), 1, 1, 3, 1000, 1);



                    if (level <= 5)
                    {
                        // adds enemyNum enemy knights to the enemies list
                        if (enemyCount < enemyNum)
                        {
                            Enemy e1 = new Knight_Bad_(startTile.Position.Y * 50, startTile.Position.X * 50);
                            int test = enemies.Count;
                            player.SpawnEnemies(enemies, e1);

                            if (enemies.Count == test + 1)
                            {
                                enemyOnBoard++;
                                enemyCount++;
                                enemyGraphs[enemyCount - 1] = new GUI_Anim(enemyImage, new Point(150, 50), 1, 1, 3, 1000, 1);
                            }
                        }
                    }
                    else if (level > 5)//spawns bees and knights 
                    {
                        if (enemyCount < enemyNum)
                        {
                            Enemy e1 = new Knight_Bad_(startTile.Position.Y * 50, startTile.Position.X * 50);
                            Enemy e2 = new Bee(startTile.Position.Y * 50, startTile.Position.X * 50);
                            int test = enemies.Count;
                            player.SpawnEnemies(enemies, e1);

                            if (enemies.Count == test + 1)
                            {
                                enemyOnBoard++;
                                enemyCount++;
                                enemyGraphs[enemyCount - 1] = new GUI_Anim(enemyImage, new Point(150, 50), 1, 1, 3, 1000, 1);
                            }

                            test = enemies.Count;
                            player.SpawnEnemies(enemies, e2);

                            if (enemies.Count == test + 1)
                            {
                                enemyOnBoard++;
                                enemyCount++;
                                enemyGraphs[enemyCount - 1] = new GUI_Anim(beeImage, new Point(150, 50), 1, 1, 3, 1000, 1);
                            }
                        }
                    }



                    /*  for (int u = 0; u < towers.Count; u++)
                      {
                          Enemy close = null;

                          if (enemies.Count != 0)
                          {
                              close = towers[u].IsClosest(enemies);
                          }

                          if (close != null)
                          {
                              close.TakeDamage(towers[u].Attack(close.Position), player);
                          }

                      }*/

                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Move(mapTile, player);

                        if (enemies[i].Previous != null)
                        {
                            Tile[] neighbors = enemies[i].Previous.GetNeighbors(mapTile);
                            foreach (Tile obj in neighbors)
                            {
                                if (obj != null)
                                {
                                    if (obj.Walkable == false && obj.TileValue == 3)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                    else if (obj.Walkable == false && obj.TileValue == 6)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                    else if (obj.Walkable == false && obj.TileValue == 2)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                }
                            }
                        }
                        for (int u = 0; u < towers.Count; u++)
                        {
                            int dmg = towers[u].Attack(enemies[i].Position);
                            enemies[i].TakeDamage(dmg, player);
                            if (dmg != 0)
                            {
                                towerGraphs[u].AttackAnim();
                            }

                        }


                        for (int j = 0; j < enemies.Count(); j++)
                        {
                            if (enemies[j].Alive == true)
                            {

                                enemyGraphs[j].Update(gameTime);
                            }
                        }
                        for (int j = 0; j < towers.Count(); j++)
                        {
                            towerGraphs[j].Update(gameTime);
                        }


                        if (enemies[i].Alive == false)
                        {
                            enemies[i].Previous.Refresh(mapTile);
                            Tile[] neighbors = enemies[i].Previous.GetNeighbors(mapTile);
                            foreach (Tile obj in neighbors)
                            {
                                if (obj != null)
                                {
                                    if (obj.Walkable == false && obj.TileValue == 3)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                    else if (obj.Walkable == false && obj.TileValue == 6)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                    else if (obj.Walkable == false && obj.TileValue == 2)
                                    {
                                        obj.Refresh(mapTile);
                                    }
                                }
                            }
                            enemies.Remove(enemies[i]);
                            enemyOnBoard--;
                            enemiesKilled++;
                            money = money + 50;
                        }

                    }

                    //each tower in towers
                    for (int i = 0; i < towers.Count(); i++)
                    {//currently doesn't check if tower is alive, need tower.alive property, and to actually assign a value to Alive at some point (currently not returning anything)
                     //if (tow.Alive == true)
                     //{
                        towerGraphs[i].switchAnim(towers[i].IsClosest(enemies));
                        //}
                    }



                    // beat the level
                    if (enemiesKilled == enemyNum)
                    {
                        totalEnemiesKilled += enemiesKilled;
                        gameState = GameState.Results; // shows current money and score
                        Nextlevel();
                    }

                    // you lose
                    if (player.Health <= 0)
                    {
                        enemies.Clear();
                        towers.Clear();
                        gameState = GameState.GameOver;
                    }
                    break;
                // ---------------------------------------------------------------------------------------

                // code for Results screen after successful level completion
                case GameState.Results: // commented out until level 2 is completed

                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        gameState = GameState.Game;
                    }

                    break;

                // code for Game Over
                case GameState.GameOver:

                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        player.Health = 25;
                        enemyNum = 10;
                        level = 1;
                        gameState = GameState.Title;
                    }
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
            //spriteBatch.DrawString(font, "Position: " + currentMouseState.X + ", " + currentMouseState.Y, new Vector2(0, 0), Color.Black);

            switch (gameState)
            {
                case GameState.Title:

                    menuScreen.StaticImage(1, 1, spriteBatch);

                    if (howToMenu == true)
                    {
                        if (howToPage == 1)
                        {
                            howTo1.StaticImage(1, 1, spriteBatch);
                        }
                        else if (howToPage == 2)
                        {
                            howTo2.StaticImage(1, 1, spriteBatch);
                        }

                    }

                    break;

                case GameState.Game:

                    if (isBought == true)
                    {
                        boughtSym.Draw(gameTime, spriteBatch, new Vector2(mX, mY));
                    }

                    //spriteBatch.DrawString(font, "Position: " + currentMouseState.X + ", " + currentMouseState.Y, new Vector2(800, 0), Color.Black); // displays current mouse position
                    //spriteBatch.DrawString(font, "Towers: " + towers.Count, new Vector2(800, 50), Color.Black); // displays current number of towers
                    //s//priteBatch.DrawString(font, "Enemies: " + enemies.Count, new Vector2(800, 100), Color.Black); // displays current number of enemies
                    
                    //spriteBatch.DrawString(font, "Bought: " + isBought, new Vector2(800, 200), Color.Black);
                    //.DrawString(font, "EnemyNum: " + enemyNum, new Vector2(800, 250), Color.Black);
                    //spriteBatch.DrawString(font, "EnemyCount: " + enemyCount, new Vector2(800, 300), Color.Black);
                    //map drawing
                    if (level <= 5)
                    {
                        mapGraph.MapDraw(spriteBatch);
                    }


                    if (level > 5)
                    {
                        mapGraph2.MapDraw(spriteBatch);
                    }


                    for (int i = 0; i < enemies.Count(); i++)
                    {
                        if (enemies[i].Alive == true)
                        {
                            enemyGraphs[i].Draw(gameTime, spriteBatch, new Vector2(enemies[i].Position.X, enemies[i].Position.Y));
                        }
                    }

                    //each tower in towers
                    for (int i = 0; i < towers.Count(); i++)
                    {//currently doesn't check if tower is alive, need tower.alive property, and to actually assign a value to Alive at some point (currently not returning anything)
                     //if (tow.Alive == true)
                     //{
                        towerGraphs[i].Draw(gameTime, spriteBatch, new Vector2(towers[i].Position.X, towers[i].Position.Y));
                        //}
                    }

                    //storedrawing                                                                                        
                    storeBack.StaticImage(0, 1f, spriteBatch);
                    listing1.StaticImage(1, .66f, spriteBatch);
                    listing2.StaticImage(1, .66f, spriteBatch);
                    listing3.StaticImage(1, .66f, spriteBatch);

                    towerGraphsPlaceholders[0].SizeChangeDraw(gameTime, spriteBatch, new Vector2(483, 555), 0.66f);

                    spriteBatch.DrawString(font, "Knight \n Price: $100",
                        new Vector2(465, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Lancer \n Price: $" + 150, //replace with price variable later       
                        new Vector2(565, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Advance to\nunlock\ntowers!", //replace with price variable later       
                        new Vector2(665, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);

                    if (level > 5)
                    {
                        towerGraphsPlaceholders[1].SizeChangeDraw(gameTime, spriteBatch, new Vector2(584, 555), 0.66f);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, " Unlock at \n lv.5",
                        new Vector2(565, 545), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
                    }

                    spriteBatch.DrawString(font, "Level: " + level,
                        new Vector2(665, 15), Color.White, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Health: " + player.Health, new Vector2(600, 470), Color.White);//displays Current Health
                    spriteBatch.DrawString(font, "Funds available: " + money,
                        new Vector2(10, 510), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
                    spriteBatch.DrawString(font, "Score: " + player.Points,
                        new Vector2(10, 535), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);

                    break;

                case GameState.GameOver:

                    spriteBatch.DrawString(font, "Game Over", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2-100), Color.Black);
                    spriteBatch.DrawString(font, "Score: "+player.Points, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 - 50), Color.Black);
                    spriteBatch.DrawString(font, "Total Enemies Killed: " + enemiesKilled, new Vector2(GraphicsDevice.Viewport.Width / 2-100, GraphicsDevice.Viewport.Height / 2), Color.Black);
                    break;

                case GameState.Results:

                    spriteBatch.DrawString(font, "Results:", new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, 100), Color.Black);
                    spriteBatch.DrawString(font, "Total Enemies Killed: " + totalEnemiesKilled, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, 150), Color.Black);
                    spriteBatch.DrawString(font, "Total Points: " + player.Points, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, 200), Color.Black);
                    spriteBatch.DrawString(font, "Current Money: $" + money, new Vector2(GraphicsDevice.Viewport.Width / 2 - 100, 250), Color.Black);
                    break;
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }

        // Gets data for the next stage
        public void Nextlevel()
        {
            level++; // increments level
            enemyNum = (level) * 10; //resets enemyNum   
            enemiesKilled = 0;
            enemyCount = 0;
            foreach (Tower obj in towers)
            {
                money = money + obj.Cost;
            }
            towers.Clear();
        }


    }
}
