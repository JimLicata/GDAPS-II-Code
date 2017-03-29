using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Home_Sweet_Hell
    //Stephen Rhodenizer
{
    class Enemy
    {
        //enemy attributes to inherit
        private int health;
        private int speed;
        private int sizeX;
        private int sizeY;
        private int positionX;
        private int positionY;
        private Rectangle position;
        private bool alive;
        private Texture2D image;
        private int score;
        private int control = 0;

        //properties for attributes
        public int Health
        {
            get { return health; }

            set
            {
                if (value < health && value > 0)
                {
                    health = value;
                }
            }
        }

        public int Speed
        {
            get { return speed; }

            set { speed = value; }
        }

        public int SizeX
        {
            get { return sizeX; }
        }

        public int SizeY
        {
            get { return sizeY; }
        }

        public int PositionX
        {
            get { return positionX; }

            set { positionX = value; }
        }

        public int PositionY
        {
            get { return positionY; }

            set { positionY = value; }
        }

        public Rectangle Position
        {
            get { return position; }

            set { position = value; }
        }

        public int Score
        {
            get { return score; }
        }

        public bool Alive
        {
            get { return alive; }

            set { alive = value; }
        }
        //constructor
        public Enemy(int hp, int sp, int w, int h, int x, int y,int scr)
        {
            health = hp;
            speed = sp;
            sizeX = w;
            sizeY = h;
            positionX = x;
            positionY = y;
            position = new Rectangle(new Point(x, y), new Point(w, h));
            alive = true;
            score = scr;
        }

        //take damage method
        public void TakeDamage(int dmg, Player p1)
        {
            int finalHealth = health - dmg;
            if (finalHealth > 0)
            {
                health = finalHealth;
            }
            else if (finalHealth <= 0)
            {
                alive = false;
                p1.Points = p1.Points + score;
            }

        }

        //override draw method so it only draws alive enemies
        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive == true)
            {
                spriteBatch.Draw(image);
            }
            else if (alive == false)
            {

            }
        }

        public void Move(Tile[,] map, int[,] tiles)//method to cause enemies to move toward the base
        {
            control++;
            if (control % 60 == 0)
            { switch (control)
                {
                    case 0: position = new Rectangle(new Point(position.X+50,position.Y), new Point(sizeX, sizeY));
                        break;
                    case 60:
                        position = new Rectangle(new Point(position.X + 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 120:
                        position = new Rectangle(new Point(position.X + 50, position.Y+50), new Point(sizeX, sizeY));
                        break;
                    case 180:
                        position = new Rectangle(new Point(position.X + 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 240:
                        position = new Rectangle(new Point(position.X + 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 300:
                        position = new Rectangle(new Point(position.X + 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 360:
                        position = new Rectangle(new Point(position.X + 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 420:
                        position = new Rectangle(new Point(position.X - 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 480:
                        position = new Rectangle(new Point(position.X - 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 540:
                        position = new Rectangle(new Point(position.X - 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 600:
                        position = new Rectangle(new Point(position.X - 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 660:
                        position = new Rectangle(new Point(position.X - 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 720:
                        position = new Rectangle(new Point(position.X - 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 780:
                        position = new Rectangle(new Point(position.X - 50, position.Y ), new Point(sizeX, sizeY));
                        break;
                    case 840:
                        position = new Rectangle(new Point(position.X - 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 900:
                        position = new Rectangle(new Point(position.X - 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 960:
                        position = new Rectangle(new Point(position.X + 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    case 1020:
                        position = new Rectangle(new Point(position.X + 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 1080:
                        position = new Rectangle(new Point(position.X + 50, position.Y), new Point(sizeX, sizeY));
                        break;
                    case 1140:
                        position = new Rectangle(new Point(position.X + 50, position.Y + 50), new Point(sizeX, sizeY));
                        break;
                    
                }
            }
            
        }

        public void Breach(Player p1,Tile[,] map, int[,] tiles)//if the enemy isn't killed in time it damages the player
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    if (position.Intersects(map[row, column].Position) == true)
                    {
                        if (map[row, column].TileValue == 6)
                        {
                            alive = false;
                            p1.Health = p1.Health - 1;

                        }
                    }
                }
            }
        }
    }
}
