using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Interfaces;
using System;

namespace Snake.Tools.Implementations
{
    public sealed class GameManager : IGameManager
    {
        private readonly IPrinter _Printer;
        private readonly IGameProcessor _GameProcessor;
        public GameManager(IPrinter printer, IGameProcessor gameProcessor)
        {
            _Printer = printer;
            _Printer.SetInitialBoardPosition(new(0, 0));
            _GameProcessor = gameProcessor;
        }

        public bool CanRunProgramLoop()
        {
            var pressedCharacter = Console.ReadKey(true).Key;
            while (pressedCharacter != ConsoleKey.Enter && pressedCharacter != ConsoleKey.Escape)
            {
                pressedCharacter = Console.ReadKey(true).Key;
            }
            return pressedCharacter == ConsoleKey.Enter;
        }
        public void ClearMenu()
        {
            _Printer.ClearText(DisplayTable.Texts.SelectDifficultyInfo);
            _Printer.ClearText(DisplayTable.Texts.DifficultyEasy);
            _Printer.ClearText(DisplayTable.Texts.DifficultyMedium);
            _Printer.ClearText(DisplayTable.Texts.DifficultyHard);
            _Printer.ClearText(DisplayTable.Texts.Win);
            _Printer.ClearText(DisplayTable.Texts.Lose);
            _Printer.ClearText(DisplayTable.Texts.PlayAgainKeyToPressInfo);
            _Printer.ClearText(DisplayTable.Texts.QuitKeyToPressInfo);
            _Printer.ClearText(DisplayTable.Texts.NavigationInfo);
        }
        public void PrintMenu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            _Printer.PrintText(DisplayTable.Texts.HeaderText_1);
            _Printer.PrintText(DisplayTable.Texts.HeaderText_2);
            _Printer.PrintText(DisplayTable.Texts.SelectDifficultyInfo);
            _Printer.PrintText(DisplayTable.Texts.NavigationInfo);
            _Printer.PrintText(DisplayTable.Texts.DifficultyEasy);
            _Printer.PrintText(DisplayTable.Texts.DifficultyMedium);
            _Printer.PrintText(DisplayTable.Texts.DifficultyHard);
        }
        public void PrintResultScreen(GameResult result)
        {
            switch (result)
            {
                case GameResult.WIN:
                    _Printer.PrintText(DisplayTable.Texts.Win);
                    break;
                case GameResult.LOSE:
                    _Printer.PrintText(DisplayTable.Texts.Lose);
                    break;
            }
            _Printer.PrintText(DisplayTable.Texts.PlayAgainKeyToPressInfo);
            _Printer.PrintText(DisplayTable.Texts.QuitKeyToPressInfo);
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
                    if (iterator == difficulties.Length - 1)
                        iterator = 0;
                    else
                        iterator++;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    if (iterator == 0)
                        iterator = difficulties.Length - 1;
                    else
                        iterator--;
                }

                switch (difficulties[iterator])
                {
                    case Difficulty.EASY:
                        {
                            _Printer.SelectText(DisplayTable.Texts.DifficultyEasy);
                            _Printer.PrintText(DisplayTable.Texts.DifficultyMedium);
                            _Printer.PrintText(DisplayTable.Texts.DifficultyHard);
                        };
                        break;
                    case Difficulty.MEDIUM:
                        {
                            _Printer.PrintText(DisplayTable.Texts.DifficultyEasy);
                            _Printer.SelectText(DisplayTable.Texts.DifficultyMedium);
                            _Printer.PrintText(DisplayTable.Texts.DifficultyHard);
                        };
                        break;
                    case Difficulty.HARD:
                        {
                            _Printer.PrintText(DisplayTable.Texts.DifficultyEasy);
                            _Printer.PrintText(DisplayTable.Texts.DifficultyMedium);
                            _Printer.SelectText(DisplayTable.Texts.DifficultyHard);
                        };
                        break;
                }
            }

            return new GameConfiguration(difficulties[iterator]);
        }
        public GameResult StartGame(GameConfiguration gameConfiguration)
        {
            return _GameProcessor.Start(gameConfiguration);
        }
    }
}
