using Calculator.Constants;

namespace Calculator.Operators;

public class DelimiterOperator : IDelimiterOperator
{
    public char GetDelimiter(string numbers)
    {
        var delimiterPrefix = "//";
        if (numbers.StartsWith(delimiterPrefix))
        {
            var delimiterPrefixIndex = 1;
            var delimiter = char.Parse(numbers.Substring(delimiterPrefixIndex + 1));
            StringConstants.Splitters.Add(delimiter);
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