using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IGameProcessor
    {
        GameResult Start(GameConfiguration gameConfiguration);
    }
}
