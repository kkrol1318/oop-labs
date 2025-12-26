using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init => _name = ValidateName(value);
    }

    public int Level
    {
        get => _level;
        init => _level = ValidateLevel(value);
    }

    public abstract string Info { get; }
    public virtual char Symbol => '?';

    public Map? Map { get; private set; }
    public Point? Position { get; private set; }

    protected Creature() { }

    protected Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Greeting();
    public abstract int Power { get; }

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public void AssignMap(Map map, Point position)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Position = position;

        map.Add(this, position);
    }

    public virtual void Go(Direction direction)
    {
        if (Map is null || Position is null)
            return;

        var current = Position.Value;
        var next = Map.Next(current, direction);

        Map.Move(this, current, next);
        Position = next;
    }

    private static string ValidateName(string? raw)
    {
        string baseValue = string.IsNullOrWhiteSpace(raw) ? "Unknown" : raw;
        string s = Validator.Shortener(baseValue, 3, 25, '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }

    private static int ValidateLevel(int value)
        => Validator.Limiter(value, 1, 10);
}
