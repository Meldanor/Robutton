using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robutton
{
    class Robutton : Unit
    {
        private double direction;
        public double Direction 
        {
            get
            {
                return direction;
            }
            set
            {
                while(value >= 360)
                    value -= 360;
                direction = value;
            }
        }
        private Unit coin;
        public Unit Coin
        {
            get
            {
                return coin;
            }
            set
            {
                coin = value;
            }
        }

        public Robutton(int x, int y, int direction)
            : base(x,y)
        {
            Direction = direction;
        }
    }
}
