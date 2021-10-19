using Snake.Enums;

namespace Snake.Tools.Interfaces
{
    public interface IMenuPrinter
    {
        void PrintHeader(params string[] headerTexts);
        void PrintMenuOptions(Difficulty? selectedDifficulty = null);
        void PrintPlayAgainOption();
        void PrintWinScreen();
        void PrintLoseScreen();
        void ClearRow(int yIndex);
    }
}
