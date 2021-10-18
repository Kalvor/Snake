using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface ISnakeMover
    {
        void MoveSnake(ref Structures.Snake snake, Direction direction, ref Board board);
    }
}
