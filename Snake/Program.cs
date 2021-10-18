using Snake.Structures;
using Snake.Tools;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(30, 10);
            IPrinter printer = new Printer(new(10,5));

            var snake = new Snake.Structures.Snake(new(10, 10));
            snake.AddNode();
            snake.AddNode();
            snake.AddNode();
            var locations = snake.GetAllNodesLocations().ToList();

            printer.Print(board.Data);
        }
    }
}
