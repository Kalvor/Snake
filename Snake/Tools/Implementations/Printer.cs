using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class Printer : IPrinter
    {
        public Point InitialCurosrPosition { get; init; }
        public Printer(Point initialCurosrPosition)
        {
            InitialCurosrPosition = initialCurosrPosition;
        }

        public void Print(ref Board board)
        {
            Console.CursorVisible = false;
            foreach(var field in board.Fields.Where(c=>c.Value.NeedsRefreshing))
            {
                Console.SetCursorPosition(
                    InitialCurosrPosition.XCord + field.Key.XCord, 
                    InitialCurosrPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }
    }
}
