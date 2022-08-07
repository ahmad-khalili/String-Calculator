using Calculator.Calculators;

namespace Calculator.Tests;

public class CommaSeparatedCalculatorTests
{
    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,2,3", 6)]
    public void CommaSeparatedAdditionTest_ShouldReturnCorrespondingExpectedResult(string numbers, decimal expected)
    {
        var commaSeparatedCalculator = new CommaSeperatedCalculator();

        var actual = commaSeparatedCalculator.CommaSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }
}