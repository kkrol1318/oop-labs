namespace Simulator.Maps;

public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<Creature>> _creatures = new();

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX),
                "Map must be at least 5x5.");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Creature creature, Point p)
    {
        if (creature is null)
            throw new ArgumentNullException(nameof(creature));

        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p),
                "Point does not belong to the map.");

        if (!_creatures.TryGetValue(p, out var list))
        {
            list = new List<Creature>();
            _creatures[p] = list;
        }

        if (!list.Contains(creature))
            list.Add(creature);
    }

    public void Remove(Creature creature, Point p)
    {
        if (creature is null)
            return;

        if (!_creatures.TryGetValue(p, out var list))
            return;

        list.Remove(creature);
        if (list.Count == 0)
            _creatures.Remove(p);
    }

    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public IEnumerable<Creature> At(Point p)
        => _creatures.TryGetValue(p, out var list)
            ? list
            : Enumerable.Empty<Creature>();

    public IEnumerable<Creature> At(int x, int y) => At(new Point(x, y));
    public Point PositionOf(Creature creature)
    {
        foreach (var kv in _creatures)
        {
            if (kv.Value.Contains(creature))
                return kv.Key;
        }

        throw new ArgumentException("Creature is not on this map.", nameof(creature));
    }
}
