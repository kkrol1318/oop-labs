using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSwapCoordinates_WhenNeeded()
    {
        var r = new Rectangle(8, 9, 3, 4);
        Assert.Equal(3, r.X1);
        Assert.Equal(4, r.Y1);
        Assert.Equal(8, r.X2);
        Assert.Equal(9, r.Y2);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenPointsAreCollinear()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(2, 2, 7, 2));
    }

    [Fact]
    public void Contains_ShouldReturnCorrectValues()
    {
        var r = new Rectangle(0, 0, 5, 5);

        Assert.True(r.Contains(new Point(0, 0)));   // corner
        Assert.True(r.Contains(new Point(5, 5)));   // opposite corner
        Assert.True(r.Contains(new Point(2, 3)));   // inside

        Assert.False(r.Contains(new Point(-1, 0))); // outside
        Assert.False(r.Contains(new Point(6, 6)));  // outside
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var r = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2):(3, 4)", r.ToString());
    }
}
