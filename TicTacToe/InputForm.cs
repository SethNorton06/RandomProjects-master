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
        private TextBox UserInputBox;
        private Button ButtonConfirmInput;
        private TextBox SelectionText;
        private TextBox InputFeedback;
        public string TextField = "";

        public InputForm()
        {
            InitializeComponent();
        }



        public string GetText()
        {
            string text = "";
            text = UserInputBox.Text.ToString().Trim().ToUpper();
            return text;
        }

        private void InitializeComponent()
        {
            this.Prompt = new System.Windows.Forms.TextBox();
            this.UserInputBox = new System.Windows.Forms.TextBox();
            this.SelectionText = new System.Windows.Forms.TextBox();
            this.ButtonConfirmInput = new System.Windows.Forms.Button();
            this.InputFeedback = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.Font = new System.Drawing.Font("Wide Latin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prompt.Location = new System.Drawing.Point(0, 0);
            this.Prompt.Multiline = true;
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(598, 150);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "Type in your selection (\"X\" or \"O\"):";
            // 
            // UserInputBox
            // 
            this.UserInputBox.Location = new System.Drawing.Point(71, 114);
            this.UserInputBox.Name = "UserInputBox";
            this.UserInputBox.Size = new System.Drawing.Size(125, 22);
            this.UserInputBox.TabIndex = 1;
            this.UserInputBox.TextChanged += new System.EventHandler(this.UserInputBox_TextChanged);
            this.UserInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserInputBox_KeyPress);
            // 
            // SelectionText
            // 
            this.SelectionText.Location = new System.Drawing.Point(8, 114);
            this.SelectionText.Name = "SelectionText";
            this.SelectionText.Size = new System.Drawing.Size(57, 22);
            this.SelectionText.TabIndex = 2;
            this.SelectionText.Text = "Selection: ";
            // 
            // ButtonConfirmInput
            // 
            this.ButtonConfirmInput.Location = new System.Drawing.Point(212, 113);
            this.ButtonConfirmInput.Name = "ButtonConfirmInput";
            this.ButtonConfirmInput.Size = new System.Drawing.Size(75, 23);
            this.ButtonConfirmInput.TabIndex = 3;
            this.ButtonConfirmInput.Text = "OK";
            this.ButtonConfirmInput.UseVisualStyleBackColor = true;
            this.ButtonConfirmInput.Click += new System.EventHandler(this.ButtonConfirmInput_Click);
            // 
            // InputFeedback
            // 
            this.InputFeedback.Location = new System.Drawing.Point(306, 114);
            this.InputFeedback.Name = "InputFeedback";
            this.InputFeedback.ReadOnly = true;
            this.InputFeedback.Size = new System.Drawing.Size(209, 22);
            this.InputFeedback.TabIndex = 4;
            // 
            // InputForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(587, 148);
            this.Controls.Add(this.InputFeedback);
            this.Controls.Add(this.ButtonConfirmInput);
            this.Controls.Add(this.SelectionText);
            this.Controls.Add(this.UserInputBox);
            this.Controls.Add(this.Prompt);
            this.Name = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonConfirmInput_Click(object sender, EventArgs e)
        {
            string value = "";
            value = GetText();
            if (value == "X" || value == "O")
            {
                TextField = value;
                InputFeedback.Text = "";
                this.Close();
            }
            else
            {
                // Some type of error feedback to the user
                InputFeedback.ForeColor = Color.Red;
                InputFeedback.Text = "Please enter valid selection";
            }
        }

        private void UserInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == '\r')
            {
                string value = "";
                value = GetText();
                if (value == "X" || value == "O")
                {
                    TextField = value;
                    InputFeedback.Text = "";
                    this.Close();
                }
                else
                {
                    // Some type of error feedback to the user
                    InputFeedback.ForeColor = Color.Red;
                    InputFeedback.Text = "Please enter valid selection";
                }
            }
        }

        private void UserInputBox_TextChanged(object sender, EventArgs e)
        {
            InputFeedback.Text = "";    // clear the text
        }
    }
}