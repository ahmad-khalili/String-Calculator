using Calculator.Calculators;
using Calculator.Constants;

namespace Calculator.Tests;

public class SeparatedNumbersCalculatorTests
{
    private readonly SeparatedNumbersNumbersCalculator _separatedNumbersNumbersCalculator;
    public SeparatedNumbersCalculatorTests()
    {
        _separatedNumbersNumbersCalculator = new SeparatedNumbersNumbersCalculator();
    }
    
    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,2,3", 6)]
    public void SeparatedNumbersAddTest_ShouldReturnCorrespondingExpectedResult(string numbers, decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.SeparatedNumbersAdd(numbers);

        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("2,2,4",8)]
    [InlineData("4,2,1,1",8)]
    [InlineData("5,0,1,3,4",13)]
    public void SeparatedNumbersAddTestWithMultipleNumbers_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.SeparatedNumbersAdd(numbers);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    public void SeparatedNumbersAddTestWithNewLines_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.SeparatedNumbersAdd(numbers);

        actual.Should().Be(expected);
    }
    
    [Fact]
    public void SeparatedNumbersAddTestWithCustomDelimiter_ShouldReturnThree()
    {
        var numbers = "//;\n1;2";
        var expected = 3M;
        var delimiter = ';';
        StringConstants.Splitters.Add(delimiter);

        var actual = _separatedNumbersNumbersCalculator.SeparatedNumbersAdd(numbers);

        actual.Should().Be(expected);
        StringConstants.Splitters.Remove(delimiter);
    }

    [Theory]
    [InlineData("2,1001", 2)]
    [InlineData("1000,4,2,1101", 1006)]
    public void SeparatedNumbersAddTestWithBigNumbers_ShouldIgnoreNumbersBiggerThanThousand(string numbers,
        decimal expected)
    {
        var actual = _separatedNumbersNumbersCalculator.SeparatedNumbersAdd(numbers);

        actual.Should().Be(expected);
    }
}