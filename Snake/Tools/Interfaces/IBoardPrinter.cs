using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IBoardPrinter
    {
        Point InitialBoardPosition { get; init; }
        void Print(ref Board board);
    }
}
