using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class SnakeMover : ISnakeMover
    {
        public void MoveSnake(ref Structures.Snake snake, Direction direction, ref Board board)
        {
            if (direction == Direction.NONE) return;

            if (snake.Head.NextNode is not null)
            {
                moveToSnakeNodeParentLocation(snake.Head.NextNode, snake.Head.Location, ref board);
            }

            switch (direction)
            {
                case Direction.DOWN:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord, snake.Head.Location.YCord + 1);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.SnakeHeadDown);
                    };
                    break;
                case Direction.UP:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord, snake.Head.Location.YCord - 1);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.SnakeHeadUp);
                    };
                    break;
                case Direction.RIGHT:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord + 1, snake.Head.Location.YCord);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.SnakeHeadRight);
                    };
                    break;
                case Direction.LEFT:
                    {
                        snake.Head.Location = new(snake.Head.Location.XCord - 1, snake.Head.Location.YCord);
                        board.Fields[snake.Head.Location].SetField(DisplayTable.SnakeHeadLeft);
                    }; break;
            }
        }
        private void moveToSnakeNodeParentLocation(SnakeNode nodeToMove, Point parentNodeLocation, ref Board board)
        {
            if (nodeToMove.NextNode is not null)
            {
                moveToSnakeNodeParentLocation(nodeToMove.NextNode, nodeToMove.Location, ref board);
            }
            else
            {
                board.Fields[nodeToMove.Location].SetField(DisplayTable.Empty);
            }
            nodeToMove.Location = parentNodeLocation;
            board.Fields[nodeToMove.Location].SetField(DisplayTable.SnakeBody);

        }

    }
}
