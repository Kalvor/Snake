using Snake.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Tools
{
    public sealed class Printer : IPrinter
    {
        public Point InitialCurosrPosition { get; init; }
        public Printer(Point initialCurosrPosition)
        {
            InitialCurosrPosition = initialCurosrPosition;
        }

        public void Print(Dictionary<Point, BoardField> data)
        {
            foreach(var field in data.Where(c=>c.Value.NeedsRefreshing))
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
