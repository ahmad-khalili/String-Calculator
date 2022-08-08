using Calculator.Constants;

namespace Calculator.Operators;

public class DelimiterOperator : IDelimiterOperator
{
    public char GetDelimiter(string numbers)
    {
        var delimiterPrefix = "//";
        if (numbers.StartsWith(delimiterPrefix))
        {
            var delimiterIndex = 2;
            var delimiter = numbers[delimiterIndex];
            return delimiter;
        }

        return default;
    }

    public void AddDelimiter(char delimiter)
    {
        throw new NotImplementedException();
    }

    public void RemoveDelimiter(char delimiter)
    {
        throw new NotImplementedException();
    }
}