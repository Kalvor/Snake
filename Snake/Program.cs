using Snake.Structures;
using Snake.Tools;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameProcessor = new GameProcessor(40, 20, 0, 0, Enums.Difficulty.MEDIUM);
            gameProcessor.Start();
        }
    }
}
