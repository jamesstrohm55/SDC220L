# SDC220L Calculator Week 1 Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a C# console calculator that prints an assignment header, welcomes the user, performs integer addition and floating-point subtraction, and exits through a numbered menu — all routed through three reusable static helper classes.

**Architecture:** `Display`, `InputHelper`, and `Memory` are static classes with single responsibilities. `Program.Main()` calls them in sequence and contains no I/O or formatting logic. `Memory` is fully implemented and tested this week but not wired into the UI — that happens when the full menu is built in a later week.

**Tech Stack:** C# / .NET 8.0, xUnit 2.x

## Global Constraints

- Target framework: `net8.0`
- Namespace: `SDC220LCalculator` throughout
- Floating-point results: `F2` format specifier (always 2 decimal places)
- Integer results: no decimal places
- All `Console.Write*` calls live in `Display` — none in `Program.cs` or `InputHelper`
- All `Console.ReadLine()` calls live in `InputHelper` — none in `Program.cs`
- Error messages formatted as `  Error: <message>` via `Display.ShowError()`

---

## File Structure

```
C:\Users\james\Desktop\SDC220L\
  .gitignore
  SDC220LCalculator.sln
  SDC220LCalculator\
    SDC220LCalculator.csproj
    Program.cs
    Display.cs
    InputHelper.cs
    Memory.cs
  SDC220LCalculator.Tests\
    SDC220LCalculator.Tests.csproj
    MemoryTests.cs
    InputHelperTests.cs
  docs\
    superpowers\
      specs\2026-06-21-calculator-design.md
      plans\2026-06-21-sdc220l-calculator-week1.md
```

---

### Task 1: Project Scaffold

**Files:**
- Create: `SDC220LCalculator.sln`
- Create: `SDC220LCalculator/SDC220LCalculator.csproj`
- Create: `SDC220LCalculator/Program.cs` (generated stub)
- Create: `SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj`
- Create: `.gitignore`

**Interfaces:**
- Produces: a buildable solution and a working test runner with zero tests

- [ ] **Step 1: Initialize git**

```bash
cd C:\Users\james\Desktop\SDC220L
git init
```

Expected:
```
Initialized empty Git repository in C:/Users/james/Desktop/SDC220L/.git/
```

- [ ] **Step 2: Create the solution and main console project**

```bash
dotnet new sln -n SDC220LCalculator
dotnet new console -n SDC220LCalculator -o SDC220LCalculator --framework net8.0
```

Expected: `Restore succeeded.`

- [ ] **Step 3: Create the xUnit test project and wire it to the main project**

```bash
dotnet new xunit -n SDC220LCalculator.Tests -o SDC220LCalculator.Tests --framework net8.0
dotnet sln add SDC220LCalculator/SDC220LCalculator.csproj
dotnet sln add SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj
dotnet add SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj reference SDC220LCalculator/SDC220LCalculator.csproj
```

Expected: `Reference ... added to the project.`

- [ ] **Step 4: Delete the generated dummy test**

Delete `SDC220LCalculator.Tests/UnitTest1.cs` — it exists only to confirm the scaffold compiles.

- [ ] **Step 5: Verify the build succeeds**

```bash
dotnet build
```

Expected: `Build succeeded.  0 Warning(s)  0 Error(s)`

- [ ] **Step 6: Create .gitignore and commit**

Create `.gitignore` at `C:\Users\james\Desktop\SDC220L\.gitignore`:

```
bin/
obj/
.vs/
*.user
```

```bash
git add .gitignore SDC220LCalculator.sln SDC220LCalculator/ SDC220LCalculator.Tests/ docs/
git commit -m "chore: scaffold solution, projects, and test runner"
```

---

### Task 2: Memory Class

**Files:**
- Create: `SDC220LCalculator/Memory.cs`
- Create: `SDC220LCalculator.Tests/MemoryTests.cs`

**Interfaces:**
- Consumes: nothing
- Produces:
  - `Memory.HasValue` → `bool`
  - `Memory.Store(double value)` → `void`
  - `Memory.Recall()` → `double` (throws `InvalidOperationException` when empty)
  - `Memory.Clear()` → `void`

- [ ] **Step 1: Write the failing tests**

