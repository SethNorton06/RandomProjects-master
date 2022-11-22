namespace TicTacToe
{
    partial class Winning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WinBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WinBox
            // 
            this.WinBox.Font = new System.Drawing.Font("Wide Latin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinBox.Location = new System.Drawing.Point(265, 137);
            this.WinBox.Multiline = true;
            this.WinBox.Name = "WinBox";
            this.WinBox.Size = new System.Drawing.Size(281, 170);
            this.WinBox.TabIndex = 0;
            this.WinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Winning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WinBox);
            this.Name = "Winning";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WinBox;
    }
}