using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Sweet_Hell
    //Stephen Rhodenizer
{
    class Player
    {
        //attributes 
        private int health;
        private int points;
        private int control = 0;

        //property
        public int Health
        {
            get { return health; }

            set
            {
                if (value >= 0 && value < 100)
                {
                    health = value;
                }
            }
        }
        public int Points
        {
            get { return points; }

            set { points = value; }
        }

        //constructor 
        public Player()
        {
            health = 50;
            points = 0;
        }

        public void SpawnEnemies(List<Enemy> enemies, Enemy villan)
        {
            control++;
            if (control % 60 == 0)
            {
                enemies.Add(villan);
            }
        }
    }
}
