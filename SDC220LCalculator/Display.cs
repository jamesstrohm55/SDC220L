namespace SDC220LCalculator;

/// <summary>
/// Centralizes all console output. No other class calls Console.Write/WriteLine directly.
/// </summary>
public static class Display
{
    private const string StudentName = "James Strohm";
    private const string Line = "----------------------------------------";
    private const string DoubleLine = "========================================";

    /// <summary>Prints the assignment header: week number, title, and student name.</summary>
    public static void ShowHeader(int week)
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine($"  Project Week {week} | SDC220L Calculator");
        Console.WriteLine($"  {StudentName}");
        Console.WriteLine(DoubleLine);
        Console.WriteLine();
    }

    /// <summary>Prints the welcome message.</summary>
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
    }

    /// <summary>
    /// Prints the welcome message and instructions for the Week 4
    /// division application.
    /// </summary>
    public static void ShowWelcomeWeek4()
    {
        Console.WriteLine("Welcome to the SDC220L Division Calculator!");
        Console.WriteLine(Line);
        Console.WriteLine("This program divides one number by another.");
        Console.WriteLine("Instructions:");
        Console.WriteLine("  1. Enter a first number (the dividend).");
        Console.WriteLine("  2. Enter a second number (the divisor).");
        Console.WriteLine("  3. The result of first / second is shown.");
        Console.WriteLine();
        Console.WriteLine("Don't worry about mistakes:");
        Console.WriteLine("  - If you divide by zero, you'll be asked again.");
        Console.WriteLine("  - If you type something that isn't a number,");
        Console.WriteLine("    you'll be asked again.");
        Console.WriteLine();
        Console.WriteLine("You can keep dividing as many times as you");
        Console.WriteLine("like, and quit whenever you are done.");
        Console.WriteLine(Line);
        Console.Write("Press any key to begin...");
    }

    /// <summary>Prints the 7-item main menu.</summary>
    public static void ShowMainMenu()
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  SDC220L Calculator — Main Menu");
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Subtract");
        Console.WriteLine("  3. Multiply");
        Console.WriteLine("  4. Divide");
        Console.WriteLine("  5. Memory");
        Console.WriteLine("  6. Collection");
        Console.WriteLine("  7. Quit");
        Console.WriteLine(Line);
    }

    /// <summary>Prints the 4-item memory sub-menu.</summary>
    public static void ShowMemoryMenu()
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  SDC220L Calculator — Memory");
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  1. Store Value");
        Console.WriteLine("  2. Recall Value");
        Console.WriteLine("  3. Clear Value");
        Console.WriteLine("  4. Back to Main Menu");
        Console.WriteLine(Line);
    }

    /// <summary>Prints the 8-item collection sub-menu.</summary>
    public static void ShowCollectionMenu()
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  SDC220L Calculator — Integer Collection");
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  1. Display All Values");
        Console.WriteLine("  2. Count of Values");
        Console.WriteLine("  3. Remove a Value");
        Console.WriteLine("  4. Add a Value");
        Console.WriteLine("  5. Sum");
        Console.WriteLine("  6. Average");
        Console.WriteLine("  7. First-Last Difference");
        Console.WriteLine("  8. Back to Main Menu");
        Console.WriteLine(Line);
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
