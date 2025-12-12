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
