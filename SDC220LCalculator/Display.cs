namespace SDC220LCalculator;

/// <summary>
/// Centralizes all console output. No other class calls Console.Write/WriteLine directly.
/// </summary>
public static class Display
{
    private const string StudentName = "[Your Name]"; // Replace with your full name before submitting
    private const string Line = "----------------------------------------";
    private const string DoubleLine = "========================================";

    /// <summary>Prints the assignment header: week number, title, and student name.</summary>
    public static void ShowHeader()
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  Project Week 1 | SDC220L Calculator");
        Console.WriteLine($"  {StudentName}");
        Console.WriteLine(DoubleLine);
        Console.WriteLine();
    }

    /// <summary>Prints the welcome message, then blocks until the user presses any key.</summary>
    public static void ShowWelcome()
    {
        Console.WriteLine("Welcome to the SDC220L Calculator!");
        Console.WriteLine(Line);
        Console.WriteLine("This calculator will guide you through");
        Console.WriteLine("a series of operations. Follow the");
        Console.WriteLine("prompts to enter values, and use the");
        Console.WriteLine("menu after each result to continue or exit.");
        Console.WriteLine();
        Console.WriteLine("\"Why do programmers prefer dark mode?");
        Console.WriteLine(" Because light attracts bugs.\"");
        Console.WriteLine(Line);
        Console.Write("Press any key to begin...");
        Console.ReadKey(true); // true = do not echo the key
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>Prints <paramref name="formula"/> surrounded by separator lines.</summary>
    public static void ShowResult(string formula)
    {
        Console.WriteLine(Line);
        Console.WriteLine($"  {formula}");
        Console.WriteLine(Line);
        Console.WriteLine();
    }

    /// <summary>Prints a formatted error message.</summary>
    public static void ShowError(string message)
    {
        Console.WriteLine($"  Error: {message}");
    }

    /// <summary>
    /// Prints the post-result navigation menu.
    /// Pass <paramref name="hasNext"/> = true to show Continue (1) and Exit (2).
    /// Pass false to show only Exit (1).
    /// </summary>
    public static void ShowMenu(bool hasNext)
    {
        Console.WriteLine(Line);
        Console.WriteLine("What would you like to do next?");
        if (hasNext)
        {
            Console.WriteLine("  1. Continue to next operation");
            Console.WriteLine("  2. Exit");
        }
        else
        {
            Console.WriteLine("  1. Exit");
        }
    }

    /// <summary>Prints the closing message.</summary>
    public static void ShowClosing()
    {
        Console.WriteLine();
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  Thank you for using SDC220L Calculator!");
        Console.WriteLine("  Goodbye!");
        Console.WriteLine(DoubleLine);
    }
}
