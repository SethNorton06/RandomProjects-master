using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    [Serializable]
    public class TicTacToePanel : Panel
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
                    
                    if (CharacterInPanel == 'X')
                    {
                        Pen pe = new Pen(Color.Red, 8);
                        // Draw an X
                        g.DrawLine(pe, 0, 0, 100, 100);
                        g.DrawLine(pe, 100, 0, 0, 100);
                    }
                    else
                    {
                        Pen pe = new Pen(Color.Blue, 8);
                        // Draw an O
                        g.DrawEllipse(pe, new Rectangle(0, 0, 100, 100));
                    }


                }
            }               
        }
    }
}
