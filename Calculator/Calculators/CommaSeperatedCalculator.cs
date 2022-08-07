﻿namespace Calculator.Calculators;

public class CommaSeperatedCalculator : ICommaSeperatedCalculator
{
    public decimal CommaSeperatedAdd(string numbers)
    {
        var numbersArray = numbers.Split(',');
        decimal result = 0;

        if (numbersArray.Any())
            foreach (var number in numbersArray)
                result += decimal.Parse(number);

        return result;
    }
}