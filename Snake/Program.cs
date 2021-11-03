using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            bool runProgramLoop = true;
            var menuProcessor = new MenuProcessor();
            menuProcessor.InitializeMenu();
            var configuration = menuProcessor.ReadConfiguration();
            do
            {
                menuProcessor.ClearMenu();

                var gameProcessor = new GameProcessor(
                    configuration, 
                    new((Console.WindowWidth - configuration.BoardWidth) / 2, 5));

                var result = gameProcessor.Start();

                menuProcessor.PrintResultScreen(result);
                var pressedCharacter = Console.ReadKey(true).Key;
                while(pressedCharacter != ConsoleKey.Enter && pressedCharacter != ConsoleKey.Escape)
                {
                    pressedCharacter = Console.ReadKey(true).Key;
                }
                if (pressedCharacter == ConsoleKey.Escape) runProgramLoop = false;
                if (pressedCharacter == ConsoleKey.Enter) runProgramLoop = true;
            }
            while(runProgramLoop);
        }
    }
}
