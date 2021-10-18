using System.Collections.Generic;

namespace Snake.Structures
{
    public sealed class Snake
    {
        public SnakeNode Head { get; init; }
        public Snake(Point initialLocation)
        {
            Head = new SnakeNode(initialLocation);
        }

        public void AddNode()
        {
            var currentNode = Head;
            while(currentNode.NextNode is not null)
            {
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = new SnakeNode(new Point(currentNode.Location.XCord-1,currentNode.Location.YCord));
        }
        public IEnumerable<Point> GetAllNodesLocations()
        {
            var currentNode = Head;
            while(currentNode is not null)
            {
                yield return currentNode.Location;
                currentNode = currentNode.NextNode;
            }
        }
    }
    public sealed class SnakeNode
    {
        public Point Location { get; set; }
        public SnakeNode NextNode { get; set; }
        public SnakeNode(Point location)
        {
            Location = location;
            NextNode = null;
        }
    }
}
