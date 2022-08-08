using Calculator.Calculators;

namespace Calculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator _stringCalculator;
    private readonly Mock<ICommaSeparatedCalculator> _commaSeperatedCalculatorMock;
    public StringCalculatorTests()
    {
        _commaSeperatedCalculatorMock = new Mock<ICommaSeparatedCalculator>();
        _stringCalculator = new StringCalculator(_commaSeperatedCalculatorMock.Object);
    }

    [Theory]
    [InlineData("",0)]
    [InlineData("1",1)]
    public void EmptyAndOneNumberStringAdditionTest_ShouldReturnCorrespondingExpectedValue(string numbers,
        decimal expected)
    {
        var actual = _stringCalculator.Add(numbers);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TwoNumbersStringAdditionTest_ShouldReturnSum()
    {
        var expected = 3;
        var testString = "1,2";

        _commaSeperatedCalculatorMock.Setup(x => x.CommaSeperatedAdd(testString))
            .Returns(expected);

        var actual = _stringCalculator.Add(testString);

        actual.Should().Be(expected);
    }
}