namespace Snake.Structures
{
    public sealed class Point
    {
        public int XCord { get; init; }
        public int YCord { get; init; }
        public Point(int xCord, int yCord)
        {
            XCord = xCord;
            YCord = yCord;
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Point) return false;
            var castedObj = obj as Point;
            return castedObj.XCord == this.XCord && castedObj.YCord == this.YCord;
        }
        public override int GetHashCode()
        {
            return this.XCord.GetHashCode() ^ this.YCord.GetHashCode();
        }
    }
}
