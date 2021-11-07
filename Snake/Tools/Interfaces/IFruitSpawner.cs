using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IFruitSpawner
    {
        Fruit SpawnFruit(Board board);
        bool CanSpawnFruit(Board board);
    }
}
