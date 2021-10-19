using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;
using Snake.Enums;

namespace Snake.Tools.Implementations
{
    public sealed class Printer : IPrinter
    {
        public Point InitialBoardPosition { get; init; }
        public Printer(Point initialBoardPosition)
        {
            InitialBoardPosition = initialBoardPosition;
        }

        public void PrintBoard(ref Board board)
        {
            foreach(var field in board.Fields.Where(c=>c.Value.NeedsRefreshing))
            {
                Console.ForegroundColor = field.Value.Color;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(
                    InitialBoardPosition.XCord + field.Key.XCord, 
                    InitialBoardPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }

        public void PrintText(DisplayText text)
        {
            Console.ForegroundColor = text.Color;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(text.Location.XCord, text.Location.YCord);
            Console.Write(text.StringToPrint);
        }

        public void ClearText(DisplayText text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(text.Location.XCord, text.Location.YCord);
            Console.Write(new string(' ',Console.WindowWidth));
        }

        public void SelectText(DisplayText text)
        {
            Console.ForegroundColor = text.Color;
            Console.BackgroundColor = text.BackgroundColor;
            Console.SetCursorPosition(text.Location.XCord, text.Location.YCord);
            Console.Write(text.StringToPrint);
        }
    }
}
