using Calculator.Constants;

namespace Calculator.Calculators;

public class CommaSeparatedCalculator : ICommaSeparatedCalculator
{
    public decimal CommaNewLineSeperatedAdd(string numbers)
    {
        numbers = numbers.TrimStart('/');
        var numbersArray = numbers.Split(StringConstants.Splitters.ToArray());
        decimal result = 0;

        if (numbersArray.Any())
        {
            numbersArray = numbersArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            foreach (var number in numbersArray)
            {
                Console.WriteLine(number);
                result += decimal.Parse(number);
            }
        }

        return result;
    }
}