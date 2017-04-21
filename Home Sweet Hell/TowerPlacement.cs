using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// James Licata
namespace Home_Sweet_Hell
{
    class TowerPlacement
    {
        private int mX; // current mouse state x
        private int mY; // current mouse state y
        private bool done; // if player clicks on a valid tile
        private int[] mapInts;
        GUI_StatGraphics map;

        // properties
        public bool Done 
        {
            get { return done; }
            set { done = value; }
        }

        public TowerPlacement(int mouseX, int mouseY, object mapGraph)
        {
            mX = mouseX;
            mY = mouseY;
            map = (GUI_StatGraphics)mapGraph; // cast mapGraph object back into a class
            mapInts = map.MapInts;
        }

        public int MX
        {
            set { mX = value; }
        }

        public int MY
        {
            set { mY = value; }
        }

       /*
        * public bool checkPosition()
        {
            if(mX >= 50 && mX < 100)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[16] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[31] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[46] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[61] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[76] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[91] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[106] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[121] == 1)
                        return true;

                    else return false;
                }
            }
            return false;
        }
        */

        public bool checkPosition(Tile[,] map, List<Tower> towers, int mX, int mY)
        {
            foreach (var tile in map)
            {
                if (tile.TileValue == 1)
                {
                    foreach (var tower in towers)
                    {
                        if (tower.Position.X == mX && tower.Position.Y == mY)
                        {
                            return false;
                        }
                        else return true;
                    }
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}
