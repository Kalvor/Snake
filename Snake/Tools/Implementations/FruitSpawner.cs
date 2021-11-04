using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class FruitSpawner : IFruitSpawner
    {
        public Fruit SpawnFruit(Board board)
        {
            var fieldToSpawnFruitOn = board.Fields
                .Where(c => c.Value.Field == DisplayTable.Empty)
                .OrderBy(c => Guid.NewGuid())
                .Take(1)
                .First();

            fieldToSpawnFruitOn.Value.SetField(DisplayTable.Fruit);

            return new Fruit(fieldToSpawnFruitOn.Key);
        }
    }
}
