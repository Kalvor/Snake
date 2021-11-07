using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;
using Snake.Enums;

namespace Snake.Tools.Implementations
{
    public sealed class Printer : IPrinter
    {
        public Point InitialBoardPosition { get; private set; }
        public Printer()
        {
            InitialBoardPosition = new(0, 0);
        }

        public void PrintBoard(Board board)
        {
            foreach(var field in board.Fields.Where(c=>c.Value.NeedsRefreshing))
            {
                Console.ForegroundColor = field.Value.Field.Color;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(
                    InitialBoardPosition.XCord + field.Key.XCord, 
                    InitialBoardPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.Field.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }
        public void ClearBoard(Board board)
        {
            foreach (var field in board.Fields)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(
                    InitialBoardPosition.XCord + field.Key.XCord,
                    InitialBoardPosition.YCord + field.Key.YCord);
                Console.Write(" ");
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

        public void SetInitialBoardPosition(Point point)
        {
            InitialBoardPosition = point;
        }
    }
}
