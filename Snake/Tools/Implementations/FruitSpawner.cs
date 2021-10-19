using Snake.Structures;
using System;
using System.Linq;
using Snake.Tools.Interfaces;

namespace Snake.Tools.Implementations
{
    public sealed class FruitSpawner : IFruitSpawner
    {
        public Fruit SpawnFruit(ref Board board)
        {
            var allowedFields = board.Fields
                .Where(c => c.Value.CharToPrint == DisplayTable.Empty.CharToPrint);
            var fieldToSpawnFruitOn = allowedFields
                .OrderBy(c => Guid.NewGuid())
                .Take(1)
                .First();
            fieldToSpawnFruitOn.Value.SetField(DisplayTable.Fruit);

            return new Fruit(fieldToSpawnFruitOn.Key);
        }
    }
}
