using System.Collections.Generic;

namespace Snake.Structures
{
    public sealed class Snake
    {
        public SnakeNode Head { get; init; }
        public Snake(Point initialLocation, int numberOfSegments = 4)
        {
            Head = new SnakeNode(initialLocation);
            for(int i=1;i<=numberOfSegments;i++)
            {
                AddNode(new(initialLocation.XCord - i, initialLocation.YCord));
            }
        }

        public void AddNode(Point nodeLocation)
        {
            var lastNode = getLastNode();
            lastNode.NextNode = new SnakeNode(nodeLocation);
        }
        public SnakeNode GetTail()
        {
            return getLastNode();
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

        private SnakeNode getLastNode()
        {
            var currentNode = Head;
            while (currentNode.NextNode is not null)
            {
                currentNode = currentNode.NextNode;
            }
            return currentNode;
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
