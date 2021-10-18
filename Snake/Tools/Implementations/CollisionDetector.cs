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
            return false;
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
