using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;
using Snake.Enums;

namespace Snake.Tools.Implementations
{
    public sealed class Printer : IPrinter
    {
        public Point InitialCurosrPosition { get; init; }
        public Printer(Point initialCurosrPosition)
        {
            InitialCurosrPosition = initialCurosrPosition;
        }

        public void Print(ref Board board)
        {
            foreach(var field in board.Fields.Where(c=>c.Value.NeedsRefreshing))
            {
                Console.ForegroundColor = field.Value.Color;
                Console.SetCursorPosition(
                    InitialCurosrPosition.XCord + field.Key.XCord, 
                    InitialCurosrPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }

        public void PrintHeader(params string[] headerTexts)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for(int i=0;i<headerTexts.Length;i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - headerTexts[i].Length) / 2, 1 + i);
                Console.Write(headerTexts[i]);
            }
        }


        public void PrintMenuOptions(Difficulty? selectedDifficulty = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Black;
            string info = $"Please select Difficulty...";
            Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, 4);
            Console.WriteLine(info);

            var allDifficulties = Enum.GetValues<Difficulty>();
            for (int i = 0; i < allDifficulties.Length; i++)
            {
                if(selectedDifficulty != null && selectedDifficulty == allDifficulties[i])
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                switch (allDifficulties[i])
                {
                    case Difficulty.EASY: { Console.ForegroundColor = ConsoleColor.DarkGreen; }; break;
                    case Difficulty.MEDIUM: { Console.ForegroundColor = ConsoleColor.DarkYellow; }; break;
                    case Difficulty.HARD: { Console.ForegroundColor = ConsoleColor.DarkRed; }; break;
                }

                Console.SetCursorPosition((Console.WindowWidth - allDifficulties[i].ToString().Length) / 2, 5+i);
                Console.Write(allDifficulties[i].ToString());
            }
        }

        public void PrintPlayAgainOption()
        {
        }

        public void PrintWinScreen()
        {
        }

        public void PrintLoseScreen()
        {
        }
    }
}
