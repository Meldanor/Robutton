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
        private Coin;

        public Robutton()
        {
            Direction = 
        }
    }
}
