using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Robutton
{
    public partial class Table : Form
    {
        private Game game;

        public Table()
        {
            InitializeComponent();
            game = new Game(200,1);
            GameLoop timer = new GameLoop(game, splitContainer1.Panel1);
            timer.Interval = 1000 / 30;
            timer.Enabled = true;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Brush pen = new SolidBrush(Color.Black);
            for (int i = 0; i < game.Robuttons.Count; ++i)
            {
                Robutton robu = game.Robuttons[i];
                g.FillEllipse(pen, robu.X, robu.Y, 2, 2);
            }
            pen = new SolidBrush(Color.Gold);
            for (int i = 0; i < game.Coins.Count; ++i)
            {
                Unit coin = game.Coins[i];
                g.FillEllipse(pen, coin.X, coin.Y, 2, 2);
            }
        }
    }
}
