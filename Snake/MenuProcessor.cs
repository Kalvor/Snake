using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Implementations;
using Snake.Tools.Interfaces;
using System;

namespace Snake
{
    public sealed class MenuProcessor
    {
        private readonly IPrinter _Printer;
        public MenuProcessor()
        {
            _Printer = new Printer(new(0,0));
        }

        public void InitializeMenu()
        {
            _Printer.PrintText(DisplayTable.HeaderText_1);
            _Printer.PrintText(DisplayTable.HeaderText_2);
            _Printer.PrintText(DisplayTable.SelectDifficultyInfo);
            _Printer.PrintText(DisplayTable.DifficultyEasy);
            _Printer.PrintText(DisplayTable.DifficultyMedium);
            _Printer.PrintText(DisplayTable.DifficultyHard);
        }
        public GameConfiguration ReadConfiguration() 
        {
            var iterator = 0;
            ConsoleKey key = ConsoleKey.NoName;
            var difficulties = Enum.GetValues<Difficulty>();
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow)
                {
                    if(iterator == difficulties.Length-1)
                        iterator = 0;
                    else
                        iterator++;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    if(iterator==0)
                        iterator = difficulties.Length - 1;
                    else
                        iterator--;
                }
                printDifficultyOptions(difficulties[iterator]);
            }


            return new GameConfiguration
            {
                BoardHeight = 10,
                BoardWidth = 20,
                Difficulty = difficulties[iterator]
            };
        }
       
        public void ClearMenu()
        {
            _Printer.ClearText(DisplayTable.SelectDifficultyInfo);
            _Printer.ClearText(DisplayTable.DifficultyEasy);
            _Printer.ClearText(DisplayTable.DifficultyMedium);
            _Printer.ClearText(DisplayTable.DifficultyHard);
            _Printer.ClearText(DisplayTable.Win);
            _Printer.ClearText(DisplayTable.Lose);
            _Printer.ClearText(DisplayTable.PlayAgainKeyToPressInfo);
            _Printer.ClearText(DisplayTable.QuitKeyToPressInfo);
        }
        public void PrintResultScreen(GameResult result)
        {
            switch (result)
            {
                case GameResult.WIN:
                    _Printer.PrintText(DisplayTable.Win);
                    break;
                case GameResult.LOSE:
                    _Printer.PrintText(DisplayTable.Lose);
                    break;
            }
            _Printer.PrintText(DisplayTable.PlayAgainKeyToPressInfo);
            _Printer.PrintText(DisplayTable.QuitKeyToPressInfo);
        }

        private void printDifficultyOptions(Difficulty selectedDifficulty)
        {
            switch (selectedDifficulty)
            {
                case Difficulty.EASY:
                    {
                        _Printer.SelectText(DisplayTable.DifficultyEasy);
                        _Printer.PrintText(DisplayTable.DifficultyMedium);
                        _Printer.PrintText(DisplayTable.DifficultyHard);
                    };
                    break;
                case Difficulty.MEDIUM:
                    {
                        _Printer.PrintText(DisplayTable.DifficultyEasy);
                        _Printer.SelectText(DisplayTable.DifficultyMedium);
                        _Printer.PrintText(DisplayTable.DifficultyHard);
                    };
                    break;
                case Difficulty.HARD:
                    {
                        _Printer.PrintText(DisplayTable.DifficultyEasy);
                        _Printer.PrintText(DisplayTable.DifficultyMedium);
                        _Printer.SelectText(DisplayTable.DifficultyHard);
                    };
                    break;
            }
        }
    }
}
