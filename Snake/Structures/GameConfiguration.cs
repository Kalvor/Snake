using Snake.Enums;

namespace Snake.Structures
{
    public sealed class GameConfiguration
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public Difficulty Difficulty { get; set; }
        public int GameCycleMsInterval => Difficulty switch
        {
            Difficulty.EASY => 100,
            Difficulty.MEDIUM => 75,
            Difficulty.HARD => 50,
            _ => throw new System.NotImplementedException()
        };
    }
}
