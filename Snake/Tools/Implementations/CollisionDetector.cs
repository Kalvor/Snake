using Snake.Structures;
using Snake.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return false;
        }
    }
}
