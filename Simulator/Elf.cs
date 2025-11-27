
namespace Simulator;

public class Elf : Creature
{
    private int _agility = 0;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        init => _agility = LimitStat(value);
    }

    public Elf() { }

    public Elf(string name, int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} at level {Level}.");
    }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        _singCount++;

        if (_singCount % 3 == 0)
        {
            _agility = LimitStat(_agility + 1);
        }
    }

    public override int Power => 8 * Level + 2 * Agility;

    private static int LimitStat(int value)
    {
        if (value < 0) return 0;
        if (value > 10) return 10;
        return value;
    }
}
