using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // class designed to build the board and display messages
    class board
    {
        public board()
        {

        }

        
        public void title()
        {
            Console.WriteLine("Welcome to Noughts & Crosses");
            Console.WriteLine("Player one: x\nPLayer two: 0\n\n");
        }
        public void createBoard()
        {
            Console.WriteLine("[{}] [{}] [{}]");
            Console.WriteLine("[{}] [{}] [{}]");
            Console.WriteLine("[{}] [{}] [{}]");
        }
    }
}
