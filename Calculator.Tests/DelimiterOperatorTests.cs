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
    
    [Fact]
    public void AddDelimiterTest_ShouldAddDelimiterToSplitters()
    {
        var delimiter = ';';

        _delimiterOperator.AddDelimiter(delimiter);
        
        StringConstants.Splitters.Should().Contain(delimiter);
    }
    
    [Fact]
    public void RemoveDelimiterTest_ShouldRemoveDelimiterFromSplitters()
    {
        var delimiter = ';';
        StringConstants.Splitters.Add(delimiter);

        _delimiterOperator.RemoveDelimiter(delimiter);

        StringConstants.Splitters.Should().NotContain(delimiter);
    }
}