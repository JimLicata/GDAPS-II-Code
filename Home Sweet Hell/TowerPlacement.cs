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
        GUI_StatGraphics map;
        private int[] mapInts;
        

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
                        mapInts[16] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150) // second row
                {
                    if (mapInts[31] == 1)
                    {
                        mapInts[31] = 0;
                        return true;
                    }
                        

                    else return false;
                }

                else if (mY >= 150 && mY < 200) // third row etc.
                {
                    if (mapInts[46] == 1)
                    {
                        mapInts[46] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[61] == 1)
                    {
                        mapInts[61] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[76] == 1)
                    {
                        mapInts[76] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[91] == 1)
                    {
                        mapInts[91] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[106] == 1)
                    {
                        mapInts[106] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[121] == 1)
                    {
                        mapInts[121] = 0;
                        return true;
                    }
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
                        mapInts[17] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[32] == 1)
                    {
                        mapInts[32] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[47] == 1)
                    {
                        mapInts[47] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[62] == 1)
                    {
                        mapInts[62] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[77] == 1)
                    {
                        mapInts[77] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[92] == 1)
                    {
                        mapInts[92] = 0;
                        return true;
                    }

                    else return false;
                }
// continue from here
                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[107] == 1)
                    {
                        mapInts[107] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[122] == 1)
                    {
                        mapInts[122] = 0;
                        return true;
                    }
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
                        mapInts[18] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[33] == 1)
                    {
                        mapInts[33] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[48] == 1)
                    {
                        mapInts[48] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[63] == 1)
                    {
                        mapInts[63] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[78] == 1)
                    {
                        mapInts[78] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[93] == 1)
                    {
                        mapInts[93] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[108] == 1)
                    {
                        mapInts[108] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[123] == 1)
                    {
                        mapInts[123] = 0;
                        return true;
                    }

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
                        mapInts[19] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[34] == 1)
                    {
                        mapInts[34] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[49] == 1)
                    {
                        mapInts[49] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[64] == 1)
                    {
                        mapInts[64] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[79] == 1)
                    {
                        mapInts[79] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[94] == 1)
                    {
                        mapInts[94] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[109] == 1)
                    {
                        mapInts[109] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[124] == 1)
                    {
                        mapInts[124] = 0;
                        return true;
                    }

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
                        mapInts[20] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[35] == 1)
                    {
                        mapInts[35] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[50] == 1)
                    {
                        mapInts[50] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[65] == 1)
                    {
                        mapInts[65] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[80] == 1)
                    {
                        mapInts[80] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[95] == 1)
                    {
                        mapInts[95] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[110] == 1)
                    {
                        mapInts[110] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[125] == 1)
                    {
                        mapInts[125] = 0;
                        return true;
                    }

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
                        mapInts[21] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[36] == 1)
                    {
                        mapInts[36] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[51] == 1)
                    {
                        mapInts[51] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[66] == 1)
                    {
                        mapInts[66] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[81] == 1)
                    {
                        mapInts[81] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[96] == 1)
                    {
                        mapInts[96] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[111] == 1)
                    {
                        mapInts[111] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[126] == 1)
                    {
                        mapInts[126] = 0;
                        return true;
                    }

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
                        mapInts[22] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[37] == 1)
                    {
                        mapInts[37] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[52] == 1)
                    {
                        mapInts[52] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[67] == 1)
                    {
                        mapInts[67] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[82] == 1)
                    {
                        mapInts[82] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[97] == 1)
                    {
                        mapInts[97] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[112] == 1)
                    {
                        mapInts[112] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[127] == 1)
                    {
                        mapInts[127] = 0;
                        return true;
                    }

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
                        mapInts[23] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[38] == 1)
                    {
                        mapInts[38] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[53] == 1)
                    {
                        mapInts[53] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[68] == 1)
                    {
                        mapInts[68] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[83] == 1)
                    {
                        mapInts[83] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[98] == 1)
                    {
                        mapInts[98] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[113] == 1)
                    {
                        mapInts[113] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[128] == 1)
                    {
                        mapInts[128] = 0;
                        return true;
                    }

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
                        mapInts[24] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[39] == 1)
                    {
                        mapInts[39] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[54] == 1)
                    {
                        mapInts[54] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[69] == 1)
                    {
                        mapInts[69] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[84] == 1)
                    {
                        mapInts[84] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[99] == 1)
                    {
                        mapInts[99] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[114] == 1)
                    {
                        mapInts[114] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[129] == 1)
                    {
                        mapInts[129] = 0;
                        return true;
                    }

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
                        mapInts[25] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[40] == 1)
                    {
                        mapInts[40] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[55] == 1)
                    {
                        mapInts[55] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[70] == 1)
                    {
                        mapInts[70] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[85] == 1)
                    {
                        mapInts[85] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[100] == 1)
                    {
                        mapInts[100] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[115] == 1)
                    {
                        mapInts[115] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[130] == 1)
                    {
                        mapInts[130] = 0;
                        return true;
                    }

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
                        mapInts[26] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[41] == 1)
                    {
                        mapInts[41] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[56] == 1)
                    {
                        mapInts[56] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[71] == 1)
                    {
                        mapInts[71] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[86] == 1)
                    {
                        mapInts[86] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[101] == 1)
                    {
                        mapInts[101] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[116] == 1)
                    {
                        mapInts[116] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[131] == 1)
                    {
                        mapInts[131] = 0;
                        return true;
                    }

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
                        mapInts[27] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[42] == 1)
                    {
                        mapInts[42] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[57] == 1)
                    {
                        mapInts[57] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[72] == 1)
                    {
                        mapInts[72] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[87] == 1)
                    {
                        mapInts[87] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[101] == 1)
                    {
                        mapInts[101] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[117] == 1)
                    {
                        mapInts[117] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[132] == 1)
                    {
                        mapInts[132] = 0;
                        return true;
                    }

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
                        mapInts[28] = 0;
                        return true;
                    }
                    else return false;
                }

                else if (mY >= 100 && mY < 150)
                {
                    if (mapInts[43] == 1)
                    {
                        mapInts[43] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 150 && mY < 200)
                {
                    if (mapInts[58] == 1)
                    {
                        mapInts[58] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 200 && mY < 250)
                {
                    if (mapInts[73] == 1)
                    {
                        mapInts[73] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 250 && mY < 300)
                {
                    if (mapInts[88] == 1)
                    {
                        mapInts[88] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 300 && mY < 350)
                {
                    if (mapInts[102] == 1)
                    {
                        mapInts[102] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 350 && mY < 400)
                {
                    if (mapInts[118] == 1)
                    {
                        mapInts[118] = 0;
                        return true;
                    }

                    else return false;
                }

                else if (mY >= 400 && mY < 450)
                {
                    if (mapInts[133] == 1)
                    {
                        mapInts[133] = 0;
                        return true;
                    }

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
