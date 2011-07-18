using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robutton
{
    public class Unit
    {
        public Unit()
        {
        }

        public Unit(int x, int y)
        {
            X = x;
            Y = y;
        }

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
        public bool HasSameLocation(Unit other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
