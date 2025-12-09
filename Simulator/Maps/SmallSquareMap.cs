using System;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private readonly Rectangle _bounds;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size),
                "Size must be between 5 and 20.");

        Size = size;

        _bounds = new Rectangle(0, 0, size - 1, size - 1);
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size &&
               p.Y >= 0 && p.Y < Size;
    }


    public override Point Next(Point p, Direction d)
    {
        Point next = p.Next(d);

        if (!Exist(next))
            return p;

        return next;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point next = p.NextDiagonal(d);

        if (!Exist(next))
            return p;

        return next;
    }

}
