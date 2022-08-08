using Calculator.Constants;
using Calculator.Operators;

namespace Calculator.Tests;

public class DelimiterOperatorTests
{
    private readonly DelimiterOperator _delimiterOperator;

    public DelimiterOperatorTests()
    {
        _delimiterOperator = new DelimiterOperator();
    }

    [Theory]
    [InlineData("//;\n1;2",';')]
    public void GetDelimiterTest_ShouldReturnCorrespondingExpectedValue(string numbers, char expected)
    {
        var actual = _delimiterOperator.GetDelimiter(numbers);

        actual.Should().Be(expected);
    }
}