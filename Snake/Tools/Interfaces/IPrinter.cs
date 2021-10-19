using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IPrinter
    {
        Point InitialCurosrPosition { get; init; }
        void Print(ref Board board);
        void PrintHeader(params string[] headerTexts);
        void PrintMenuOptions(Difficulty? selectedDifficulty = null);
        void PrintPlayAgainOption();
        void PrintWinScreen();
        void PrintLoseScreen();
    }
}
