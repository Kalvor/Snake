﻿using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IPrinter
    {
        Point InitialCurosrPosition { get; init; }
        void Print(ref Board board);
        void PrintHeader(params string[] headerTexts);
        void PrintMenuOptions();
        void PrintPlayAgainOption();
        void PrintWinScreen();
        void PrintLoseScreen();
    }
}
