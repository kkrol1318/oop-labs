using System;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public SmallSquareMap(int size)
        : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size),
                "Max size is 20.");
    }

    public override bool Exist(Point p)
        => p.X >= 0 && p.X < SizeX
        && p.Y >= 0 && p.Y < SizeY;

    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return Exist(next) ? next : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var next = p.NextDiagonal(d);
        return Exist(next) ? next : p;
    }
}
