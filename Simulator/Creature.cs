using Simulator.Maps;

namespace Simulator;

public abstract class Creature
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

    public Map? Map { get; private set; }

    public Point? Position { get; private set; }

    protected Creature() { }

    protected Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public override string ToString()
    {
        string typeName = GetType().Name.ToUpperInvariant();
        return $"{typeName}: {Info}";
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

    public void RemoveFromMap()
    {
        if (Map is null || Position is null)
            return;

        Map.Remove(this, Position.Value);
        Map = null;
        Position = null;
    }

    public void Go(Direction direction)
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

        string s = Validator.Shortener(baseValue, min: 3, max: 25, placeholder: '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }

    private static int ValidateLevel(int value)
    {
        return Validator.Limiter(value, 1, 10);
    }
}
