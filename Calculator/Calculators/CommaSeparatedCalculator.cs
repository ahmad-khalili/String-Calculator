namespace Calculator.Calculators;

public class CommaSeparatedCalculator : ICommaSeparatedCalculator
{
    public decimal CommaNewLineSeperatedAdd(string numbers)
    {
        var numbersArray = numbers.Split(',', '\n');
        decimal result = 0;

        if (numbersArray.Any())
            foreach (var number in numbersArray)
                result += decimal.Parse(number);

        return result;
    }
}