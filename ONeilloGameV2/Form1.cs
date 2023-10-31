using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONeilloGameV2
{
    public partial class Form1 : Form
    {
        private const int boardSize = 8; // set the number of cells on the board, or the number represented in the array
        private const int cellSize = 50; // set the size of the cells in pixels
        private int[,] board = new int[boardSize, boardSize]; // create new 2D array representing the size of the board x the size of the board (8x8)
        private int currentPlayer = 1; // start with player 1

        public Form1()
        {
            InitializeComponent();
            FormComponents();
            InitialiseBoard();
            SetBoard();
        }

        private void FormComponents()
        {
            int width = (boardSize * cellSize) + 20;
            int height = boardSize * cellSize + cellSize * 2;

            this.Text = "ONeillo Game V2"; // set the name of the form 
            this.BackColor = Color.Green; // setting the background of the form to green
            this.Size = new Size(width, height);
        }
        private void InitialiseBoard()
        {
            board[3, 3] = board[4, 4] = 1;
            board[3, 4] = board[4, 3] = 2;

            UpdateInterface();
        }

        private void SetBoard()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(cellSize, cellSize);
                    button.Location = new Point(col * cellSize, row * cellSize);
                    button.Click += new EventHandler(CellClicked);
                    button.Name = "btn_" + row + "_" + col;

                    if (board[row, col] == 1)
                    {
                        button.BackColor = Color.Black;
                        button.Enabled = false;
                    }
                    else if (board[row, col] == 2)
                    {
                        button.BackColor = Color.White;
                        button.Enabled = false;
                    }
                    else
                    {
                        button.BackColor = Color.Green; // set unoccupied cells to green
                    }

                    Controls.Add(button);
                }
            }
        }

        private void CellClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = button.Location.Y / cellSize;
            int col = button.Location.X / cellSize;

            if (ValidMove(row, col))
            {
                MakeMove(row, col);
                SetBoard();

                if (GameOver())
                {
                    GameOverMessage();
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        private void UpdateInterface()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button button = (Button)Controls.Find("btn_" + row + "_" + col, true).FirstOrDefault();

                    if (button != null)
                    {
                        if (board[row, col] == 1)
                        {
                            button.BackColor = Color.Black;
                            button.Enabled = false;
                        }
                        else if (board[row, col] == 2)
                        {
                            button.BackColor = Color.White;
                            button.Enabled = false;
                        }
                        else
                        {
                            button.BackColor = Color.Green; // set the empty counters to green to match the form background colour
                            button.Enabled = ValidMove(row, col); // enable buttons for valid moves
                        }
                    }
                }
            }
        }

        private bool ValidMove(int row, int col)
        {
            if (board[row, col] != 0)
            {
                return false;
            }

            int[] directionRow = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] directionCol = { -1, 0, 1, 1, 1, 0, -1, -1 };
            bool isValidMove = false;

            for (int i = 0; i < 8; i++)
            {
                int r = row + directionRow[i];
                int c = col + directionCol[i];
                bool foundOpponent = false;

                if (r < 0 || r >= boardSize || c < 0 || c >= boardSize || board[r, c] != OtherPlayer())
                {
                    continue;
                }

                while (true)
                {
                    r += directionRow[i];
                    c += directionCol[i];

                    if (r < 0 || r >= boardSize || c < 0 || c >= boardSize)
                    {
                        break;
                    }

                    if (board[r, c] == 0)
                    {
                        break;
                    }

                    if (board[r, c] == currentPlayer)
                    {
                        isValidMove = true;
                        break;
                    }
                }
            }

            return isValidMove;
        }

        private void MakeMove(int row, int col)
        {
            int[] directionRow = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] directionCol = { -1, 0, 1, 1, 1, 0, -1, -1 };

            board[row, col] = currentPlayer;

            for (int i = 0; i < 8; i++)
            {
                int r = row + directionRow[i];
                int c = col + directionCol[i];
                bool foundOpponent = false;

                if (r < 0 || r >= boardSize || c < 0 || c >= boardSize || board[r, c] != OtherPlayer())
                {
                    continue;
                }

                while (true)
                {
                    r += directionRow[i];
                    c += directionCol[i];

                    if (r < 0 || r >= boardSize || c < 0 || c >= boardSize)
                    {
                        break;
                    }

                    if (board[r, c] == 0)
                    {
                        break;
                    }

                    if (board[r, c] == currentPlayer)
                    {
                        while (r != row || c != col)
                        {
                            r -= directionRow[i];
                            c -= directionCol[i];
                            board[r, c] = currentPlayer;
                        }
                        break;
                    }
                }
            }

            UpdateInterface();
        }

        private bool GameOver()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (ValidMove(row, col))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void GameOverMessage()
        {
            int blackCount = 0;
            int whiteCount = 0;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board[row, col] == 1)
                    {
                        blackCount++;
                    }
                    else if (board[row, col] == 2)
                    {
                        whiteCount++;
                    }
                }
            }

            if (blackCount > whiteCount)
            {
                MessageBox.Show("Black wins!");
            }
            else if (whiteCount > blackCount)
            {
                MessageBox.Show("White wins!");
            }
            else
            {
                MessageBox.Show("Draw!");
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = OtherPlayer();
            // statusLabel.Text = "Current player: " + (currentPlayer == 1 ? "Black" : "White");
        }

        private int OtherPlayer()
        {
            return currentPlayer == 1 ? 2 : 1;
        }
    }
}

