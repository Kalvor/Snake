using Snake.Enums;
using Snake.Structures;
using Snake.Tools.Interfaces;
using System.Linq;

namespace Snake.Tools.Implementations
{
    public sealed class CollisionDetector : ICollisionDetector
    {
        public bool CheckForBorderCollision(SnakeNode snakeHead, Board board)
        {
            return snakeHead.Location.XCord == 0 ||
                   snakeHead.Location.YCord == 0 ||
                   snakeHead.Location.XCord == board.Fields.Max(c => c.Key.XCord) ||
                   snakeHead.Location.YCord == board.Fields.Max(c => c.Key.YCord);
        }

        public bool CheckForFruitCollisionInNextMove(SnakeNode snakeHead, Fruit[] fruits, Direction direction)
        {
            Point newHeadLocation = direction switch
            {
                Direction.UP => new(snakeHead.Location.XCord, snakeHead.Location.YCord - 1),
                Direction.DOWN => new(snakeHead.Location.XCord, snakeHead.Location.YCord + 1),
                Direction.LEFT => new(snakeHead.Location.XCord - 1, snakeHead.Location.YCord),
                Direction.RIGHT => new(snakeHead.Location.XCord + 1, snakeHead.Location.YCord),
                Direction.NONE => new(snakeHead.Location.XCord, snakeHead.Location.YCord),
                _ => throw new System.Exception()
            };
            var isAnyFrutAtMovedHeadLocation = fruits.Any(c => c.Location == newHeadLocation);
            return isAnyFrutAtMovedHeadLocation;
        }

        public bool CheckForSelfCollision(Structures.Snake snake)
        {
            return snake.GetAllNodesLocations().GroupBy(c => c).Any(c => c.Count() > 1);
        }
    }
}
