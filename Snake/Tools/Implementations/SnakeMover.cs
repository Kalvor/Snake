using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class SnakeMover : ISnakeMover
    {
        public void MoveSnake(Structures.Snake snake, Direction direction, Board board)
        {
            if (direction == Direction.NONE) return;

            if (snake.Head.NextNode is not null)
            {
                moveToSnakeNodeParentLocation(snake.Head.NextNode, snake.Head.Location, board);
            }

            switch (direction)
            {
                case Direction.DOWN:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord, snake.Head.Location.YCord + 1);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.Fields.SnakeHeadDown);
                    };
                    break;
                case Direction.UP:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord, snake.Head.Location.YCord - 1);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.Fields.SnakeHeadUp);
                    };
                    break;
                case Direction.RIGHT:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord + 1, snake.Head.Location.YCord);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.Fields.SnakeHeadRight);
                    };
                    break;
                case Direction.LEFT:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord - 1, snake.Head.Location.YCord);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.Fields.SnakeHeadLeft);
                    }; break;
            }
        }
        private void moveToSnakeNodeParentLocation(SnakeNode nodeToMove, Point parentNodeLocation, Board board)
        {
            if (nodeToMove.NextNode is not null)
            {
                moveToSnakeNodeParentLocation(nodeToMove.NextNode, nodeToMove.Location, board);
            }
            else
            {
                board.Fields[nodeToMove.Location].SetField(DisplayTable.Fields.Empty);
            }
            nodeToMove.Location = parentNodeLocation;
            board.Fields[nodeToMove.Location].SetField(DisplayTable.Fields.SnakeBody);

        }

    }
}
