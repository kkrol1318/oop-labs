namespace Simulator.Maps;

public interface IMappable
{
    char Symbol { get; }
    string Info { get; }

    void AssignMap(Map map, Point position);
    void Go(Direction direction);
}
