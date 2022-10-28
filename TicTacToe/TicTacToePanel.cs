using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class TicTacToePanel : Panel
    {
        public char  CharacterInPanel { get; set; }
        public Color CharacterColor { get; set; }
        public Font CharacterFont { get; set; }
        
        public TicTacToePanel()
        {
            CharacterColor = Color.Red;
            CharacterFont = new Font(new FontFamily("Verdana"), 12, FontStyle.Bold);
            ForeColor = CharacterColor;
  
        }

        public void CharacterInPanelChange(object sender, PaintEventArgs e)
        {
            TicTacToePanel p = sender as TicTacToePanel;

            if (p.CharacterInPanel != '\0')
            {
                using (Graphics g = e.Graphics)
                {
                    Pen pe = new Pen(Color.Red);
                    pe.Width = 8.0F;
                    SolidBrush sb = new SolidBrush(Color.Red);
                    g.DrawLine(pe, p.Location.X, p.Location.Y, p.Location.X + p.Width, p.Location.Y + p.Height);
                    g.DrawEllipse(pe, new Rectangle(p.Location.X, p.Location.Y, p.Location.X + p.Width, p.Location.Y + p.Height));
                    // g.DrawRectangle(pe, new Rectangle(new Point(50, 50), new Size(new Point(50, 50))));

                }
            }               
        }
    }
}
