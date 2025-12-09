using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        var m = new SmallSquareMap(10);
        Assert.Equal(10, m.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(4, 4, true)]
    [InlineData(5, 5, false)]
    [InlineData(-1, 2, false)]
    public void Exist_ShouldReturnCorrectValues(int x, int y, bool expected)
    {
        var m = new SmallSquareMap(5);
        Assert.Equal(expected, m.Exist(new Point(x, y)));
    }

    [Theory]
    [InlineData(3, 3, Direction.Up, 3, 4)]
    [InlineData(4, 4, Direction.Up, 4, 4)]   // cannot move outside
    [InlineData(0, 2, Direction.Left, 0, 2)]
    public void Next_ShouldHandleBoundaries(int x, int y, Direction d, int ex, int ey)
    {
        var m = new SmallSquareMap(5);
        var p = new Point(x, y);
        var next = m.Next(p, d);
        Assert.Equal(new Point(ex, ey), next);
    }
}
