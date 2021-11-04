using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IPrinter
    {
        Point InitialBoardPosition { get; init; }
        void PrintBoard(Board board);
        void ClearBoard(Board board);
        void PrintText(DisplayText text);
        void ClearText(DisplayText text);
        void SelectText(DisplayText text);
    }
}
