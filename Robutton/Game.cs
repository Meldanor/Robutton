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

using System.Collections.Generic;
using System;

namespace Robutton
{
    public class Game
    {
        private List<Robutton> robuttons;
        private List<Unit> coins;
        private int xSize;
        private int ySize;

        public Game()
            : this(5, 5, 400, 400){}

        public Game(int robuttons, int coins)
            : this(robuttons,coins,400,400){}

        public Game(int robuttons, int coins, int xSize, int ySize)
        {
            Robuttons = new List<Robutton>(robuttons);
            Coins = new List<Unit>(coins);
            this.xSize = xSize;
            this.ySize = ySize;
            GenerateGame();
        }

        public Game(List<Robutton> robuttons, List<Unit> coins, int xSize, int ySize)
        {
            Robuttons = robuttons;
            Coins = coins;
            this.xSize = xSize;
            this.ySize = ySize;
            GenerateGame();
        }

        public void GenerateGame()
        {
            // generate the robuttons
            for (int i = 0 ; i < Robuttons.Count; ++i) {
                int x = new Random().Next(XSize);
                int y = new Random().Next(YSize);
                int direction = new Random().Next(360);
                Robutton robu = new Robutton(x,y,direction);
                for (int j = 0 ; j < i ; ++j) {
                    Robutton tempRobu = Robuttons[j];
                    if (robu.HasSameLocation(tempRobu))
                    {
                        --i;
                        break;
                    }
                }
                Robuttons.Add(robu);
            }
            // generate the coin positions
            for (int i = 0; i < Coins.Count; ++i)
            {
                int x = new Random().Next(XSize);
                int y = new Random().Next(YSize);
                Unit coin = new Unit(x, y);
                // check the other coins position
                for (int j = 0; j < i; ++j)
                {
                    Unit tempCoin = Coins[j];
                    if (coin.HasSameLocation(tempCoin))
                    {
                        --i;
                        break;
                    }
                }
                // check the other robuttons position
                for (int j = 0; j < i; ++j)
                {
                    Unit tempRobu = Robuttons[j];
                    if (coin.HasSameLocation(tempRobu))
                    {
                        --i;
                        break;
                    }
                }
                Coins.Add(coin);
            }
        }

        public List<Robutton> Robuttons
        {
            get
            {
                return robuttons;
            }
            set
            {
                robuttons = value;
            }
        }

        public List<Unit> Coins
        {
            get
            {
                return coins;
            }
            set
            {
                coins = value;
            }
        }

        public int XSize
        {
            get
            {
                return xSize;
            }
        }

        public int YSize
        {
            get
            {
                return ySize;
            }
        }
    }
}
