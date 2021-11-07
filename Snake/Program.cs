using Microsoft.Extensions.DependencyInjection;
using Snake.Tools.Implementations;
using Snake.Tools.Interfaces;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IPrinter, Printer>();
            services.AddTransient<ISnakeMover, SnakeMover>();
            services.AddTransient<IFruitSpawner, FruitSpawner>();
            services.AddTransient<ICollisionDetector, CollisionDetector>();
            services.AddTransient<IGameManager, GameManager>();
            services.AddTransient<IGameProcessor, GameProcessor>();
            
            IGameManager gameManager = services.BuildServiceProvider().GetRequiredService<IGameManager>();
            do
            {
                gameManager.PrintMenu();
                var gameConfig = gameManager.ReadConfiguration();
                gameManager.ClearMenu();
                var gameResult = gameManager.StartGame(gameConfig);
                gameManager.PrintResultScreen(gameResult);
            }
            while (gameManager.CanRunProgramLoop());
            
        }
    }
}
