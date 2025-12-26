using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "";

    public required string Description
    {
        get => _description;
        init => _description = ValidateDescription(value);
    }

    public uint Size { get; set; } = 3;

    public virtual char Symbol => 'A';
    public virtual string Info => $"{Description} <{Size}>";

    public Map? Map { get; protected set; }
    public Point? Position { get; protected set; }


    public void AssignMap(Map map, Point position)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Position = position;
        map.Add(this, position);
    }

    public void RemoveFromMap()
    {
        if (Map is null || Position is null) return;

        Map.Remove(this, Position.Value);
        Map = null;
        Position = null;
    }

    public virtual void Go(Direction direction)
    {
        if (Map is null || Position is null) return;

        var current = Position.Value;
        var next = Map.Next(current, direction);

        Map.Move(this, current, next);
        Position = next;
    }

    private static string ValidateDescription(string? raw)
    {
        string baseValue = string.IsNullOrWhiteSpace(raw) ? "Unknown" : raw;

        string s = Validator.Shortener(baseValue, min: 3, max: 15, placeholder: '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }

    public override string ToString() => Info;
}
