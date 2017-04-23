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

        // very long and ugly but it will work for any map configuration as long as map dimensions are consistent
        public bool checkPosition()
        {
            // first column
            if (mX >= 50 && mX < 100) 
            {
                if (mY >= 50 && mY < 100) // first row
                {
                    if (mapInts[16] == 1) // is this a tower placeable tile?
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150) // second row
                {
                    if (mapInts[31] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200) // third row etc.
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

            // second column
            else if (mX >= 100 && mX < 150)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[17] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[32] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[47] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[62] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[77] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[92] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[107] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[122] == 1)
                        return true;

                    else return false;
                }
            }

            // third column
            else if (mX >= 150 && mX < 200)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[18] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[33] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[48] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[63] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[78] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[93] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[108] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[123] == 1)
                        return true;

                    else return false;
                }
            }

            // fourth column
            else if (mX >= 200 && mX < 250)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[19] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[34] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[49] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[64] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[79] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[94] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[109] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[124] == 1)
                        return true;

                    else return false;
                }
            }

            // fifth column
            else if (mX >= 250 && mX < 300)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[20] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[35] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[50] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[65] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[80] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[95] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[110] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[125] == 1)
                        return true;

                    else return false;
                }
            }

            // sixth column
            else if (mX >= 300 && mX < 350)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[21] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[36] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[51] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[66] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[81] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[96] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[111] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[126] == 1)
                        return true;

                    else return false;
                }
            }

            // seventh column
            else if (mX >= 350 && mX < 400)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[22] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[37] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[52] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[67] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[82] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[97] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[112] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[127] == 1)
                        return true;

                    else return false;
                }
            }

            // eighth column
            else if (mX >= 400 && mX < 450)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[23] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[38] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[53] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[68] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[83] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[98] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[113] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[128] == 1)
                        return true;

                    else return false;
                }
            }

            // ninth column
            else if (mX >= 450 && mX < 500)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[24] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[39] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[54] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[69] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[84] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[99] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[114] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[129] == 1)
                        return true;

                    else return false;
                }
            }

            // tenth column
            else if (mX >= 500 && mX < 550)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[25] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[40] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[55] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[70] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[85] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[100] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[115] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[130] == 1)
                        return true;

                    else return false;
                }
            }

            // eleventh column
            else if (mX >= 550 && mX < 600)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[26] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[41] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[56] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[71] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[86] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[101] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[116] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[131] == 1)
                        return true;

                    else return false;
                }
            }

            // twelvth column
            else if (mX >= 600 && mX < 650)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[27] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[42] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[57] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[72] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[87] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[101] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[117] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[132] == 1)
                        return true;

                    else return false;
                }
            }

            // thirteenth column
            else if (mX >= 650 && mX < 700)
            {
                if (mY >= 50 && mY < 100)
                {
                    if (mapInts[28] == 1)
                    {
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[43] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[58] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[73] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[88] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[102] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[118] == 1)
                        return true;

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[133] == 1)
                        return true;

                    else return false;
                }
            }
            return false;
        }
        

        /*public bool checkPosition(Tile[,] map, List<Tower> towers, int mX, int mY)
        {
            done = false;
            foreach (var tile in map)
            {
                if (tile.TileValue == 1)
                {
                    foreach (var tower in towers)
                    {
                        if (tower.Position.X == mX && tower.Position.Y == mY)
                        {
                            done = false;
                        }
                        else done = true;
                    }
                    done = true;
                }
                else done = false;
            }
            return done;
        }*/

    }
}
