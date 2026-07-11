namespace SDC220LCalculator;

/// <summary>
/// Stores up to 10 integers. Use Add/Remove/GetAll/Clear to manage the collection.
/// </summary>
public static class IntCollection
{
    private static readonly List<int> _values = new();
    private const int MaxCapacity = 10;

    /// <summary>Number of values currently stored.</summary>
    public static int Count => _values.Count;

    /// <summary>True when the collection holds 10 values.</summary>
    public static bool IsFull => _values.Count == MaxCapacity;

    /// <summary>True when no values are stored.</summary>
    public static bool IsEmpty => _values.Count == 0;

    /// <summary>Appends <paramref name="value"/> to the collection.</summary>
    /// <exception cref="InvalidOperationException">Thrown when collection is full.</exception>
    public static void Add(int value)
    {
        if (IsFull)
            throw new InvalidOperationException("Collection is full.");
        _values.Add(value);
    }

    /// <summary>Removes the value at the given 0-based <paramref name="index"/>.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of range.</exception>
    public static void Remove(int index)
    {
        if (index < 0 || index >= _values.Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        _values.RemoveAt(index);
    }

    /// <summary>Returns a copy of all stored values in insertion order.</summary>
    public static int[] GetAll() => _values.ToArray();

    /// <summary>Removes all stored values.</summary>
    public static void Clear() => _values.Clear();
}
