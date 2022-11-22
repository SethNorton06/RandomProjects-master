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
using static System.Net.Mime.MediaTypeNames;

namespace TicTacToe
{
    public partial class InputForm : Form
    {
        private TextBox Prompt;
        private Button YesButton;
        public string TextField = "";
        private Button NoButton;
        private char inputChar;

        public InputForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public InputForm(char character)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.inputChar = character;
        }


        private void InitializeComponent()
        {
            this.Prompt = new System.Windows.Forms.TextBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.Font = new System.Drawing.Font("Wide Latin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prompt.Location = new System.Drawing.Point(0, 0);
            this.Prompt.Multiline = true;
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(598, 150);
            this.Prompt.TabIndex = 0;
            this.Prompt.TabStop = false;
            this.Prompt.Text = "Would you like to go here?";
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(146, 73);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 3;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Location = new System.Drawing.Point(281, 73);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 4;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // InputForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(587, 148);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.Prompt);
            this.Name = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            TextField = inputChar.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}