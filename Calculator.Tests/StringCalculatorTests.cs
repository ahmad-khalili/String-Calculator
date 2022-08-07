using Calculator.Calculators;

namespace Calculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator _stringCalculator;
    private readonly Mock<ICommaSeperatedCalculator> _commaSeperatedCalculatorMock;
    public StringCalculatorTests()
    {
        _commaSeperatedCalculatorMock = new Mock<ICommaSeperatedCalculator>();
        _stringCalculator = new StringCalculator(_commaSeperatedCalculatorMock.Object);
    }
    
    [Fact]
    public void EmptyNumbersStringAdditionTest_ShouldReturnZero()
    {
        var expected = 0;
        var testString = "";

        var actual = _stringCalculator.Add(testString);

        actual.Should().Be(expected);
    }

    [Fact]
    public void OneNumberStringAdditionTest_ShouldReturnNumber()
    {
        var expected = 1;
        var testString = "1";

        var actual = _stringCalculator.Add(testString);

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