using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> Objects { get; }

    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    private readonly List<Direction> _moves;
    private int _turn = 0;

    public IMappable CurrentObject
    {
        get
        {
            if (Objects.Count == 0)
                throw new InvalidOperationException("No objects in simulation.");

            int idx = _turn % Objects.Count;
            return Objects[idx];
        }
    }

    public string CurrentMoveName
    {
        get
        {
            if (_moves.Count == 0)
                return "";

            var d = _moves[_turn % _moves.Count];
            return d.ToString().ToLower();
        }
    }

    public Simulation(
        Map map,
        List<IMappable> objects,
        List<Point> positions,
        string moves)
    {
        if (objects is null || objects.Count == 0)
            throw new ArgumentException("Objects list cannot be empty.");

        if (positions is null || objects.Count != positions.Count)
            throw new ArgumentException(
                "Objects count must match positions count."
            );

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Objects = objects;
        Positions = positions;
        Moves = moves ?? "";

        _moves = DirectionParser.Parse(Moves);

        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].AssignMap(map, positions[i]);
        }

    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation already finished.");

        if (_turn >= _moves.Count)
        {
            Finished = true;
            return;
        }

        var obj = Objects[_turn % Objects.Count];
        var direction = _moves[_turn];

        obj.Go(direction);

        _turn++;

        if (_turn >= _moves.Count)
            Finished = true;

    }



    public Point MapPositionOf(IMappable obj)
    {
        return Map.PositionOf(obj);
    }
}
