using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            board board = new board();

            board.title();
            board.createBoard();

            Console.WriteLine("\nPlayer blah turn");
            Console.ReadLine();
        }
    }
}
