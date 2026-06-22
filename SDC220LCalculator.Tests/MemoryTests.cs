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
