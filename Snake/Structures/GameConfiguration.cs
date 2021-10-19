using Snake.Enums;

namespace Snake.Structures
{
    public sealed class GameConfiguration
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
