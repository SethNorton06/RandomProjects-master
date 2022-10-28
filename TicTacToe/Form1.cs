using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        List<TicTacToePanel> panels = new List<TicTacToePanel>();
        
        public TicTacToeForm()
        {
            InitializeComponent();
            CreatePanels();
        }



        public void CreatePanels()
        {
            int x = 0;
            int y = 0;
            // There will be nine panels
            Debug.WriteLine("===============================================");
            for (int i = 0; i < 3; i++)
            {
                TicTacToePanel p = null;
                for (int j = 0; j < 3; j++)
                {
                    const int HEIGHT = 100;
                    const int WIDTH = 100;

                    p = new TicTacToePanel();
                    p.Size = new Size(WIDTH, HEIGHT);
                    p.Location = new Point(x, y);
                    p.Click += PanelClick;
                    p.Paint += p.CharacterInPanelChange;
                    if (i != 2)
                        CreateHorizontalLines(new Rectangle(p.Location.X, p.Location.Y + HEIGHT + 1, 100, 10));
                    if(j != 2)
                        CreateVerticalLines(new Rectangle(p.Location.X  + WIDTH, p.Location.Y, 10, 100));

                    Debug.WriteLine($"Panel {i+j}: " + p.Location);
                    p.BackColor = Color.Aquamarine;
                    x += p.Size.Width + 10;
                    this.Controls.Add(p);
                    panels.Add(p);
                    Debug.WriteLine($"Inner Loop {i}: " + this.Controls.Count);
                }
                x = 0;
                y += p.Size.Height + 10; 
                Debug.WriteLine($"Loop {i}: " + this.Controls.Count);
            }
            Debug.WriteLine($"Panel Count: {this.Controls.Count}");
            Debug.WriteLine("===============================================");
        }

        private void PanelClick(object sender, EventArgs e)
        {
            TicTacToePanel p = sender as TicTacToePanel;

            foreach (var pa in panels)
            {
                if (pa.BackColor == Color.Orange)
                    pa.BackColor = Color.Aquamarine;
            }



            if (p.BackColor == Color.Aquamarine)
                p.BackColor = Color.Orange;
            else
                p.BackColor = Color.Aquamarine;


            bool invalidSelection = true;

            while(invalidSelection)
            {

                InputForm inputChoice = new InputForm();
                inputChoice.ShowDialog();
                string text = inputChoice.TextField;
                if (text[0] != '\0')
                {
                    p.CharacterInPanel = text[0];
                    invalidSelection = false;
                }
                p.Invalidate();
                p.Update();
            }

        }

        public void CreateHorizontalLines(Rectangle r)
        {
            Panel p = new Panel();
            p.Size = new Size(r.Width, r.Height);
            p.Location = new Point(r.X, r.Y);
            p.BackColor = Color.Black;
            this.Controls.Add(p);

            // Debug.WriteLine($"Rectangle Horizontal: " + this.Controls.Count);
        }

        public void CreateVerticalLines(Rectangle r)
        {
            Panel p = new Panel();
            p.Size = new Size(r.Width, r.Height);
            p.Location = new Point(r.X, r.Y);
            p.BackColor = Color.Black;
            this.Controls.Add(p);

            // Debug.WriteLine($"Rectangle Vertical: " + this.Controls.Count);
        }

    }
}
