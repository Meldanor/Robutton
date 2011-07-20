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
    class Game
    {
        private List<Robutton> robuttons;       
        public  List<Robutton> Robuttons
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
        private List<Unit> coins;
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
        private int xSize;
        public int XSize
        {
            get
            {
                return xSize;
            }
        }

        private int ySize;
        public int YSize
        {
            get
            {
                return ySize;
            }
        }

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

        public Game()
            : this(5, 5, 400, 400){}

        public Game(int robuttons, int coins)
            : this(robuttons,coins,400,400){}

        public void GenerateGame()
        {

            Random rand = new Random();
            // generate the robuttons
            for (int i = 0 ; i < Robuttons.Capacity; ++i) {
                int x = rand.Next(XSize);
                int y = rand.Next(YSize);
                int direction = rand.Next(360);
                Robutton robu = new Robutton(x,y,direction);
                if (IsThereAnUnit(x, y) != null)
                {
                    --i;
                    continue;
                }
                Robuttons.Add(robu);
            }
            // generate the coin positions
            for (int i = 0; i < Coins.Capacity; ++i)
            {
                int x = rand.Next(XSize);
                int y = rand.Next(YSize);
                Unit coin = new Unit(x, y);
                // check the other coins position
                if (IsThereAnUnit(x, y) != null)
                {
                    --i;
                    continue;
                }
                Coins.Add(coin);
            }
        }

        public Unit IsThereAnUnit(int x, int y)
        {
            foreach (Robutton robu in Robuttons)
                if (robu.X == x && robu.Y == y)
                    return robu;
            foreach (Unit coin in Coins)
                if (coin.X == x && coin.Y == y)
                    return coin;
            return null;
        }

        public const int TRESPASS_RIGHT_OR_LEFT_BORDER      = 0;
        public const int TRESPASS_UPPER_OR_BUTTOM_BORDER    = 1;
        public const int ON_THE_FIELD                       = 2;

        public int IsOnTheField(int x, int y)
        {
            if (x < 0 || x >= XSize)
                return TRESPASS_RIGHT_OR_LEFT_BORDER;
            else if (y < 0 || y >= YSize)
                return TRESPASS_UPPER_OR_BUTTOM_BORDER;
            else
                return ON_THE_FIELD;
        }

        public void Next()
        {
            for (int i = 0; i < Robuttons.Count; ++i)
                Robuttons[i].Move(this);
        }
    }
}
