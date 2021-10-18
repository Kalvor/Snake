using Snake.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Tools
{
    public sealed class FruitSpawner : IFruitSpawner
    {
        public Fruit SpawnFruit(Dictionary<Point, BoardField> fields)
        {
            var allowedFields = fields
                .Where(c => c.Value.CharToPrint == DisplayTable.Empty);
            var fieldToSpawnFruitOn = allowedFields
                .OrderBy(c => Guid.NewGuid())
                .Take(1)
                .First();
            fieldToSpawnFruitOn.Value.SetCharFunc(DisplayTable.Fruit);

            return new Fruit(fieldToSpawnFruitOn.Key);
        }
    }
}
