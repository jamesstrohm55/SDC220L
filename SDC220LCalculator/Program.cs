using SDC220LCalculator;

Display.ShowHeader(2);
Display.ShowWelcome();

while (true)
{
    Display.ShowMainMenu();
    int choice = InputHelper.ReadMenuChoice(1, 8);

    switch (choice)
    {
        case 1:
        {
            double a = InputHelper.ReadDouble("Enter first value: ");
            double b = InputHelper.ReadDouble("Enter second value: ");
            Display.ShowResult($"{a:F2} + {b:F2} = {Calculator.Add(a, b):F2}");
            break;
        }
        case 2:
        {
            double a = InputHelper.ReadDouble("Enter first value: ");
            double b = InputHelper.ReadDouble("Enter second value: ");
            Display.ShowResult($"{a:F2} - {b:F2} = {Calculator.Subtract(a, b):F2}");
            break;
        }
        case 3:
        {
            double a = InputHelper.ReadDouble("Enter first value: ");
            double b = InputHelper.ReadDouble("Enter second value: ");
            Display.ShowResult($"{a:F2} × {b:F2} = {Calculator.Multiply(a, b):F2}");
            break;
        }
        case 4:
        {
            double a = InputHelper.ReadDouble("Enter first value: ");
            double b = InputHelper.ReadDouble("Enter second value: ");
            try
            {
                Display.ShowResult($"{a:F2} ÷ {b:F2} = {Calculator.Divide(a, b):F2}");
            }
            catch (DivideByZeroException)
            {
                Display.ShowError("Cannot divide by zero.");
            }
            break;
        }
        case 5:
        {
            double v = InputHelper.ReadDouble("Enter value to store: ");
            Memory.Store(v);
            Display.ShowResult($"Memory = {v:F2}");
            break;
        }
        case 6:
        {
            try
            {
                Display.ShowResult($"Memory = {Memory.Recall():F2}");
            }
            catch (InvalidOperationException)
            {
                Display.ShowError("Memory is empty. Use Memory Store (5) first.");
            }
            break;
        }
        case 7:
        {
            Memory.Clear();
            Display.ShowResult("Memory cleared.");
            break;
        }
        case 8:
        {
            Display.ShowClosing();
            return;
        }
    }
}
