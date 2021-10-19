using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;
using Snake.Enums;

namespace Snake.Tools.Implementations
{
    public sealed class BoardPrinter : IBoardPrinter
    {
        public Point InitialBoardPosition { get; init; }
        public BoardPrinter(Point initialBoardPosition)
        {
            InitialBoardPosition = initialBoardPosition;
        }

        public void Print(ref Board board)
        {
            foreach(var field in board.Fields.Where(c=>c.Value.NeedsRefreshing))
            {
                Console.ForegroundColor = field.Value.Color;
                Console.SetCursorPosition(
                    InitialBoardPosition.XCord + field.Key.XCord, 
                    InitialBoardPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }
    }
}
