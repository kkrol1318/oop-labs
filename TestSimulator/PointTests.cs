using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var p = new Point(3, 7);
        Assert.Equal("(3, 7)", p.ToString());
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(5, 10, Direction.Down, 5, 9)]
    [InlineData(5, 10, Direction.Left, 4, 10)]
    [InlineData(5, 10, Direction.Right, 6, 10)]
    public void Next_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);
        var next = p.Next(d);
        Assert.Equal(new Point(ex, ey), next);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 10, Direction.Down, 4, 9)]
    [InlineData(5, 10, Direction.Left, 4, 11)]
    [InlineData(5, 10, Direction.Right, 6, 9)]
    public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);
        var next = p.NextDiagonal(d);
        Assert.Equal(new Point(ex, ey), next);
    }
}
