using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_Game_Gonzales
{
    public partial class Form1 : Form
    {
        private bool isPlayerOneTurn = true;
        private readonly string[,] board = new string[3, 3];
        private const int SIZE = 3;

        public Form1()
        {
            InitializeComponent();

            // Wiring all the buttons when clicked
            // Used the same logic from previous JAVA project and applied it here but with utilizing Forms.
            btn00.Click += Cell_Click;
            btn01.Click += Cell_Click;
            btn02.Click += Cell_Click;
            btn10.Click += Cell_Click;
            btn11.Click += Cell_Click;
            btn12.Click += Cell_Click;
            btn20.Click += Cell_Click;
            btn21.Click += Cell_Click;
            btn22.Click += Cell_Click;

            btnPlayAgain1.Click += (s, e) => ResetGame();
            btnPlayAgain2.Click += (s, e) => ResetGame();

            ResetBoard();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || !string.IsNullOrEmpty(btn.Text)) return;

            int row = int.Parse(btn.Name[3].ToString());
            int col = int.Parse(btn.Name[4].ToString());

            board[row, col] = isPlayerOneTurn ? "X" : "O";
            btn.Text = board[row, col];

            string winner = CheckWinner();
            if (winner != null)
            {
                if (winner == "Draw")
                {
                    lblTurnIndicator.Text = "It's a draw!";
                    lblTurnIndicator.ForeColor = Color.Gray;
                    ShowPlayAgainOption("Draw");
                }
                else
                {
                    lblTurnIndicator.Text = winner == "X" ? "Player 1 wins!" : "Player 2 wins!";
                    lblTurnIndicator.ForeColor = winner == "X" ? Color.Green : Color.Red;
                    ShowPlayAgainOption(winner);
                }
                DisableBoard();
            }
            else
            {
                isPlayerOneTurn = !isPlayerOneTurn;
                lblTurnIndicator.Text = isPlayerOneTurn ? "Player 1's Turn" : "Player 2's Turn";
                lblTurnIndicator.ForeColor = isPlayerOneTurn ? Color.Green : Color.Red;
            }
        }


        // Checks rows, columns, and diagonals for a winner or draw
        private string CheckWinner()
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (!string.IsNullOrEmpty(board[i, 0]) &&
                    board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return board[i, 0];

                if (!string.IsNullOrEmpty(board[0, i]) &&
                    board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return board[0, i];
            }

            if (!string.IsNullOrEmpty(board[0, 0]) &&
                board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return board[0, 0];

            if (!string.IsNullOrEmpty(board[0, 2]) &&
                board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return board[0, 2];

            foreach (var cell in board)
                if (string.IsNullOrEmpty(cell)) return null;

            return "Draw";
        }
        //resets the board back to blank
        private void ResetBoard()
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    board[i, j] = "";

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btn") && btn.Name.Length == 5)
                {
                    btn.Text = "";
                    btn.Enabled = true;
                }
            }

            lblTurnIndicator.Text = "Player 1's Turn";
            lblTurnIndicator.ForeColor = Color.Green;
            isPlayerOneTurn = true;
            ResetPlayerViews();
        }

        private void ResetGame()
        {
            ResetBoard();
        }

        private void DisableBoard()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("btn") && btn.Name.Length == 5)
                    btn.Enabled = false;
            }
        }

        //show play again when there is a winner or draw
        private void ShowPlayAgainOption(string winner)
        {
            if (winner == "X")
            {
                btnPlayAgain1.Visible = false;
                btnPlayAgain2.Visible = true;
                lblPlayer2.Visible = false;
                lblSymbol2.Visible = false;
            }
            else if (winner == "O")
            {
                btnPlayAgain1.Visible = true;
                btnPlayAgain2.Visible = false;
                lblPlayer1.Visible = false;
                lblSymbol1.Visible = false;
            }
            else
            {
                btnPlayAgain1.Visible = true;
                btnPlayAgain2.Visible = true;
            }
        }

        private void ResetPlayerViews()
        {
            lblPlayer1.Visible = true;
            lblSymbol1.Visible = true;
            lblPlayer2.Visible = true;
            lblSymbol2.Visible = true;
            btnPlayAgain1.Visible = false;
            btnPlayAgain2.Visible = false;
        }
    }
}
