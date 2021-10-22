using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Implementations;
using System;

namespace Snake
{
    public sealed class MenuProcessor
    {
        private readonly Printer _Printer;
        public MenuProcessor()
        {
            _Printer = new Printer(new(0,0));
        }
        public void InitializeMenu()
        {
            _Printer.PrintText(DisplayTable.HeaderText_1);
        }
        public GameConfiguration ReadConfiguraiton() 
        {
            var iterator = 0;
            ConsoleKey key = ConsoleKey.NoName;
            var difficulties = Enum.GetValues<Difficulty>();
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow && iterator < difficulties.Length-1) iterator++;
                if (key == ConsoleKey.UpArrow && iterator>0) iterator--;
            }
            return new GameConfiguration
            {
                BoardHeight = 10,
                BoardWidth = 20,
                Difficulty = difficulties[iterator]
            };
        }
    }
}
