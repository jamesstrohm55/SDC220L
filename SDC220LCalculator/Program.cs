// -----------------------------------------------------------------------------
// SDC220L - Project Week 4: Division with Exception Handling
// Author: James Strohm
//
// This application repeatedly divides a first number by a second number.
// It demonstrates exception handling for two cases:
//   * Dividing by zero            -> DivideByZeroException
//   * Entering a non-number value -> FormatException / OverflowException
// In every error case the user is told what went wrong and asked to try again.
// The program continues until the user chooses to quit.
//
// Responsibilities are split across reusable classes:
//   * Display     - all screen output (header, welcome, results, errors, closing)
//   * InputHelper - reading and parsing values entered by the user
//   * Calculator  - the math operation (division)
// These classes are reused from earlier weeks and extended for Week 4.
// -----------------------------------------------------------------------------

using System.Globalization;
using SDC220LCalculator;

// Use a period as the decimal separator for both input and output regardless
// of the machine's regional settings, so displayed results stay consistent.
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Step 1 & 2: informative header line and a welcome message with instructions.
Display.ShowHeader(4);
Display.ShowWelcomeWeek4();
InputHelper.WaitForKeyPress();
Console.WriteLine();

// Main loop: keep dividing until the user chooses to quit.
bool keepGoing = true;
while (keepGoing)
{
    try
    {
        // Step 3: allow the user to enter two values.
        // ReadDoubleOrThrow throws if the entry is not a valid number so the
        // catch blocks below can handle it.
        double dividend = InputHelper.ReadDoubleOrThrow("Enter the first number (dividend): ");
        double divisor = InputHelper.ReadDoubleOrThrow("Enter the second number (divisor): ");

        // Step 4: divide the first number by the second.
        // Calculator.Divide throws DivideByZeroException when divisor is zero.
        double result = Calculator.Divide(dividend, divisor);

        // Display the result of the division operation.
        Display.ShowResult($"{dividend:F2} / {divisor:F2} = {result:F2}");
    }
    catch (DivideByZeroException)
    {
        // Handle divide-by-zero: show a message and let the user enter new values.
        Display.ShowError("You cannot divide by zero. Please enter a different second number.");
    }
    catch (FormatException)
    {
        // Handle non-numeric input: show a message and let the user enter new values.
        Display.ShowError("That was not a valid number. Please enter numbers only.");
    }
    catch (OverflowException)
    {
        // Handle a number too large/small to represent: ask the user to try again.
        Display.ShowError("That number is too large to handle. Please enter a smaller number.");
    }

    // Step 5: ask whether to continue; any "no" answer exits the loop.
    keepGoing = InputHelper.AskYesNo("Would you like to perform another division? (y/n): ");
    Console.WriteLine();
}

// Step 6: closing message thanking the user.
Display.ShowClosing();
