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
                .Where(c => c.Value.Field == DisplayTable.Fields.Empty)
                .OrderBy(c => Guid.NewGuid())
                .Take(1)
                .First();

            fieldToSpawnFruitOn.Value.SetField(DisplayTable.Fields.Fruit);

            return new Fruit(fieldToSpawnFruitOn.Key);
        }
    }
}
