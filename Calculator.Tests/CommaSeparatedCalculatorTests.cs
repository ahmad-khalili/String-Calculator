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
    
    [Theory]
    [InlineData("2,2,4",8)]
    [InlineData("4,2,1,1",8)]
    [InlineData("5,0,1,3,4",13)]
    public void MoreThanTwoGivenNumbersStringAdditionTest_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _commaSeparatedCalculator.CommaSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    public void NewLineBetweenNumbersStringAdditionTest_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _commaSeparatedCalculator.CommaSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }
}