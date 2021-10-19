using Snake.Structures;
using Snake.Tools.Implementations;
using Snake.Tools.Interfaces;

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
            _Printer.PrintHeader("SNAKE GAME","By Krzysztof Jadczak");
            _Printer.PrintMenuOptions();
        }
        public GameConfiguration ReadConfiguraiton() 
        {
            System.Console.ReadKey(true);
            return new GameConfiguration
            {
                BoardHeight = 10,
                BoardWidth = 20,
                Difficulty = Enums.Difficulty.MEDIUM
            };
        }
    }
}
