using SDC220LCalculator;

Display.ShowHeader(3);
Display.ShowWelcome();
InputHelper.WaitForKeyPress();

while (true)
{
    Display.ShowMainMenu();
    int choice = InputHelper.ReadMenuChoice(1, 7);

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
        case 5: // Memory sub-menu
        {
            bool backToMain = false;
            while (!backToMain)
            {
                Display.ShowMemoryMenu();
                int sub = InputHelper.ReadMenuChoice(1, 4);
                switch (sub)
                {
                    case 1:
                    {
                        double v = InputHelper.ReadDouble("Enter value to store: ");
                        Memory.Store(v);
                        Display.ShowResult($"Memory = {v:F2}");
                        break;
                    }
                    case 2:
                    {
                        try
                        {
                            Display.ShowResult($"Memory = {Memory.Recall():F2}");
                        }
                        catch (InvalidOperationException)
                        {
                            Display.ShowError("Memory is empty.");
                        }
                        break;
                    }
                    case 3:
                    {
                        if (!Memory.HasValue)
                        {
                            Display.ShowError("Memory is already empty.");
                        }
                        else
                        {
                            Memory.Clear();
                            Display.ShowResult("Memory cleared.");
                        }
                        break;
                    }
                    case 4:
                        backToMain = true;
                        break;
                }
            }
            break;
        }
        case 6: // Collection sub-menu
        {
            bool backToMain = false;
            while (!backToMain)
            {
                Display.ShowCollectionMenu();
                int sub = InputHelper.ReadMenuChoice(1, 8);
                switch (sub)
                {
                    case 1: // Display All
                    {
                        if (IntCollection.IsEmpty)
                        {
                            Display.ShowError("Collection is empty.");
                        }
                        else
                        {
                            int[] vals = IntCollection.GetAll();
                            string list = string.Join("\n  ", vals.Select((v, i) => $"{i + 1}. {v}"));
                            Display.ShowResult(list);
                        }
                        break;
                    }
                    case 2: // Count
                    {
                        Display.ShowResult($"Count: {IntCollection.Count}");
                        break;
                    }
                    case 3: // Remove
                    {
                        if (IntCollection.IsEmpty)
                        {
                            Display.ShowError("Collection is empty.");
                            break;
                        }
                        int[] vals = IntCollection.GetAll();
                        string list = string.Join("\n  ", vals.Select((v, i) => $"{i + 1}. {v}"));
                        Display.ShowResult(list);
                        int removeChoice = InputHelper.ReadMenuChoice(1, IntCollection.Count);
                        int removed = vals[removeChoice - 1];
                        IntCollection.Remove(removeChoice - 1);
                        Display.ShowResult($"Removed {removed}. Count: {IntCollection.Count}");
                        break;
                    }
                    case 4: // Add
                    {
                        if (IntCollection.IsFull)
                        {
                            Display.ShowError("Collection is full (10 values maximum).");
                            break;
                        }
                        int v = InputHelper.ReadInt("Enter integer value: ");
                        IntCollection.Add(v);
                        Display.ShowResult($"Added {v}. Count: {IntCollection.Count}");
                        break;
                    }
                    case 5: // Sum
                    {
                        if (IntCollection.IsEmpty)
                        {
                            Display.ShowError("Collection is empty.");
                            break;
                        }
                        Display.ShowResult($"Sum = {Calculator.Sum(IntCollection.GetAll())}");
                        break;
                    }
                    case 6: // Average
                    {
                        if (IntCollection.IsEmpty)
                        {
                            Display.ShowError("Collection is empty.");
                            break;
                        }
                        Display.ShowResult($"Average = {Calculator.Average(IntCollection.GetAll()):F2}");
                        break;
                    }
                    case 7: // First-Last Difference
                    {
                        if (IntCollection.Count < 2)
                        {
                            Display.ShowError("Need at least 2 values for first-last difference.");
                            break;
                        }
                        int[] vals = IntCollection.GetAll();
                        Display.ShowResult($"{vals[0]} - {vals[^1]} = {Calculator.FirstLastDifference(vals)}");
                        break;
                    }
                    case 8:
                        backToMain = true;
                        break;
                }
            }
            break;
        }
        case 7:
        {
            Display.ShowClosing();
            return;
        }
    }
}
