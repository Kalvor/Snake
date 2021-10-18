namespace Snake.Structures
{
    public sealed class Fruit
    {
        public Point Location { get; set; }

        public Fruit(Point location)
        {
            Location = location;
        }
    }
}
