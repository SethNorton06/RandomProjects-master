namespace TicTacToe
{
    partial class Begin
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
            this.Title = new System.Windows.Forms.TextBox();
            this.SinglePlayerButton = new System.Windows.Forms.Button();
            this.MultiplayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Showcard Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(265, 46);
            this.Title.Multiline = true;
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(249, 133);
            this.Title.TabIndex = 0;
            this.Title.Text = "Tic Tac Toe";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SinglePlayerButton
            // 
            this.SinglePlayerButton.Location = new System.Drawing.Point(265, 232);
            this.SinglePlayerButton.Name = "SinglePlayerButton";
            this.SinglePlayerButton.Size = new System.Drawing.Size(249, 23);
            this.SinglePlayerButton.TabIndex = 1;
            this.SinglePlayerButton.Text = "Singleplayer";
            this.SinglePlayerButton.UseVisualStyleBackColor = true;
            this.SinglePlayerButton.Click += new System.EventHandler(this.SinglePlayerButton_Click);
            // 
            // MultiplayerButton
            // 
            this.MultiplayerButton.Location = new System.Drawing.Point(265, 305);
            this.MultiplayerButton.Name = "MultiplayerButton";
            this.MultiplayerButton.Size = new System.Drawing.Size(249, 23);
            this.MultiplayerButton.TabIndex = 2;
            this.MultiplayerButton.Text = "Multiplayer";
            this.MultiplayerButton.UseVisualStyleBackColor = true;
            this.MultiplayerButton.Click += new System.EventHandler(this.MultiplayerButton_Click);
            // 
            // Begin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MultiplayerButton);
            this.Controls.Add(this.SinglePlayerButton);
            this.Controls.Add(this.Title);
            this.Name = "Begin";
            this.Text = "Begin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Button SinglePlayerButton;
        private System.Windows.Forms.Button MultiplayerButton;
    }
}