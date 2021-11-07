using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake.Tools.Implementations
{
    public sealed class GameProcessor : IGameProcessor
    {
        private Board _Board;
        private Structures.Snake _Snake;
        private List<Fruit> _Fruits;

        private readonly IPrinter _Pritner;
        private readonly IFruitSpawner _FruitSpawner;
        private readonly ISnakeMover _SnakeMover;
        private readonly ICollisionDetector _CollisionDetector;

        private volatile Direction _CurrentDirection;
        private volatile GameResult _Result;

        private CancellationTokenSource _Cts;

        public GameProcessor(IPrinter pritner, IFruitSpawner fruitSpawner, ISnakeMover snakeMover, ICollisionDetector collisionDetector)
        {
            _Pritner = pritner;
            _FruitSpawner = fruitSpawner;
            _SnakeMover = snakeMover;
            _CollisionDetector = collisionDetector;         
        }

        public GameResult Start(GameConfiguration gameConfiguration)
        {
            initializeGameEnv(gameConfiguration);
            _ = beginMovementCycle(gameConfiguration.GameCycleMsInterval, _Cts.Token);
            while (_Cts.Token.IsCancellationRequested == false)
            {
                processKey(waitForKey());
            }
            _Pritner.ClearBoard(_Board);
            return _Result;
        }

        private void initializeGameEnv(GameConfiguration gameConfiguration)
        {
            Point initialSnakePosition = new((gameConfiguration.BoardWidth / 2) - 1, gameConfiguration.BoardHeight / 2);
            _Board = new Board(gameConfiguration.BoardWidth, gameConfiguration.BoardHeight);
            _Snake = new Structures.Snake(initialSnakePosition, 3);
            _Pritner.SetInitialBoardPosition(new((Console.WindowWidth - gameConfiguration.BoardWidth) / 2, 5));
            _SnakeMover.MoveSnake(_Snake, Direction.RIGHT, _Board);
            _CurrentDirection = Direction.NONE;
            _Cts = new CancellationTokenSource();

            _Fruits = new List<Fruit>()
            {
                _FruitSpawner.SpawnFruit(_Board),
                _FruitSpawner.SpawnFruit(_Board),
                _FruitSpawner.SpawnFruit(_Board)
            };
        }
        private async Task beginMovementCycle(int intervalMs, CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await Task.Delay(intervalMs, cancellationToken);

                bool willFruitBeConsumed = _CollisionDetector.CheckForFruitCollisionInNextMove(_Snake.Head, _Fruits.ToArray(), _CurrentDirection);
                if (willFruitBeConsumed)
                {
                    var lastNodeLocation = _Snake.GetTail().Location;
                    _SnakeMover.MoveSnake(_Snake, _CurrentDirection, _Board);
                    _Snake.AddNode(lastNodeLocation);

                    if(!_FruitSpawner.CanSpawnFruit(_Board))
                    {
                        _Cts.Cancel();
                        _Result = GameResult.WIN;
                    }
                    else
                    {
                        _Fruits.Remove(_Fruits.FirstOrDefault(c => c.Location == _Snake.Head.Location));
                        _Fruits.Add(_FruitSpawner.SpawnFruit(_Board));
                    }
                }
                else
                {
                    _SnakeMover.MoveSnake(_Snake, _CurrentDirection, _Board);
                    if (_CollisionDetector.CheckForSelfCollision(_Snake) || _CollisionDetector.CheckForBorderCollision(_Snake.Head, _Board))
                    {
                        _Cts.Cancel();
                        _Result = GameResult.LOSE;
                    }
                }

                _Pritner.PrintBoard(_Board);
            }
        }
        private ConsoleKeyInfo waitForKey()
        {
            int delay = 0;
            while (delay < 50)
            {
                if (Console.KeyAvailable)
                {
                    return Console.ReadKey(true);
                }
                Thread.Sleep(50);
                delay += 50;
            }
            return new ConsoleKeyInfo();
        }
        private void processKey(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.Escape)
            {
                _Result = GameResult.STOPED;
                _Cts.Cancel();
            }
            else
            {
                var requestedDirection = convertKeyToDirection(pressedKey.Key);
                if (!isDirectionOpposite(_CurrentDirection, requestedDirection))
                {
                    _CurrentDirection = requestedDirection;
                }
            }
        }
        private Direction convertKeyToDirection(ConsoleKey key) => key switch
        {
            ConsoleKey.DownArrow => Direction.DOWN,
            ConsoleKey.UpArrow => Direction.UP,
            ConsoleKey.RightArrow => Direction.RIGHT,
            ConsoleKey.LeftArrow => Direction.LEFT,
            _ => _CurrentDirection
        };
        private bool isDirectionOpposite(Direction currentDirection, Direction requestedDirection) => (currentDirection, requestedDirection) switch
        {
            (Direction.RIGHT, Direction.LEFT) or
            (Direction.LEFT, Direction.RIGHT) or
            (Direction.DOWN, Direction.UP) or
            (Direction.UP, Direction.DOWN) => true,
            _ => false
        };
    }
}
