namespace Calculator.Calculators;

public class StringCalculator
{
    private readonly char[] _splitters = { ',', '\n' };
    
    private readonly ICommaSeparatedCalculator _commaSeparatedCalculator;

    public StringCalculator(ICommaSeparatedCalculator commaSeparatedCalculator)
    {
        _commaSeparatedCalculator = commaSeparatedCalculator;
    }
    
    public decimal Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var hasOneNumber = !_splitters.Any(numbers.Contains);

        if (hasOneNumber) return decimal.Parse(numbers);

        return _commaSeparatedCalculator.CommaNewLineSeperatedAdd(numbers);
    }
}