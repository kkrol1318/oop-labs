
namespace Simulator;

public class Orc : Creature
{
    private int _rage = 0;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        init => _rage = LimitStat(value);
    }

    public Orc() { }

    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} at level {Level}.");
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        _huntCount++;

        if (_huntCount % 2 == 0)
        {
            _rage = LimitStat(_rage + 1);
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    private static int LimitStat(int value)
    {
        if (value < 0) return 0;
        if (value > 10) return 10;
        return value;
    }
}
