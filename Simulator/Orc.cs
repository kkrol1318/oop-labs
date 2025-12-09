namespace Simulator;

public class Orc : Creature
{
    private int _rage = 0;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() { }

    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public override string Greeting()
    {
        return $"Hi! I'm {Name} at level {Level}.";
    }

    public void Hunt()
    {
        _huntCount++;

        if (_huntCount % 2 == 0)
        {
            _rage = Validator.Limiter(_rage + 1, 0, 10);
        }
    }

    public override string Info => $"{Name} [{Level}][{Rage}]";

    public override int Power => 7 * Level + 3 * Rage;

    public override char Symbol => 'O';

}
