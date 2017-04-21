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
    class Knight_Bad_ : Enemy
    {
      

        //constructor
        public Knight_Bad_(int x, int y) : base(100, 5, 50, 50, x, y, 100)
        {
        }

        //where you put enemy specific code
    }
}
