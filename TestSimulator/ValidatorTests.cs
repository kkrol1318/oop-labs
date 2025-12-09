using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(-3, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldLimitValue(int input, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(input, min, max));
    }

    [Fact]
    public void Shortener_ShouldTrimAndShorten()
    {
        string input = "   Hello World   ";
        string result = Validator.Shortener(input, 3, 5, '#');
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void Shortener_ShouldPadWithPlaceholder()
    {
        string input = "A";
        string result = Validator.Shortener(input, 3, 10, '#');
        Assert.Equal("A##", result);
    }
}
