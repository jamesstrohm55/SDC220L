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
