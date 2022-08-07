using Calculator.Calculators;

namespace Calculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyNumbersStringAdditionTest_ShouldReturnZero()
    {
        var stringCalculator = new StringCalculator();
        var expected = 0;
        var testString = "";

        var actual = stringCalculator.Add(testString);

        actual.Should().Be(expected);
    }

    [Fact]
    public void OneNumberStringAdditionTest_ShouldReturnNumber()
    {
        var stringCalculator = new StringCalculator();
        var expected = 1;
        var testString = "1";

        var actual = stringCalculator.Add(testString);

        actual.Should().Be(expected);
    }
}