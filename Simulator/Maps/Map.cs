using Simulator.Maps;

namespace Simulator.Maps;

public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<IMappable>> _objects = new();

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

    public void Add(IMappable obj, Point p)
    {
        if (obj is null)
            throw new ArgumentNullException(nameof(obj));

        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p),
                "Point does not belong to the map.");

        if (!_objects.TryGetValue(p, out var list))
        {
            list = new List<IMappable>();
            _objects[p] = list;
        }

        if (!list.Contains(obj))
            list.Add(obj);
    }

    public void Remove(IMappable obj, Point p)
    {
        if (obj is null)
            return;

        if (!_objects.TryGetValue(p, out var list))
            return;

        list.Remove(obj);
        if (list.Count == 0)
            _objects.Remove(p);
    }

    public void Move(IMappable obj, Point from, Point to)
    {
        Remove(obj, from);
        Add(obj, to);
    }

    public IEnumerable<IMappable> At(Point p)
        => _objects.TryGetValue(p, out var list)
            ? list
            : Enumerable.Empty<IMappable>();

    public IEnumerable<IMappable> At(int x, int y)
        => At(new Point(x, y));

    public Point PositionOf(IMappable obj)
    {
        foreach (var kv in _objects)
        {
            if (kv.Value.Contains(obj))
                return kv.Key;
        }

        throw new ArgumentException(
            "Object is not on this map.",
            nameof(obj)
        );
    }
}
