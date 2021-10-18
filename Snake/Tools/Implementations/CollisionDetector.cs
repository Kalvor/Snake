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

        public bool CheckForFruitCollision(SnakeNode snakeHead, Fruit[] fruits)
        {
            return fruits.Any(c => c.Location == snakeHead.Location);
        }

        public bool CheckForSelfCollision(Structures.Snake snake)
        {
            return snake.GetAllNodesLocations().GroupBy(c => c).Any(c => c.Count() > 1);
        }
    }
}
