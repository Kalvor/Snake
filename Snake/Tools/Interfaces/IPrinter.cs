using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IPrinter
    {
        Point InitialBoardPosition { get; init; }
        void PrintBoard(ref Board board);
        void ClearBoard(ref Board board);
        void PrintText(DisplayText text);
        void ClearText(DisplayText text);
        void SelectText(DisplayText text);
    }
}
