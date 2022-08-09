namespace Calculator.Extensions;

public static class StringListExtensions
{
    public static string Print(this List<string> list)
    {
        var str = "";
        var isFirstLoop = true;

        foreach (var element in list)
        {
            if (isFirstLoop)
            {
                str += element;
            }
            else
            {
                str += $", {element}";
            }
            isFirstLoop = false;
        }

        return str;
    }
}