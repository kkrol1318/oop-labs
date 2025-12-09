namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int sizeX, int sizeY)
        : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeX),
                "Dimensions must be ≤ 20.");
    }

    public override bool Exist(Point p)
        => p.X >= 0 && p.X < SizeX
        && p.Y >= 0 && p.Y < SizeY;

    public override Point Next(Point p, Direction d)
    {
        var n = p.Next(d);
        int x = (n.X % SizeX + SizeX) % SizeX;
        int y = (n.Y % SizeY + SizeY) % SizeY;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var n = p.NextDiagonal(d);
        int x = (n.X % SizeX + SizeX) % SizeX;
        int y = (n.Y % SizeY + SizeY) % SizeY;
        return new Point(x, y);
    }
}
