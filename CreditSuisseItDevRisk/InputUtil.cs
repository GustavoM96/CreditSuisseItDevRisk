using System.Globalization;

namespace CreditSuisseItDevRisk;

static class InputUtil
{
    public static string ParseString(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input is not a correct text");
        }

        return input;
    }

    public static int ParseInteger(string? input)
    {
        if (!int.TryParse(input, out int number))
        {
            throw new ArgumentException("Input is not a correct number");
        }
        return number;
    }

    public static double ParseDouble(string? input)
    {
        if (
            !double.TryParse(
                input,
                NumberStyles.Float | NumberStyles.AllowThousands,
                provider: null,
                out double number
            )
        )
        {
            throw new ArgumentException("Input is not a correct number");
        }
        return number;
    }

    public static DateTime ParseDatetime(string? input)
    {
        if (!DateTime.TryParse(input, out DateTime date))
        {
            throw new ArgumentException("Input is not a correct dateTime");
        }
        return date;
    }

    public static string? GetInput(string title)
    {
        Console.WriteLine("\n" + title);
        return Console.ReadLine();
    }

    public static int GetInputAsInteger(string title)
    {
        var input = GetInput(title);
        return ParseInteger(input);
    }

    public static DateTime GetInputAsDateTime(string title)
    {
        var input = GetInput(title);
        return ParseDatetime(input);
    }

    public static string GetInputAsString(string title)
    {
        var input = GetInput(title);
        return ParseString(input);
    }
}
