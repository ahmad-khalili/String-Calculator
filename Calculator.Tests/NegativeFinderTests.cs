using Calculator.Extensions;
using Calculator.Operators;

namespace Calculator.Tests;

public class NegativeFinderTests
{
    private readonly NegativeFinder _negativeFinder;

    public NegativeFinderTests()
    {
        _negativeFinder = new NegativeFinder();
    }

    [Theory]
    [InlineData("1,4,-1", "-1")]
    [InlineData("-1,-2,-3,4", "-1, -2, -3")]
    public void GetNegativesTest_ShouldReturnCorrespondingNegatives(string numbers, string expected)
    {
        var actual = _negativeFinder.GetNegatives(numbers).Print();

        actual.Should().Be(expected);
    }
}