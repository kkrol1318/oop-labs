using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    private readonly List<Direction> _moves;
    private int _turn = 0;

    public Creature CurrentCreature
    {
        get
        {
            if (Creatures.Count == 0)
                throw new InvalidOperationException("No creatures in simulation.");

            int idx = _turn % Creatures.Count;
            return Creatures[idx];
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

    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures is null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");

        if (positions is null || creatures.Count != positions.Count)
            throw new ArgumentException("Creatures count must match positions count.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves ?? "";

        _moves = DirectionParser.Parse(Moves);

        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].AssignMap(map, positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation already finished.");

        if (_moves.Count == 0)
        {
            Finished = true;
            return;
        }

        int moveIndex = _turn % _moves.Count;

        var creature = CurrentCreature;
        var direction = _moves[moveIndex];
        creature.Go(direction);

        _turn++;

        if (_turn >= _moves.Count * Creatures.Count)
            Finished = true;
    }
}
