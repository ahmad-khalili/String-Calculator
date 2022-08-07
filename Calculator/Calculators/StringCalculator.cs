namespace Calculator.Calculators;

public class StringCalculator
{
    private readonly ICommaSeperatedCalculator _commaSeperatedCalculator;

    public StringCalculator(ICommaSeperatedCalculator commaSeperatedCalculator)
    {
        _commaSeperatedCalculator = commaSeperatedCalculator;
    }
    
    public decimal Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var hasOneNumber = !numbers.Contains(',');

        if (hasOneNumber) return decimal.Parse(numbers);

        return default;
    }
}