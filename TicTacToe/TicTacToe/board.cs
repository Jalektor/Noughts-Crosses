using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    // class designed to build the board and display messages
    // array used to populate numbers, initially, into board
    // By replacing the number inserted with the number in array element
    class board
    {
#region variables
        // sets choie of player
        static int choice;
        // which player's turn it is. default is 1
        // =/- 1 depending on which player it is
        static int player = 1;
        // bool for error fucntion to display message
        static bool error;

        // checks the state of the game. if 0, game continues
        // gameState = 1 means a winner
        // gamState = 2 means a draw
        static int gameState = 0;

        // creates char array to store tiles
        public char[] tiles = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
#endregion
        #region constructor
        public board()
        {
        }
#endregion

        public void begin()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Noughts & Crosses");
                Console.WriteLine("Player one: x\nPLayer two: 0\n\n");

                if(player == 1)
                {
                    Console.WriteLine("Player 1 to go");
                }
                else
                {
                    Console.WriteLine("Player 2 to go");
                }

                createBoard();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    error = true;
                    Error(error);
                }
                if(choice > 9 || choice < 0)
                {
                    error = true;
                    Error(error);
                }

                if (tiles[choice] != 'X' && tiles[choice] != 'O')
                {
                    if(player == 2)
                    {
                        tiles[choice] = 'O';
                        player--;
                    }
                    else
                    {
                        tiles[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    error = false;
                    Error(error);
                }

                gameState = checkWin();
                
            }
            while (gameState != 1 && gameState != 2);

            Console.Clear();
            createBoard();
            if(gameState == 1)
            {
                Console.WriteLine("Congratulations!\nPlayer {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Game is a draw" +
                    "\nBetter luck next time");
            }

            Console.ReadLine();
            newGame();

        }
#region created board
        public void createBoard()
        {
            // inserts char's into array each time fucntion called#
            // At beginning of load up and each time a game is won/drawn
            //tiles = { '0','1','2','3','4','5','6','7','8','9' };

            Console.WriteLine("[ {0} ] [ {1} ] [ {2} ]", tiles[1], tiles[2], tiles[3]);
            Console.WriteLine("[ {0} ] [ {1} ] [ {2} ]", tiles[4], tiles[5], tiles[6]);
            Console.WriteLine("[ {0} ] [ {1} ] [ {2} ]", tiles[7], tiles[8], tiles[9]);
        }
        #endregion
#region error
        public void Error(bool option)
        {
            if(option == true)
            {
                Console.WriteLine("Only enter one of the numbers on the board! Mark/Earl!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tile {0} is already marked with {1}", choice, tiles[choice]);
                Console.ReadLine();
            }
        }
#endregion
        #region Checks for a win/draw
        private int checkWin()
        {
            #region Row winner
            /// Summary
            /// Checks rows for winner
            if(tiles[1] == tiles[2] && tiles[2] == tiles[3])
            {
                return 1;
            }
            else if(tiles[4] == tiles[5] && tiles[5] == tiles[6])
            {
                return 1;
            }
            else if(tiles[7] == tiles[8] && tiles[8] == tiles[9])
            {
                return 1;
            }
            #endregion
            #region Column Winner
            /// Summary
            /// Checks columns for winner
            else if (tiles[1] == tiles[4] && tiles[4] == tiles[7])
            {
                return 1;
            }
            else if (tiles[2] == tiles[5] && tiles[5] == tiles[8])
            {
                return 1;
            }
            else if (tiles[3] == tiles[6] && tiles[6] == tiles[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winner
            /// Summary
            /// Checks Diagonals for winner
            else if (tiles[1] == tiles[5] && tiles[5] == tiles[9])
            {
                return 1;
            }
            else if (tiles[3] == tiles[5] && tiles[5] == tiles[7])
            {
                return 1;
            }
            #endregion
            #region Check for Draw
            /// Summary
            /// Checks for a Draw
            else if (tiles[1] != '1' && tiles[2] != '2' && tiles[3] != '3' && tiles[4] != '4' && tiles[5] != '5' && tiles[6] != '6' && tiles[7] != '7' && tiles[8] != '8' && tiles[9] != '9')
            {
                return 2;
            }
#endregion
            else
            {
                return 0;
            }
        }
        #endregion

#region New Game
        // Creates a new game
        // resets variables to original values
        // Time delay before a new game begins
        public void newGame()
        {
            Console.Clear();

            player = 1;

            gameState = 0;

            tiles = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Console.WriteLine("New game commencing");
            Thread.Sleep(2000);

            begin();
        }
#endregion
    }
}
