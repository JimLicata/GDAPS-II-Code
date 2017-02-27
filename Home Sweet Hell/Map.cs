using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Generic Map class
namespace Home_Sweet_Hell
{
    class Map
    {
        // height and length of map array
        private int width = 32; // placeholder value
        private int height = 32; // placeholder value

        // constructor
        public Map()
        {
           
        }

        // properties for height and width
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }
    }
}
