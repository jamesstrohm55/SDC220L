namespace SDC220LCalculator;

public static class Calculator
{
    public static double Add(double a, double b) => a + b;

    public static double Subtract(double a, double b) => a - b;

    public static double Multiply(double a, double b) => a * b;

    public static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    /// <summary>Returns the sum of all values in <paramref name="values"/>.</summary>
    public static int Sum(int[] values) => values.Sum();

    /// <summary>Returns the mean of all values in <paramref name="values"/>.</summary>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="values"/> is empty.</exception>
    public static double Average(int[] values)
    {
        if (values.Length == 0)
            throw new InvalidOperationException("Cannot average an empty collection.");
        return values.Average();
    }

    /// <summary>Returns the first element minus the last element.</summary>
    /// <exception cref="InvalidOperationException">Thrown when fewer than 2 values provided.</exception>
    public static int FirstLastDifference(int[] values)
    {
        if (values.Length < 2)
            throw new InvalidOperationException("Need at least 2 values for first-last difference.");
        return values[0] - values[^1];
    }
}
