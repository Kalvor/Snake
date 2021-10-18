using Snake.Enums;
using Snake.Structures;
using Snake.Tools;

namespace Snake
{
    public sealed class GameProcessor
    {
        private readonly Board _Board;
        private readonly Structures.Snake _Snake;
        private readonly IPrinter _Pritner;
        private readonly Difficulty _Difficulty;
        public GameProcessor(int boardWidth, int boardHeight, int initialCursorLeft, int initialCursorTop, Difficulty difficulty)
        {
            _Board = new Board(boardWidth, boardHeight);
            _Pritner = new Printer(new(initialCursorLeft, initialCursorTop));
            _Difficulty = difficulty;

            _Snake = new Structures.Snake(new(boardWidth / 2, boardHeight / 2));
            _Snake.AddNode();
            _Snake.AddNode();
            this.RegisterSnakeAtBoard();
        }

        private void RegisterSnakeAtBoard()
        {
            var nodesLocations = _Snake.GetAllNodesLocations();
            foreach(var location in nodesLocations)
            {
                _Board.Data[location].SetCharFunc(DisplayTable.SnakeBody);
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
        }
    }
}
