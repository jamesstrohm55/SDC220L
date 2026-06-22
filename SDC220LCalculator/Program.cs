namespace SDC220LCalculator;

/// <summary>
/// Week 1 entry point: header → welcome → integer addition → floating-point subtraction → exit.
/// All I/O is routed through Display and InputHelper.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Startup
        Display.ShowHeader();
        Display.ShowWelcome();

        // Integer addition
        int a = InputHelper.ReadInt("Enter the first integer value: ");
        int b = InputHelper.ReadInt("Enter the second integer value: ");
        Display.ShowResult($"{a} + {b} = {a + b}");

        Display.ShowMenu(hasNext: true);
        int choice1 = InputHelper.ReadMenuChoice(1, 2);
        if (choice1 == 2)
        {
            Display.ShowClosing();
            return;
        }

        // Floating-point subtraction (first value minus second value)
        double x = InputHelper.ReadDouble("Enter the first decimal value: ");
        double y = InputHelper.ReadDouble("Enter the second decimal value: ");
        Display.ShowResult($"{x:F2} - {y:F2} = {x - y:F2}");

        Display.ShowMenu(hasNext: false);
        InputHelper.ReadMenuChoice(1, 1);

        Display.ShowClosing();
    }
}
