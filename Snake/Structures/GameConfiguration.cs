using Snake.Enums;

namespace Snake.Structures
{
    public sealed class GameConfiguration
    {
        public GameConfiguration(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }
        public Difficulty Difficulty { get; set; }

        public int BoardWidth => Difficulty switch
        {
            Difficulty.EASY => 20,
            Difficulty.MEDIUM => 30,
            Difficulty.HARD => 30,
            _ => throw new System.NotImplementedException()
        };

        public int BoardHeight => Difficulty switch
        {
            Difficulty.EASY => 10,
            Difficulty.MEDIUM => 20,
            Difficulty.HARD => 30,
            _ => throw new System.NotImplementedException()
        };

        public int GameCycleMsInterval => Difficulty switch
        {
            Difficulty.EASY => 100,
            Difficulty.MEDIUM => 75,
            Difficulty.HARD => 50,
            _ => throw new System.NotImplementedException()
        };
    }
}
