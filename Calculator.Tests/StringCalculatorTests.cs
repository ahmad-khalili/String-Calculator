using Calculator.Calculators;
using Calculator.Operators;

namespace Calculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator _stringCalculator;
    private readonly Mock<ISeparatedNumbersCalculator> _commaSeperatedCalculatorMock;
    private readonly Mock<IDelimiterOperator> _delimiterOperatorMock;
    private readonly Mock<INegativeFinder> _negativeFinderMock;
    public StringCalculatorTests()
    {
        _commaSeperatedCalculatorMock = new Mock<ISeparatedNumbersCalculator>();
        _delimiterOperatorMock = new Mock<IDelimiterOperator>();
        _negativeFinderMock = new Mock<INegativeFinder>();
        _stringCalculator = new StringCalculator(_commaSeperatedCalculatorMock.Object, _delimiterOperatorMock.Object, 
            _negativeFinderMock.Object);
    }

    [Theory]
    [InlineData("",0)]
    [InlineData("1",1)]
    public void AddTestWithOneAndEmptyNumbers_ShouldReturnSum(string numbers, decimal expected)
    {
        var actual = _stringCalculator.Add(numbers);

        actual.Should().Be(expected);
    }

    [Fact]
    public void AddTestWithTwoNumbers_ShouldCallSeparatedNumbersAdd()
    {
        var expected = 3;
        var testString = "1,2";

        _commaSeperatedCalculatorMock.Setup(x => x.SeparatedNumbersAdd(testString))
            .Returns(expected);

        var actual = _stringCalculator.Add(testString);
        
        _commaSeperatedCalculatorMock.Verify(x => x.SeparatedNumbersAdd(testString),
            Times.Once);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("2,2,4",8)]
    [InlineData("4,2,1,1",8)]
    [InlineData("5,0,1,3,4",13)]
    public void AddTestWithMultipleNumbers_ShouldCallSeparatedNumbersAdd(string numbers, decimal expected)
    {
        _commaSeperatedCalculatorMock.Setup(x => x.SeparatedNumbersAdd(numbers))
            .Returns(expected);

        var actual = _stringCalculator.Add(numbers);
        
        _commaSeperatedCalculatorMock.Verify(x => x.SeparatedNumbersAdd(numbers),
            Times.Once);

        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1\n2",3)]
    public void AddTestWithNewLines_ShouldCallSeparatedNumbersAdd(string numbers, decimal expected)
    {
        _commaSeperatedCalculatorMock.Setup(x => x.SeparatedNumbersAdd(numbers))
            .Returns(expected);
        
        var actual = _stringCalculator.Add(numbers);
        
        _commaSeperatedCalculatorMock.Verify(x => x.SeparatedNumbersAdd(numbers),
            Times.Once);

        actual.Should().Be(expected);
    }
    
    [Fact]
    public void AddTestWithCustomDelimiter_ShouldCallDelimiterHandlerAndSeparatedNumbersAdd()
    {
        var expected = 6M;
        var numbers = "//;\n1;2";
        var delimiter = ';';
        
        _delimiterOperatorMock.Setup(x => x.GetDelimiter(numbers))
            .Returns(delimiter);
        
        _commaSeperatedCalculatorMock.Setup(x => x.SeparatedNumbersAdd(numbers))
            .Returns(expected);

        var actual = _stringCalculator.Add(numbers);
        
        _delimiterOperatorMock.Verify(x => x.AddDelimiter(delimiter), Times.Once);
        _delimiterOperatorMock.Verify(x => x.RemoveDelimiter(delimiter), Times.Once);
        _commaSeperatedCalculatorMock.Verify(x => x.SeparatedNumbersAdd(numbers),
            Times.Once);

        actual.Should().Be(expected);
    }

    [Fact]
    public void AddTestWithNegativeNumbers_ShouldThrowArgumentException()
    {
        var numbersTest = "1,4,-1";
        var expectedExceptionMessage = "Negatives not allowed: -1";
        var expectedNegatives = new List<string> { "-1" };
        _negativeFinderMock.Setup(x => x.GetNegatives(numbersTest))
            .Returns(expectedNegatives);

        var act = () => _stringCalculator.Add(numbersTest);

        act.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
    }

    [Fact]
    public void AddTestWithBigNumbers_ShouldCallSeparatedNumbersAdd()
    {
        var testString = "2,1001";
        var expected = 2M;

        _commaSeperatedCalculatorMock.Setup(x => x.SeparatedNumbersAdd(testString))
            .Returns(expected);

        var actual = _stringCalculator.Add(testString);
        
        _commaSeperatedCalculatorMock.Verify(x => x.SeparatedNumbersAdd(testString),
            Times.Once);

        actual.Should().Be(expected);
    }
}