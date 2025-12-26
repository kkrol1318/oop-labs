namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
        => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";

    public override void Go(Direction direction)
    {
        if (Map is null || Position is null)
            return;

        var current = Position.Value;
        Point next;

        if (CanFly)
        {
            next = Map.Next(current, direction);
            next = Map.Next(next, direction);
        }
        else
        {
            next = Map.NextDiagonal(current, direction);
        }

        Map.Move(this, current, next);
        Position = next;
    }
}
