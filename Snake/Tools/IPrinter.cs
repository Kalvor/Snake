using Snake.Structures;
using System.Collections.Generic;

namespace Snake.Tools
{
    public interface IPrinter
    {
        Point InitialCurosrPosition { get; init; }
        void Print(Dictionary<Point, BoardField> data);
    }
}
