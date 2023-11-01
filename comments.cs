using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        private int currentPlayer = 1; // initialize the starting player
        private int blackCount = 0; // initialize the counter for black pieces
        private int whiteCount = 0; // initialize the counter for white pieces

        public Form1() // initialize the form
        {
            InitializeComponent(); 
            FormComponents(); // set the form characteristics
            InitialiseBoard(); // set the initial pieces on the board
            SetBoard(); // creates and add button controls for the board
        }

        private void FormComponents() // set the characteristics of the form
        {
            int width = (boardSize * cellSize) + 20; // declare the form's width
            int height = boardSize * cellSize + cellSize * 4; // declare the form's height

            this.Text = "ONeillo Game V2"; // set the name of the form 
            this.BackColor = Color.Green; // setting the background of the form to green
            this.Size = new Size(width, height); // set the size of the form
        }

        private void InitialiseBoard() // set the initial placement of the pieces on the board
        {
            board[3, 3] = board[4, 4] = 1; // set the beginning black pieces
            board[3, 4] = board[4, 3] = 2; // set the beginning white pieces

            UpdateInterface(); // update the appearance of the board
        }

        private void SetBoard() // create and add button controls for the board
        {
            for (int row = 0; row < boardSize; row++) // iterate over each row of the board
            {
                for (int col = 0; col < boardSize; col++) // iterate over each column of the board
                {
                    Button button = new Button(); // create new button control for every cell
                    button.Size = new Size(cellSize, cellSize); // set the size of the cell
                    button.Location = new Point(col * cellSize, row * cellSize + 30); // set the location for the board on the app. the board has to be lowered due to the menu strip being implemented
                    button.Click += new EventHandler(CellClicked); // set the CellClicked event for the button
                    button.Name = "btn_" + row + "_" + col; // set the name of the button control as per the current iteration

                    if (board[row, col] == 1) // check if the current cell is occupied by a black piece
                    {
                        button.BackColor = Color.Black; // set the color of the button control to black
                        button.Enabled = false; // disable the button 
                    }
                    else if (board[row, col] == 2) // check if the current cell is occupied by a white piece
                    {
                        button.BackColor = Color.White; // set the color of the button control to white
                        button.Enabled = false; // disable the button 
                    }
                    else
                    {
                        button.BackColor = Color.Green; // set unoccupied cells to green
                    }

                    Controls.Add(button); // add the button control to the form controls
                }
            }
        }

        private void CellClicked(object sender, EventArgs e) // handle the click event for the cells
        {
            Button button = (Button)sender; // create an instance of the button control that was clicked 
            int row = button.Location.Y / cellSize; // calculate the row of the clicked cell
            int col = button.Location.X / cellSize; // calculate the column of the clicked cell

            if (ValidMove(row, col)) // check if the clicked cell is a valid move
            {
                MakeMove(row, col); // make the move 
                SetBoard(); // update the appearance of the board

                if (GameOver()) // check if the game is over
                {
                    GameOverMessage(); // display the winner or draw message
                }
                else
                {
                    SwitchPlayer(); // switch to the other player
                }
            }
        }

        private void UpdateInterface() // update the appearance of the board
        {
            for (int row = 0; row < boardSize; row++) // iterate over each row of the board
            {
                for (int col = 0; col < boardSize; col++) //iterate over each column of the board 
                {
                    Button button = (Button)Controls.Find("btn_" + row + "_" + col, true).FirstOrDefault(); // get the button control instance from the form controls based on its name

                    if (button != null) // check if the button instance is not null
                    {
                        if (board[row, col] == 1) // check if the current cell is occupied by a black piece
                        {
                            button.BackColor = Color.Black; // set the color of the button control to black
                            button.Enabled = false; // disable the button 
                        }
                        else if (board[row, col] == 2) // check if the current cell is occupied by a white piece
                        {
                            button.BackColor = Color.White; // set the color of the button control to white
                            button.Enabled = false; // disable the button 
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

        private bool ValidMove(int row, int col) // check if the move is valid
        {
            if (board[row, col] != 0) // check if the cell is already occupied
            {
                return false; // return false if it is already occupied
            }

            int[] directionRow = { -1, -1, -1, 0, 1, 1, 1, 0 }; // initialize an array of directions of rows to check for a potential valid move
            int[] directionCol = { -1, 0, 1, 1, 1, 0, -1, -1 }; // initialize an array of directions of columns to check for a potential valid move
            bool isValidMove = false;

            for (int i = 0; i < 8; i++) // iterate over each direction
            {
                int r = row + directionRow[i]; // calculate the new row based on the current direction
                int c = col + directionCol[i]; // calculate the new column based on the current direction
                bool foundOpponent = false;

                if (r < 0 || r >= boardSize || c < 0 || c >= boardSize || board[r, c] != OtherPlayer()) // check if the new row and column values are within the board, check if the cell at the new position is occupied by the opposing player 
                {
                    continue; // skip to the next iteration
                }

                while (true) // iterate until a break statement is encountered
                {
                    r += directionRow[i]; // update the row value based on the direction
                    c += directionCol[i]; // update the column value based on the direction

                    if (r < 0 || r >= boardSize || c < 0 || c >= boardSize) // check if the new row and column values are within the board
                    {
                        break; // if not, break out of the loop
                    }

                    if (board[r, c] == 0) // check if the current cell is empty
                    {
                        break; // if it is empty, break out of the loop
                    }

                    if (board[r, c] == currentPlayer) // check if the current cell is occupied by the current player
                    {
                        isValidMove = true; // set isValidMove to true as the move is valid
                        break; // break out of the loop
                    }
                }
            }

            return isValidMove; // return whether the move was valid or not
        }

        private void MakeMove(int row, int col) // make the move
        {
            int[] directionRow = { -1, -1, -1, 0, 1, 1, 1, 0 }; // initialize an array of directions of rows to flip the opposing pieces
            int[] directionCol = { -1, 0, 1, 1, 1, 0, -1, -1 }; // initialize an array of directions of columns to flip the opposing pieces

            board[row, col] = currentPlayer; // set the current cell to the current player's value

            for (int i = 0; i < 8; i++) // iterate over each direction
            {
                int r = row + directionRow[i]; // calculate the new row based on the current direction
                int c = col + directionCol[i]; // calculate the new column based on the current direction
                bool foundOpponent = false;

                if (r < 0 || r >= boardSize || c < 0 || c >= boardSize || board[r, c] != OtherPlayer()) // check if the new row and column values are within the board, check if the cell at the new position is occupied by the opposing player 
                {
                    continue; // skip to the next iteration
                }

                while (true) // iterate until a break statement is encountered
                {
                    r += directionRow[i]; // update the row value based on the direction
                    c += directionCol[i]; // update the column value based on the direction

                    if (r < 0 || r >= boardSize || c < 0 || c >= boardSize) // check if the new row and column values are within the board
                    {
                        break; // if not, break out of the loop
                    }

                    if (board[r, c] == 0) // check if the current cell is empty
                    {
                        break; // if it is empty, break out of the loop
                    }

                    if (board[r, c] == currentPlayer) // check if the current cell is occupied by the current player
                    {
                        while (r != row || c != col) // iterate until it reaches a piece previously set by the currentPlayer
                        {
                            r -= directionRow[i]; // update the row value backwards
                            c -= directionCol[i]; // update the column value backwards
                            board[r, c] = currentPlayer; // set the value of the cell to the currentPlayer's value
                        }
                        break; // break out of the loop
                    }
                }
            }

            UpdateInterface(); // update the appearance of the board
        }

        private bool GameOver() // check if the game is over
        {
            for (int row = 0; row < boardSize; row++) // iterate over each row of the board
            {
                for (int col = 0; col < boardSize; col++) // iterate over each column of the board
                {
                    if (ValidMove(row, col)) // check if there is still a valid move for the current cell
                    {
                        return false; // return false, the game is not over yet
                    }
                }
            }

            return true; // return true, the game is over
        }

        private void GameOverMessage() // display a message box indicating the winner or a draw
        {
            for (int row = 0; row < boardSize; row++) //iterate over each row of the board
            {
                for (int col = 0; col < boardSize; col++) // iterate over each column of the board
                {
                    if (board[row, col] == 1) // check if the cell is occupied by a black piece
                    {
                        blackCount++; // increment the black count
                    }
                    else if (board[row, col] == 2) // check if the cell is occupied by a white piece
                    {
                        whiteCount++; // increment the white count
                    }
                }
            }

            if (blackCount > whiteCount) // check if the black count is greater than the white count
            {
                MessageBox.Show($"{textBox2.Text} wins!"); // display the winner's name with a message box. black is always player 2, so they will win if their black count is greater than the white count towards the end of the game
            }
            else if (whiteCount > blackCount) // check if the white count is greater than the black count
            {
                MessageBox.Show($"{textBox1.Text} wins!"); // display the winner's name with a message box
            }
            else // if there is a draw
            {
                MessageBox.Show("Draw!"); // display a message box indicating a draw
            }
        }

        private void SwitchPlayer() // switch player mechanism
        {
            currentPlayer = OtherPlayer(); // change the current player to the other player
        }

        private int OtherPlayer() // return the number of the other player (either 1 or 2)
        {
            return currentPlayer == 1 ? 2 : 1; // if currentPlayer is 1, return 2. Otherwise, return 1.
        }
    }
}
