using Calculator.Constants;

namespace Calculator.Operators;

public class NegativeFinder : INegativeFinder
{
    public List<string> GetNegatives(string numbers)
    {
        var numbersArray = numbers.Split(StringConstants.Splitters.ToArray());
        var negativesList = new List<string>();
        
        foreach (var number in numbersArray)
            if (number.Contains('-'))
                negativesList.Add(number);

        return negativesList;
    }
}