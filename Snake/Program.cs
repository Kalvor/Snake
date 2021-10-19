using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            var menuProcessor = new MenuProcessor();
            menuProcessor.InitializeMenu();
            var configuration = menuProcessor.ReadConfiguraiton();

            var gameProcessor = new GameProcessor(
                configuration, 
                new((Console.WindowWidth - configuration.BoardWidth) / 2, 5));
            gameProcessor.Start();
        }
    }
}
