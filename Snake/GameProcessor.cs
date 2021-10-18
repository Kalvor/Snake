using Snake.Enums;
using Snake.Structures;
using Snake.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public sealed class GameProcessor
    {
        private readonly Board _Board;
        private readonly Structures.Snake _Snake;
        private readonly IPrinter _Pritner;
        private readonly Difficulty _Difficulty;
        private Direction _CurrentDirection;
        private readonly CancellationTokenSource _Cts;
        public GameProcessor(int boardWidth, int boardHeight, int initialCursorLeft, int initialCursorTop, Difficulty difficulty)
        {
            _Cts = new CancellationTokenSource();
            _Board = new Board(boardWidth, boardHeight);
            _Pritner = new Printer(new(initialCursorLeft, initialCursorTop));
            _Difficulty = difficulty;
            _CurrentDirection = Direction.NONE;
            _Snake = new Structures.Snake(new(boardWidth / 2, boardHeight / 2));
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();
            _Snake.AddNode();

            var nodesLocations = _Snake.GetAllNodesLocations();
            bool isHead = true;
            foreach (var location in nodesLocations)
            {
                if (isHead)
                {
                    _Board.Data[location].SetCharFunc(DisplayTable.SnakeHeadRight);
                    isHead = false;
                }
                else
                {
                    _Board.Data[location].SetCharFunc(DisplayTable.SnakeBody);
                }
            }
        }
        public void Start()
        {
            _ = BeginMovementCycle(GetMsInterval(_Difficulty), _Cts.Token);
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
                         _  => Direction.NONE
                    };
                }
            }
        }

        private async Task BeginMovementCycle(int intervalMs, CancellationToken cancellationToken)
        {
            while(cancellationToken.IsCancellationRequested == false)
            {
                await Task.Delay(intervalMs,cancellationToken);
                MoveSnake(_CurrentDirection);
                _Pritner.Print(_Board.Data);
            }
        }
        private void MoveSnake(Direction direction)
        {
            if (direction == Direction.NONE) return;

            if(_Snake.Head.NextNode is not null)
            {
                MoveToSnakeNodeParentLocation(_Snake.Head.NextNode, _Snake.Head.Location);
            }

            switch(direction)
            {
                case Direction.DOWN: 
                    { 
                        _Snake.Head.Location = new(_Snake.Head.Location.XCord, _Snake.Head.Location.YCord + 1);
                        _Board.Data[_Snake.Head.Location].SetCharFunc(DisplayTable.SnakeHeadDown);
                    };
                    break;
                case Direction.UP: 
                    {
                        _Snake.Head.Location = new(_Snake.Head.Location.XCord, _Snake.Head.Location.YCord - 1);
                        _Board.Data[_Snake.Head.Location].SetCharFunc(DisplayTable.SnakeHeadUp);
                    };
                    break;
                case Direction.RIGHT: 
                    {
                        _Snake.Head.Location = new(_Snake.Head.Location.XCord + 1, _Snake.Head.Location.YCord);
                        _Board.Data[_Snake.Head.Location].SetCharFunc(DisplayTable.SnakeHeadRight);
                    };
                    break;
                case Direction.LEFT: 
                    {
                        _Snake.Head.Location = new(_Snake.Head.Location.XCord - 1, _Snake.Head.Location.YCord);
                        _Board.Data[_Snake.Head.Location].SetCharFunc(DisplayTable.SnakeHeadLeft);
                    };break;
            }
        }
        private void MoveToSnakeNodeParentLocation(SnakeNode nodeToMove, Point parentNodeLocation)
        {
            if (nodeToMove.NextNode is not null)
            {
                MoveToSnakeNodeParentLocation(nodeToMove.NextNode, nodeToMove.Location);
            }
            else
            {
                _Board.Data[nodeToMove.Location].SetCharFunc(DisplayTable.Empty);
            }
            nodeToMove.Location = parentNodeLocation;
            _Board.Data[nodeToMove.Location].SetCharFunc(DisplayTable.SnakeBody);

        }
        private int GetMsInterval(Difficulty difficulty)
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
