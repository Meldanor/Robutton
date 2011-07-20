/*
* Copyright (C) 2011 Kilian Gaertner
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program. If not, see <http://www.gnu.org/licenses/>.
*/

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
                while(value >= 360.0)
                    value -= 360.0;
                while (value < 0.0)
                    value += 360.0; 
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

        public void Move(Game game)
        {
            // calculate the next x and y coordinate by using the formula : xNew = xOld + cos(angle)
            //                                                              yNew = yOld + sin(angle)
            // Look at trigonometrical functions and their definition
            int x = (int)Math.Round(Math.Cos(ToRad(Direction))) + X;
            int y = (int)Math.Round(Math.Sin(ToRad(Direction))) + Y;

            // Will be the Robutton leave the game field? If yes, it shall reflect
            int borderCollision = game.IsOnTheField(x, y);
            if (borderCollision != Game.ON_THE_FIELD)
            {
                ReflectFromBorder(borderCollision);
                // need to recalculate the Coordinates
                X = (int)Math.Round(Math.Cos(ToRad(Direction))) + X;
                Y = (int)Math.Round(Math.Sin(ToRad(Direction))) + Y;
                return;
            }

            // Will the Robutton collide with some other robutton or coin
            Unit possibleCollision = game.IsThereAnUnit(x, y);
            if (possibleCollision != null)
            {
                // The unit is another Robutton
                if (possibleCollision is Robutton)
                {
                    Robutton otherRobutton = (Robutton)possibleCollision;
                    RotateAfterContact();
                    otherRobutton.RotateAfterContact();
                }
                // The unit is a coin
                else
                {
                    if (Coin == null)
                    {
                        // pick up the coin
                        Coin = possibleCollision;
                        game.Coins.Remove(Coin);
                    }
                    else
                    {
                        // drop the coin in front of the found coin
                        Coin.X = this.X;
                        Coin.Y = this.Y;
                        game.Coins.Add(Coin);
                        Coin = null;
                        // rotate up to 180 degree
                        Direction = Direction + 180;
                    }
                }
                // need to recalculate the Coordinates
                X = (int)Math.Round(Math.Cos(ToRad(Direction))) + X;
                Y = (int)Math.Round(Math.Sin(ToRad(Direction))) + Y;
                return;
            }

            // if everything is ok, the robutton moves to the calculated coordinates
            X = x;
            Y = y;
        }

        // Copyright (C) to Landei from java-forums.org for the solution
        private void ReflectFromBorder(int borderCollision)
        {
            if (borderCollision == Game.TRESPASS_RIGHT_OR_LEFT_BORDER)
                Direction = 180 - Direction;
            else if (borderCollision == Game.TRESPASS_UPPER_OR_BUTTOM_BORDER)
                Direction = 360 - Direction;
        }

        /// <summary>
        /// When a Robutton has contact with another Robutton both will rotate up to 180° and
        /// rotate up to a random angle between 90° and -90°.
        /// </summary>
        public void RotateAfterContact()
        {
            Direction = Direction + 180;
            Random rand = new Random();
            if (rand.Next(2) == 0)
                Direction = Direction + rand.Next(0, 91);
            else
                Direction = Direction - rand.Next(0, 91);
        }

        private double ToDeg(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        private double ToRad(double degrees)
        {
            return Math.PI / 180 * degrees;
        }
    }
}
