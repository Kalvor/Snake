using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface ICollisionDetector
    {
        bool CheckForFruitCollision(SnakeNode snakeHead, Fruit[] fruits);
        bool CheckForSelfCollision(Structures.Snake snake);
        bool CheckForBorderCollision(SnakeNode snakeHead, Board board);
    }
}
