using System.Collections.Generic;
using System;

namespace Robutton
{
    public class Game
    {
        private List<Robutton> robuttons;
        private List<Coin> coins;
        private int xSize;
        private int ySize;

        public Game()
        {
            robuttons = new List<Robutton>(5);
            coins = new List<Coin>(5);
            xSize = 400;
            ySize = 400;
        }

        public Game(int robuttons, int coins)
        {
            this.robuttons = new List<Robutton>(robuttons);
            this.coins = new List<Coin>(coins);
            xSize = 400;
            ySize = 400;
        }

        public Game(int robuttons, int coins, int xSize, int ySize)
        {
            this.robuttons = new List<Robutton>(robuttons);
            this.coins = new List<Coin>(coins);
            this.xSize = xSize;
            this.ySize = ySize;
        }
    }
}
