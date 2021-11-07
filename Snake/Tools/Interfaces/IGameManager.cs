using Snake.Enums;
using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IGameManager
    {
        void PrintMenu();
        void PrintResultScreen(GameResult result);
        void ClearMenu();
        GameResult StartGame(GameConfiguration gameConfiguration);
        GameConfiguration ReadConfiguration();
        bool CanRunProgramLoop();
    }
}
