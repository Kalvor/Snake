using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface ICollisionDetector
    {
        bool CheckForFruitCollisionInNextMove(SnakeNode snakeHead, Fruit[] fruits, Direction direction);
        bool CheckForSelfCollision(Structures.Snake snake);
        bool CheckForBorderCollision(SnakeNode snakeHead, Board board);
    }
}
