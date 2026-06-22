namespace SDC220LCalculator;

public static class Display
{
    private const string StudentName = "James Strohm";
    private const string Line = "----------------------------------------";
    private const string DoubleLine = "========================================";

    public static void ShowHeader(int week)
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine($"  Project Week {week} | SDC220L Calculator");
        Console.WriteLine($"  {StudentName}");
        Console.WriteLine(DoubleLine);
        Console.WriteLine();
    }

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
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void ShowMainMenu()
    {
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  SDC220L Calculator — Main Menu");
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Subtract");
        Console.WriteLine("  3. Multiply");
        Console.WriteLine("  4. Divide");
        Console.WriteLine("  5. Memory Store (MS)");
        Console.WriteLine("  6. Memory Recall (MR)");
        Console.WriteLine("  7. Memory Clear (MC)");
        Console.WriteLine("  8. Quit");
        Console.WriteLine(Line);
    }

    public static void ShowResult(string formula)
    {
        Console.WriteLine(Line);
        Console.WriteLine($"  {formula}");
        Console.WriteLine(Line);
        Console.WriteLine();
    }

    public static void ShowError(string message)
    {
        Console.WriteLine($"  Error: {message}");
    }

    public static void ShowClosing()
    {
        Console.WriteLine();
        Console.WriteLine(DoubleLine);
        Console.WriteLine("  Thank you for using SDC220L Calculator!");
        Console.WriteLine("  Goodbye!");
        Console.WriteLine(DoubleLine);
    }
}
