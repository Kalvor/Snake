using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Implementations;
using Snake.Tools.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public sealed class GameProcessor
    {
        private Board _Board;
        private Structures.Snake _Snake;
        private List<Fruit> _Fruits;

        private readonly IBoardPrinter _Pritner;
        private readonly IFruitSpawner _FruitSpawner;
        private readonly ISnakeMover _SnakeMover;
        private readonly ICollisionDetector _CollisionDetector;

        private readonly Difficulty _Difficulty;
        private Direction _CurrentDirection;

        private readonly CancellationTokenSource _Cts;
        public GameProcessor(GameConfiguration configuration, Point initialCursorPosition)
        {
            _Cts = new CancellationTokenSource();
            _Board = new Board(configuration.BoardWidth, configuration.BoardHeight);
            _Pritner = new BoardPrinter(initialCursorPosition);
            _FruitSpawner = new FruitSpawner();
            _SnakeMover = new SnakeMover();
            _CollisionDetector = new CollisionDetector();

            _Difficulty = configuration.Difficulty;
            _CurrentDirection = Direction.NONE;

            _Snake = new Structures.Snake(new(configuration.BoardWidth / 2, configuration.BoardHeight / 2));
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();

            _Fruits = new List<Fruit>()
            {
                _FruitSpawner.SpawnFruit(ref _Board),
                _FruitSpawner.SpawnFruit(ref _Board),
                _FruitSpawner.SpawnFruit(ref _Board)
            };

        }
        public void Start()
        {
            _ = beginMovementCycle(getMsInterval(_Difficulty), _Cts.Token);
            while(_Cts.Token.IsCancellationRequested == false)
            {
                var pressedChar = System.Console.ReadKey(true).KeyChar;
                if(pressedChar == 'q')
                {
                    _Cts.Cancel();
                }
                else
                {
                    _CurrentDirection = pressedChar switch
                    {
                        'w' => Direction.UP,
                        's' => Direction.DOWN,
                        'a' => Direction.LEFT,
                        'd' => Direction.RIGHT,
                         _  => _CurrentDirection
                    };
                }
            }
        }

        private async Task beginMovementCycle(int intervalMs, CancellationToken cancellationToken)
        {
            while(cancellationToken.IsCancellationRequested == false)
            {
                await Task.Delay(intervalMs,cancellationToken);
                _SnakeMover.MoveSnake(ref _Snake, _CurrentDirection, ref _Board);
                if (_CollisionDetector.CheckForSelfCollision(_Snake) || 
                    _CollisionDetector.CheckForBorderCollision(_Snake.Head, _Board))
                {
                    _Cts.Cancel();
                }
                if (_CollisionDetector.CheckForFruitCollision(_Snake.Head, _Fruits.ToArray()))
                {
                    consumeFruit();       
                }
                
                _Pritner.Print(ref _Board);
            }
        }
        private void consumeFruit()
        {
            _Snake.AddNode();
            _Fruits.Remove(_Fruits.FirstOrDefault(c => c.Location == _Snake.Head.Location));
            _Fruits.Add(_FruitSpawner.SpawnFruit(ref _Board));
        }
        private int getMsInterval(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.EASY => 100,
                Difficulty.MEDIUM => 75,
                Difficulty.HARD => 50,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
