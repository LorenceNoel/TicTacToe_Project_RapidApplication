using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_Game_Gonzales
{
    partial class Form1
    {

        //use buttons to create 3x3 grid 
        private System.ComponentModel.IContainer components = null;

        private Button btn00, btn01, btn02;
        private Button btn10, btn11, btn12;
        private Button btn20, btn21, btn22;
        private Button btnPlayAgain1, btnPlayAgain2;
        private Label lblTurnIndicator, lblPlayer1, lblPlayer2, lblSymbol1, lblSymbol2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        //sets up all controls layout and also the styling for the whole game
        private void InitializeComponent()
        {
            this.btn00 = new Button();
            this.btn01 = new Button();
            this.btn02 = new Button();
            this.btn10 = new Button();
            this.btn11 = new Button();
            this.btn12 = new Button();
            this.btn20 = new Button();
            this.btn21 = new Button();
            this.btn22 = new Button();
            this.btnPlayAgain1 = new Button();
            this.btnPlayAgain2 = new Button();
            this.lblTurnIndicator = new Label();
            this.lblPlayer1 = new Label();
            this.lblPlayer2 = new Label();
            this.lblSymbol1 = new Label();
            this.lblSymbol2 = new Label();
            this.SuspendLayout();

            // Form styling is here. Tried matching it into a TV show SQUID GAME
            this.BackColor = Color.Black;

            // Position buttons in a grid
            int size = 80, spacing = 10;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var btn = new Button();
                    btn.Name = $"btn{row}{col}";
                    btn.Size = new Size(size, size);
                    btn.Location = new Point(10 + col * (size + spacing), 10 + row * (size + spacing));
                    btn.BackColor = Color.FromArgb(30, 30, 30);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                    Controls.Add(btn);
                    GetType().GetField(btn.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, btn);
                }
            }

            // Turn indicator on whos turn is it
            lblTurnIndicator.Location = new Point(70, 280);
            lblTurnIndicator.Size = new Size(250, 30);
            lblTurnIndicator.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTurnIndicator.ForeColor = Color.Lime;
            lblTurnIndicator.Text = "Player 1's Turn";
            Controls.Add(lblTurnIndicator);

            // Play again buttons design
            btnPlayAgain1.Text = "Play Again";
            btnPlayAgain1.Location = new Point(80, 330);
            btnPlayAgain1.Size = new Size(100, 30);
            btnPlayAgain1.Visible = false;
            btnPlayAgain1.BackColor = Color.DarkRed;
            btnPlayAgain1.ForeColor = Color.White;
            btnPlayAgain1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Controls.Add(btnPlayAgain1);

            btnPlayAgain2.Text = "Play Again";
            btnPlayAgain2.Location = new Point(80, 330);
            btnPlayAgain2.Size = new Size(100, 30);
            btnPlayAgain2.Visible = false;
            btnPlayAgain2.BackColor = Color.DarkRed;
            btnPlayAgain2.ForeColor = Color.White;
            btnPlayAgain2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Controls.Add(btnPlayAgain2);

            // Labels for players SIGN
            lblPlayer1.Text = "Player 1";
            lblPlayer1.Location = new Point(300, 10);
            lblPlayer1.ForeColor = Color.DeepPink;
            lblPlayer1.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblSymbol1.Text = "X";
            lblSymbol1.Location = new Point(300, 30);
            lblSymbol1.ForeColor = Color.White;
            lblSymbol1.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblPlayer2.Text = "Player 2";
            lblPlayer2.Location = new Point(300, 60);
            lblPlayer2.ForeColor = Color.DeepPink;
            lblPlayer2.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblSymbol2.Text = "O";
            lblSymbol2.Location = new Point(300, 80);
            lblSymbol2.ForeColor = Color.White;
            lblSymbol2.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            Controls.Add(lblPlayer1);
            Controls.Add(lblSymbol1);
            Controls.Add(lblPlayer2);
            Controls.Add(lblSymbol2);

            // Form settings
            this.ClientSize = new Size(400, 350);
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
        }
    }
}