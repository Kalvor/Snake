using Snake.Structures;
using Snake.Tools;
using System;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(30, 10);
            IPrinter printer = new Printer(new(10,5));

            printer.Print(board.Data);
        }
    }
}
