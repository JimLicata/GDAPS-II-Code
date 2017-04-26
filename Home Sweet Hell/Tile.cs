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
    class Tile
    {
        //needed attributes
        Rectangle position;
        int tileValue;
        bool walkable;
        public Tile[] neighbors;

        //constructor
        public Tile(int posX, int posY, int sizeX, int sizeY, int value)
        {
            position = new Rectangle(new Point(posX, posY), new Point(sizeX, sizeY));
            tileValue = value;
            if (tileValue > 1 && tileValue <= 6)
            {
                walkable = true;
            }
            else
            {
                walkable = false;
            }
        }

        //properties
        public Rectangle Position
        {
            get { return position; }

            set { position = value; }
        }

        public int TileValue
        {
            get { return tileValue; }

            set { tileValue = value; }
        }

        public Tile[] Neighbors
        {
            get { return neighbors; }
        }

        public bool Walkable
        {
            get { return walkable; }

            set { walkable = value; }
        }

        //checks to see if the tile is part of the enemy path
        public void IsWalkable()
        {
            if (tileValue > 1 && tileValue <= 6)
            {
                walkable = true;
            }
            else
            {
                walkable = false;
            }
        }

        //checks to see if the tile is the next one in the enemy path
        public bool IsNext(Tile obj)
        {
            
                if (obj.tileValue == tileValue + 1)
                {
                    return true;
                }
                else
                if (obj.tileValue == 5 && tileValue == 3)
                {
                    return true;
                }
                else
                if (obj.tileValue == 6 && tileValue > 2)
                {
                    return true;
                }
                else { return false; }
            
        }

        //gets adjacent tiles
        //neighbor[0] = up
        //neighbor[1] = down 
        //neighbor[2] = left
        //neighbor[3] = right
        public Tile[] GetNeighbors(Tile[,] map)
        {
            List<Tile> nList = new List<Tile>();
            try
            {
                nList.Add(map[position.X , position.Y +1]);
            }
            catch (IndexOutOfRangeException)
            {
                nList.Add(null);
            }

            try
            {
                nList.Add(map[position.X , position.Y -1]);
            }
            catch (IndexOutOfRangeException)
            {
                nList.Add(null);
            }

            try
            {
                nList.Add(map[position.X +1, position.Y ]);
            }
            catch (IndexOutOfRangeException)
            {
                nList.Add(null);
            }

            try
            {
                nList.Add(map[position.X -1, position.Y ]);
            }
            catch (IndexOutOfRangeException)
            {
                nList.Add(null);
            }
            neighbors = nList.ToArray();
            return neighbors;
        }
        
    }
}
