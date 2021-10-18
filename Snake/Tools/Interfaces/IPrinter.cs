using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IPrinter
    {
        Point InitialCurosrPosition { get; init; }
        void Print(ref Board board);
    }
}
