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

        //checks to see if the tile is part of the enemy path
        public bool IsWalkable()
        {
            if (tileValue > 1 && tileValue < 6)
            {
                walkable = true;
                return true;
            }
            else
            {
                walkable = false;
                return false;
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
        public Tile[] GetNeighbors(Tile[,] map, int x, int y)
        {
            Tile space = map[x, y];
            neighbors = new Tile[] 
            {
                map[x,y+1],
                map[x,y-1],
                map[x-1,y],
                map[x+1,y]
            };
            return neighbors;
        }
        
    }
}
