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
        private volatile GameResult _Result;

        private readonly IPrinter _Pritner;
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
            _Pritner = new Printer(initialCursorPosition);
            _FruitSpawner = new FruitSpawner();
            _SnakeMover = new SnakeMover();
            _CollisionDetector = new CollisionDetector();

            _Difficulty = configuration.Difficulty;
            _CurrentDirection = Direction.NONE;

            _Snake = new Structures.Snake(new((configuration.BoardWidth / 2) - 1, configuration.BoardHeight / 2));
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();
            _SnakeMover.MoveSnake(ref _Snake, Direction.RIGHT, ref _Board);

            _Fruits = new List<Fruit>()
            {
                _FruitSpawner.SpawnFruit(ref _Board),
                _FruitSpawner.SpawnFruit(ref _Board),
                _FruitSpawner.SpawnFruit(ref _Board)
            };

        }

        public GameResult Start()
        {
            _ = beginMovementCycle(getMsInterval(_Difficulty), _Cts.Token);
            while(_Cts.Token.IsCancellationRequested == false)
            {
                processKey(System.Console.ReadKey(true));            
            }
            _Pritner.ClearBoard(ref _Board);
            return _Result;
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
                    _Result = GameResult.LOSE;
                }

                if (_CollisionDetector.CheckForFruitCollision(_Snake.Head, _Fruits.ToArray()))
                {
                    _Snake.AddNode();
                    _Fruits.Remove(_Fruits.FirstOrDefault(c => c.Location == _Snake.Head.Location));
                    _Fruits.Add(_FruitSpawner.SpawnFruit(ref _Board));
                }   
                
                _Pritner.PrintBoard(ref _Board);
            }
        }
        private void processKey(System.ConsoleKeyInfo pressedKey)
        {
            if(pressedKey.Key == System.ConsoleKey.Escape)
            {
                _Result = GameResult.STOPED;
                _Cts.Cancel();
            }
            else
            {
                var requestedDirection = pressedKey.Key switch
                {
                    System.ConsoleKey.DownArrow => Direction.DOWN,
                    System.ConsoleKey.UpArrow => Direction.UP,
                    System.ConsoleKey.RightArrow => Direction.RIGHT,
                    System.ConsoleKey.LeftArrow => Direction.LEFT,
                    _ => _CurrentDirection
                };
                if(!isDirectionOpposite(_CurrentDirection,requestedDirection))
                {
                    _CurrentDirection = requestedDirection;
                }
            }
        }
        private bool isDirectionOpposite(Direction currentDirection, Direction requestedDirection)
        {
            return (currentDirection, requestedDirection) switch
            {
                (Direction.RIGHT,Direction.LEFT) or
                (Direction.LEFT,Direction.RIGHT) or
                (Direction.DOWN,Direction.UP) or
                (Direction.UP,Direction.DOWN) => true,
                _ => false
            };
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
