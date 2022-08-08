using Calculator.Constants;
using Calculator.Operators;

namespace Calculator.Calculators;

public class StringCalculator
{
    private readonly ICommaSeparatedCalculator _commaSeparatedCalculator;
    private readonly IDelimiterOperator _delimiterOperator;

    public StringCalculator(ICommaSeparatedCalculator commaSeparatedCalculator, IDelimiterOperator delimiterOperator)
    {
        _commaSeparatedCalculator = commaSeparatedCalculator;
        _delimiterOperator = delimiterOperator;
    }
    
    public decimal Add(string numbers)
    {
        var delimiter = _delimiterOperator.GetDelimiter(numbers);

        var delimiterExists = delimiter != default;
        
        if (delimiterExists) _delimiterOperator.AddDelimiter(delimiter);
        
        if (string.IsNullOrEmpty(numbers)) return 0;

        var hasOneNumber = !StringConstants.Splitters.Any(numbers.Contains);

        if (hasOneNumber) return decimal.Parse(numbers);

        var result = _commaSeparatedCalculator.CommaNewLineSeperatedAdd(numbers);

        if (delimiterExists) _delimiterOperator.RemoveDelimiter(delimiter);

        return result;
    }
}