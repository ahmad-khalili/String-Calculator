using Calculator.Calculators;
using Calculator.Constants;
using Calculator.Operators;

namespace Calculator.Tests;

public class CommaSeparatedCalculatorTests
{
    private readonly SeparatedNumbersNumbersCalculator _separatedNumbersNumbersCalculator;
    public CommaSeparatedCalculatorTests()
    {
        _separatedNumbersNumbersCalculator = new SeparatedNumbersNumbersCalculator();
    }
    
    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,2,3", 6)]
    public void CommaSeparatedAdditionTest_ShouldReturnCorrespondingExpectedResult(string numbers, decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.CommaNewLineSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("2,2,4",8)]
    [InlineData("4,2,1,1",8)]
    [InlineData("5,0,1,3,4",13)]
    public void MoreThanTwoGivenNumbersStringAdditionTest_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.CommaNewLineSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    public void NewLineBetweenNumbersStringAdditionTest_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.CommaNewLineSeperatedAdd(numbers);

        actual.Should().Be(expected);
    }
    
    [Fact]
    public void DelimiterBetweenNumbersStringAdditionTest_ShouldReturnThree()
    {
        var numbers = "//;\n1;2";
        var expected = 3M;
        var delimiter = ';';
        StringConstants.Splitters.Add(delimiter);

        var actual = _separatedNumbersNumbersCalculator.CommaNewLineSeperatedAdd(numbers);

        actual.Should().Be(expected);
        StringConstants.Splitters.Remove(delimiter);
    }
}