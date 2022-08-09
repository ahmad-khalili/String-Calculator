﻿using Calculator.Constants;

namespace Calculator.Calculators;

public class SeparatedNumbersNumbersCalculator : ISeparatedNumbersCalculator
{
    public decimal SeparatedNumbersAdd(string numbers)
    {
        numbers = numbers.TrimStart('/');
        var numbersArray = numbers.Split(StringConstants.Splitters.ToArray());
        decimal result = 0;

        if (numbersArray.Any())
        {
            numbersArray = numbersArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            foreach (var number in numbersArray)
            {
                var realNumber = decimal.Parse(number);
                if (realNumber <= 1000)
                    result += decimal.Parse(number);
            }
        }

        return result;
    }
}