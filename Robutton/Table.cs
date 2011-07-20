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
        private GameLoop timer;

        public Table()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (game == null)
                return;
            Graphics g = e.Graphics;

            Brush pen = new SolidBrush(Color.Black);
            for (int i = 0; i < game.Robuttons.Count; ++i)
            {
                Robutton robu = game.Robuttons[i];
                g.FillEllipse(pen, robu.X, robu.Y, 4, 4);
            }
            pen = new SolidBrush(Color.Gold);
            for (int i = 0; i < game.Coins.Count; ++i)
            {
                Unit coin = game.Coins[i];
                g.FillEllipse(pen, coin.X, coin.Y, 4, 4);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game = new Game((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            timer = new GameLoop(game, splitContainer1.Panel1);
            timer.Interval = 1000 / 30;
            timer.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Pause"))
            {
                timer.Enabled = false;
                button2.Text = "Weiter";
                button2.Invalidate();
            }
            else
            {
                timer.Enabled = true;
                button2.Text = "Pause";
            }
        }
    }
}
