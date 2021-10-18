using Snake.Structures;

namespace Snake.Tools.Interfaces
{
    public interface IFruitSpawner
    {
        Fruit SpawnFruit(ref Board board);
    }
}
