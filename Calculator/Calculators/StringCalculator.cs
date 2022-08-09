using Calculator.Constants;
using Calculator.Extensions;
using Calculator.Operators;

namespace Calculator.Calculators;

public class StringCalculator
{
    private readonly ISeparatedNumbersCalculator _separatedNumbersCalculator;
    private readonly IDelimiterOperator _delimiterOperator;
    private readonly INegativeFinder _negativeFinder;

    public StringCalculator(ISeparatedNumbersCalculator separatedNumbersCalculator, IDelimiterOperator delimiterOperator, 
        INegativeFinder negativeFinder)
    {
        _separatedNumbersCalculator = separatedNumbersCalculator;
        _delimiterOperator = delimiterOperator;
        _negativeFinder = negativeFinder;
    }
    
    public decimal Add(string numbers)
    {
        var delimiter = _delimiterOperator.GetDelimiter(numbers);

        var delimiterExists = delimiter != default;
        
        if (delimiterExists) _delimiterOperator.AddDelimiter(delimiter);

        if (string.IsNullOrEmpty(numbers)) return 0;

        var hasOneNumber = !StringConstants.Splitters.Any(numbers.Contains);

        if (hasOneNumber) return decimal.Parse(numbers);

        var negatives = _negativeFinder.GetNegatives(numbers);

        if (negatives != null) throw new ArgumentException($"negatives not allowed: {negatives.Print()}");

        var result = _separatedNumbersCalculator.SeparatedNumbersAdd(numbers);

        if (delimiterExists) _delimiterOperator.RemoveDelimiter(delimiter);

        return result;
    }
}