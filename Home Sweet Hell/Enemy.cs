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
        private int score;
        private int control = 0;
        private int spawnRate = 0;


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

        public int SpawnRate
        {
            get { return spawnRate; }
        }


        //constructor
        public Enemy(int hp, int sp, int w, int h, int x, int y, int scr)
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

        public void Move(Tile[,] map, Player p1)//method to cause enemies to move toward the base
        {
            control++;

            if (control % 60 == 0)
            {
                foreach (Tile obj in map)
                {

                    if (position.X == obj.Position.Y * 50 && position.Y == obj.Position.X * 50)
                    {
                        if (obj.TileValue == 6)
                        {
                            alive = false;
                            p1.Health = p1.Health - 1;
                        }
                        obj.GetNeighbors(map);

                        foreach (Tile next in obj.Neighbors)
                        {
                            if (next != null)
                            {
                                if (next.Walkable == true)
                                {
                                    position = new Rectangle(new Point(next.Position.Y * 50, next.Position.X * 50), new Point(50, 50));

                                    next.Walkable = false;
                                    obj.Walkable = false;
                                    return;
                                }
                            }

                        }

                    }
                }

            }
        }

    }

}
