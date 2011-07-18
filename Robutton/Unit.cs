using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robutton
{
    public abstract class Unit
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
