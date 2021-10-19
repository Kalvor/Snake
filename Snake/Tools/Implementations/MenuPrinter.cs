using Snake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class MenuPrinter : IMenuPrinter
    {
        public void PrintHeader(params string[] headerTexts)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < headerTexts.Length; i++)
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
                switch (allDifficulties[i])
                {
                    case Difficulty.EASY: { Console.ForegroundColor = ConsoleColor.DarkGreen; }; break;
                    case Difficulty.MEDIUM: { Console.ForegroundColor = ConsoleColor.DarkYellow; }; break;
                    case Difficulty.HARD: { Console.ForegroundColor = ConsoleColor.DarkRed; }; break;
                }

                Console.SetCursorPosition((Console.WindowWidth - allDifficulties.Max(c => c.ToString().Length).ToString().Length - 8) / 2, 6 + i);
                if (selectedDifficulty != null && selectedDifficulty == allDifficulties[i])
                {
                    Console.Write(">");
                }
                else
                {
                    Console.WriteLine(" ");
                }
                Console.SetCursorPosition((Console.WindowWidth - allDifficulties[i].ToString().Length) / 2, 6 + i);
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

        public void ClearRow(int yIndex)
        {
            Console.SetCursorPosition(0, yIndex);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