Create `SDC220LCalculator.Tests/MemoryTests.cs`:

```csharp
using Xunit;

namespace SDC220LCalculator.Tests;

public class MemoryTests
{
    [Fact]
    public void HasValue_IsFalseByDefault()
    {
        Memory.Clear();
        Assert.False(Memory.HasValue);
    }

    [Fact]
    public void Store_SetsHasValueTrue()
    {
        Memory.Clear();
        Memory.Store(42.0);
        Assert.True(Memory.HasValue);
    }

    [Fact]
    public void Store_Zero_StillSetsHasValueTrue()
    {
        Memory.Clear();
        Memory.Store(0.0);
        Assert.True(Memory.HasValue);
    }

    [Fact]
    public void Recall_ReturnsStoredValue()
    {
        Memory.Clear();
        Memory.Store(3.14);
        Assert.Equal(3.14, Memory.Recall(), precision: 5);
    }

    [Fact]
    public void Store_Overwrites_PreviousValue()
    {
        Memory.Clear();
        Memory.Store(1.0);
        Memory.Store(99.9);
        Assert.Equal(99.9, Memory.Recall(), precision: 5);
    }

    [Fact]
    public void Clear_ResetsHasValueToFalse()
    {
        Memory.Store(10.0);
        Memory.Clear();
        Assert.False(Memory.HasValue);
    }

    [Fact]
    public void Recall_WhenEmpty_ThrowsInvalidOperationException()
    {
        Memory.Clear();
        Assert.Throws<InvalidOperationException>(() => Memory.Recall());
    }
}
```

- [ ] **Step 2: Run tests to confirm they fail (build error expected)**

```bash
dotnet test SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj --filter "FullyQualifiedName~MemoryTests"
```

Expected: build error — `The type or namespace name 'Memory' could not be found`

- [ ] **Step 3: Implement Memory.cs**

Create `SDC220LCalculator/Memory.cs`:

```csharp
namespace SDC220LCalculator;

/// <summary>
/// Single-slot memory store. Tracks one double value and whether it has been set.
/// Use Store/Recall/Clear to manage the stored value.
/// </summary>
public static class Memory
{
    private static double _value;
    private static bool _hasValue;

    /// <summary>True if a value has been stored; false if memory is empty.</summary>
    public static bool HasValue => _hasValue;

    /// <summary>Saves <paramref name="value"/> to memory, overwriting any prior value.</summary>
    public static void Store(double value)
    {
        _value = value;
        _hasValue = true;
    }

    /// <summary>Returns the stored value.</summary>
    /// <exception cref="InvalidOperationException">Thrown when memory is empty.</exception>
    public static double Recall()
    {
        if (!_hasValue)
            throw new InvalidOperationException("Memory is empty.");
        return _value;
    }

    /// <summary>Resets memory to empty.</summary>
    public static void Clear()
    {
        _value = 0;
        _hasValue = false;
    }
}
```

- [ ] **Step 4: Run tests to confirm they pass**

```bash
dotnet test SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj --filter "FullyQualifiedName~MemoryTests"
```

Expected: `Passed!  - Failed:  0, Passed:  7, Skipped: 0`

- [ ] **Step 5: Commit**

```bash
git add SDC220LCalculator/Memory.cs SDC220LCalculator.Tests/MemoryTests.cs
git commit -m "feat: add Memory class with store, recall, and clear"
```

---

### Task 3: Display Class

**Files:**
- Create: `SDC220LCalculator/Display.cs`

**Interfaces:**
- Consumes: nothing
- Produces:
  - `Display.ShowHeader()` → `void`
  - `Display.ShowWelcome()` → `void`
  - `Display.ShowResult(string formula)` → `void`
  - `Display.ShowError(string message)` → `void`
  - `Display.ShowMenu(bool hasNext)` → `void`
  - `Display.ShowClosing()` → `void`

**Note:** All methods write to `Console` — correctness is verified by running the app in Task 5 and taking the required screenshots. Unit tests are not practical here.

- [ ] **Step 1: Implement Display.cs**

Create `SDC220LCalculator/Display.cs`:

```csharp
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
```

- [ ] **Step 2: Verify the build succeeds**

