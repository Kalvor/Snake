using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;

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
                Console.SetCursorPosition(
                    InitialCurosrPosition.XCord + field.Key.XCord, 
                    InitialCurosrPosition.YCord + field.Key.YCord);
                Console.Write(field.Value.CharToPrint);
                field.Value.NeedsRefreshing = false;
            }
        }

        public void PrintHeader(params string[] headerTexts)
        {
            for(int i=0;i<headerTexts.Length;i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - headerTexts[i].Length) / 2, Console.CursorTop + 1 + i);
                Console.Write(headerTexts[i]);
            }     
        }


        public void PrintMenuOptions()
        {
            
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
