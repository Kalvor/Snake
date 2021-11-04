using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface ISnakeMover
    {
        void MoveSnake(Structures.Snake snake, Direction direction, Board board);
    }
}
