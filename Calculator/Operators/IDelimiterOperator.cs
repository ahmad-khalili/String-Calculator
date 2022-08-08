namespace Calculator.Operators;

public interface IDelimiterOperator
{
    char GetDelimiter(string numbers);
    void AddDelimiter(char delimiter);
    void RemoveDelimiter(char delimiter);
}