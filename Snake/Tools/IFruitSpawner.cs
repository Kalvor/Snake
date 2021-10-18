using Snake.Structures;
using System.Collections.Generic;

namespace Snake.Tools
{
    public interface IFruitSpawner
    {
        Fruit SpawnFruit(Dictionary<Point, BoardField> fields);
    }
}
