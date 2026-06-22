using System.Globalization;

namespace SDC220LCalculator;

/// <summary>
/// Handles all console input. The Read* methods loop until valid input is received.
/// </summary>
public static class InputHelper
{
    /// <summary>Returns true if <paramref name="input"/> parses as a whole number.</summary>
    public static bool TryParseInt(string input, out int value) =>
        int.TryParse(input.Trim(), out value);

    /// <summary>
    /// Returns true if <paramref name="input"/> parses as a decimal number.
    /// Uses InvariantCulture so a period is always the decimal separator.
    /// </summary>
    public static bool TryParseDouble(string input, out double value) =>
        double.TryParse(input.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value);

    /// <summary>Prompts until a valid integer is entered, then returns it.</summary>
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (TryParseInt(input, out int value))
                return value;
            Display.ShowError("Please enter a whole number. Try again.");
        }
    }

    /// <summary>Prompts until a valid double is entered, then returns it.</summary>
    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (TryParseDouble(input, out double value))
                return value;
            Display.ShowError("Please enter a valid number. Try again.");
        }
    }

    /// <summary>
    /// Prompts until the user enters an integer in [<paramref name="min"/>, <paramref name="max"/>],
    /// then returns it.
    /// </summary>
    public static int ReadMenuChoice(int min, int max)
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine() ?? string.Empty;
            if (TryParseInt(input, out int value) && value >= min && value <= max)
                return value;
            Display.ShowError($"Please enter a number between {min} and {max}. Try again.");
        }
    }
}
