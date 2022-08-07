﻿using Calculator.Calculators;

namespace Calculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator _stringCalculator;
    public StringCalculatorTests()
    {
        _stringCalculator = new StringCalculator();
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
}