using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Begin : Form
    {
        public Begin()
        {
            InitializeComponent();
        }

        private void SinglePlayerButton_Click(object sender, EventArgs e)
        {
            TicTacToeForm t = new TicTacToeForm();
            t.Show();
            this.Hide();
        }

        private void MultiplayerButton_Click(object sender, EventArgs e)
        {

            TicTacToeForm t = new TicTacToeForm(true, true, "127.0.0.1");
            TicTacToeForm b = new TicTacToeForm(true, false, "127.0.0.1");

            t.Show();
            b.Show();
            this.Hide();
        }
    }
}
