using Calculator.Calculators;

namespace Calculator.Tests;

public class CommaSeparatedCalculatorTests
{
    private readonly CommaSeparatedCalculator _commaSeparatedCalculator;

    public CommaSeparatedCalculatorTests()
    {
        _commaSeparatedCalculator = new CommaSeparatedCalculator();
    }
    
    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,2,3", 6)]
    public void CommaSeparatedAdditionTest_ShouldReturnCorrespondingExpectedResult(string numbers, decimal expected)
    {
        var actual = _commaSeparatedCalculator.CommaSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }
}