```bash
dotnet build
```

Expected: `Build succeeded.  0 Warning(s)  0 Error(s)`

- [ ] **Step 3: Commit**

```bash
git add SDC220LCalculator/Display.cs
git commit -m "feat: add Display class with all output methods"
```

---

### Task 4: InputHelper Class

**Files:**
- Create: `SDC220LCalculator/InputHelper.cs`
- Create: `SDC220LCalculator.Tests/InputHelperTests.cs`

**Interfaces:**
- Consumes: `Display.ShowError(string message)` (Task 3)
- Produces:
  - `InputHelper.TryParseInt(string input, out int value)` → `bool`
  - `InputHelper.TryParseDouble(string input, out double value)` → `bool`
  - `InputHelper.ReadInt(string prompt)` → `int` (loops until valid)
  - `InputHelper.ReadDouble(string prompt)` → `double` (loops until valid)
  - `InputHelper.ReadMenuChoice(int min, int max)` → `int` (loops until valid and in range)

**Note:** `ReadInt`, `ReadDouble`, and `ReadMenuChoice` call `Console.ReadLine()` and `Display.ShowError()` — they are not unit tested. Tests cover only the two pure parse methods.

- [ ] **Step 1: Write the failing tests**

Create `SDC220LCalculator.Tests/InputHelperTests.cs`:

```csharp
using Xunit;

namespace SDC220LCalculator.Tests;

public class InputHelperTests
{
    [Theory]
    [InlineData("42",         true,   42)]
    [InlineData("-7",         true,   -7)]
    [InlineData("0",          true,    0)]
    [InlineData("abc",        false,   0)]
    [InlineData("",           false,   0)]
    [InlineData("3.14",       false,   0)]  // decimals rejected for int
    [InlineData("9999999999", false,   0)]  // overflows int range
    public void TryParseInt_ValidatesCorrectly(string input, bool expectedOk, int expectedVal)
    {
        bool ok = InputHelper.TryParseInt(input, out int val);
        Assert.Equal(expectedOk, ok);
        if (expectedOk)
            Assert.Equal(expectedVal, val);
    }

    [Theory]
    [InlineData("3.14",  true,  3.14)]
    [InlineData("-1.5",  true, -1.5)]
    [InlineData("0",     true,  0.0)]
    [InlineData("42",    true,  42.0)]
    [InlineData("abc",   false,  0.0)]
    [InlineData("",      false,  0.0)]
    public void TryParseDouble_ValidatesCorrectly(string input, bool expectedOk, double expectedVal)
    {
        bool ok = InputHelper.TryParseDouble(input, out double val);
        Assert.Equal(expectedOk, ok);
        if (expectedOk)
            Assert.Equal(expectedVal, val, precision: 5);
    }
}
```

- [ ] **Step 2: Run tests to confirm they fail (build error expected)**

```bash
dotnet test SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj --filter "FullyQualifiedName~InputHelperTests"
```

Expected: build error — `The type or namespace name 'InputHelper' could not be found`

- [ ] **Step 3: Implement InputHelper.cs**

Create `SDC220LCalculator/InputHelper.cs`:

```csharp
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
```

- [ ] **Step 4: Run tests to confirm they pass**

```bash
dotnet test SDC220LCalculator.Tests/SDC220LCalculator.Tests.csproj --filter "FullyQualifiedName~InputHelperTests"
```

Expected: `Passed!  - Failed:  0, Passed: 13, Skipped: 0`

- [ ] **Step 5: Commit**

```bash
git add SDC220LCalculator/InputHelper.cs SDC220LCalculator.Tests/InputHelperTests.cs
git commit -m "feat: add InputHelper with parse validation and read methods"
```

---

### Task 5: Program.cs — Week 1 Flow

**Files:**
- Modify: `SDC220LCalculator/Program.cs` (replace generated stub entirely)

**Interfaces:**
- Consumes:
  - `Display.ShowHeader()`, `Display.ShowWelcome()`, `Display.ShowResult(string)`, `Display.ShowMenu(bool)`, `Display.ShowClosing()` (Task 3)
  - `InputHelper.ReadInt(string)` → `int`, `InputHelper.ReadDouble(string)` → `double`, `InputHelper.ReadMenuChoice(int, int)` → `int` (Task 4)

- [ ] **Step 1: Replace Program.cs with the week 1 flow**

Open `SDC220LCalculator/Program.cs` and replace its entire contents:

```csharp
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
```

- [ ] **Step 2: Build**

```bash
dotnet build SDC220LCalculator/SDC220LCalculator.csproj
```

Expected: `Build succeeded.  0 Warning(s)  0 Error(s)`

- [ ] **Step 3: Edit Display.cs — replace `[Your Name]` with your actual name**

Open `SDC220LCalculator/Display.cs` and change line:
```csharp
private const string StudentName = "[Your Name]"; // Replace with your full name before submitting
```
to:
```csharp
private const string StudentName = "Your Actual Name Here";
```

- [ ] **Step 4: Run and take Screenshot 1 — header and welcome**

```bash
dotnet run --project SDC220LCalculator/SDC220LCalculator.csproj
```

**Take a screenshot NOW before pressing any key.** The screen should show:

```
========================================
  Project Week 1 | SDC220L Calculator
  Your Actual Name Here
========================================

Welcome to the SDC220L Calculator!
----------------------------------------
This calculator will guide you through
a series of operations. Follow the
prompts to enter values, and use the
menu after each result to continue or exit.

"Why do programmers prefer dark mode?
 Because light attracts bugs."
----------------------------------------
Press any key to begin...
```

- [ ] **Step 5: Test integer addition — valid input — take Screenshot 2**

Press any key. Enter `6` for the first value and `5` for the second.

Expected:
```
Enter the first integer value: 6
Enter the second integer value: 5
----------------------------------------
  6 + 5 = 11
----------------------------------------

----------------------------------------
What would you like to do next?
  1. Continue to next operation
  2. Exit
Enter your choice:
```

**Take a screenshot showing the addition result and menu.**

- [ ] **Step 6: Test invalid integer input (error + re-prompt)**

Run the app again. At the first integer prompt type `abc`, then `3.14`, then `10`.

Expected:
```
Enter the first integer value: abc
  Error: Please enter a whole number. Try again.
Enter the first integer value: 3.14
  Error: Please enter a whole number. Try again.
Enter the first integer value: 10
```

Confirm re-prompting works, then exit (choose `2`).

- [ ] **Step 7: Test floating-point subtraction and closing — take Screenshot 3**

Run again. After addition, choose `1` (Continue). Enter `3.14` and `1.00`.

Expected:
```
Enter the first decimal value: 3.14
Enter the second decimal value: 1.00
----------------------------------------
  3.14 - 1.00 = 2.14
----------------------------------------

----------------------------------------
What would you like to do next?
  1. Exit
Enter your choice: 1

========================================
  Thank you for using SDC220L Calculator!
  Goodbye!
========================================
```

**Take a screenshot showing the subtraction result and closing message.**

- [ ] **Step 8: Run all tests one final time**

```bash
dotnet test
```

Expected: `Passed!  - Failed:  0, Passed: 20, Skipped: 0`

- [ ] **Step 9: Commit**

```bash
git add SDC220LCalculator/Program.cs SDC220LCalculator/Display.cs
git commit -m "feat: implement week 1 flow — header, welcome, addition, subtraction, exit"
```

---

## Self-Review Notes

| Spec section | Covered by |
|---|---|
| 01 Startup screen | Task 5, Steps 3–4 (screenshot) |
| 02 Input method (one at a time, re-prompt) | Task 4 InputHelper + Task 5 Steps 5–6 |
| 03 Standard operations (add ints, subtract doubles) | Task 5 Program.cs |
| 03 Multi-value operations | Not implemented — week 1 scope only |
| 04 Output formatting (formula + result, F2) | Task 3 Display.ShowResult, Task 5 formula strings |
| 05 Error handling (non-numeric, overflow) | Task 4 InputHelper loops |
| 05 Division by zero | Not applicable — division not implemented week 1 |
| 06 Memory class | Task 2 (implemented + tested, not wired to UI) |
| 07 Navigation menu + exit | Task 3 Display.ShowMenu, Task 5 menu logic |
| 08 Class architecture | All four files created across Tasks 2–5 |
