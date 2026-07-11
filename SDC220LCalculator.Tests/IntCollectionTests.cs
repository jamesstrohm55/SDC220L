using Xunit;

namespace SDC220LCalculator.Tests;

public class IntCollectionTests
{
    public IntCollectionTests() => IntCollection.Clear();

    [Fact]
    public void Count_IsZeroByDefault() =>
        Assert.Equal(0, IntCollection.Count);

    [Fact]
    public void IsEmpty_IsTrueWhenEmpty() =>
        Assert.True(IntCollection.IsEmpty);

    [Fact]
    public void IsFull_IsFalseWhenEmpty() =>
        Assert.False(IntCollection.IsFull);

    [Fact]
    public void Add_IncreasesCount()
    {
        IntCollection.Add(5);
        Assert.Equal(1, IntCollection.Count);
    }

    [Fact]
    public void Add_WhenFull_ThrowsInvalidOperationException()
    {
        for (int i = 0; i < 10; i++)
            IntCollection.Add(i);
        Assert.Throws<InvalidOperationException>(() => IntCollection.Add(99));
    }

    [Fact]
    public void IsFull_TrueWhenTenValues()
    {
        for (int i = 0; i < 10; i++)
            IntCollection.Add(i);
        Assert.True(IntCollection.IsFull);
    }

    [Fact]
    public void GetAll_ReturnsCurrentValues()
    {
        IntCollection.Add(1);
        IntCollection.Add(2);
        IntCollection.Add(3);
        Assert.Equal(new[] { 1, 2, 3 }, IntCollection.GetAll());
    }

    [Fact]
    public void GetAll_ReturnsDefensiveCopy()
    {
        IntCollection.Add(10);
        int[] copy = IntCollection.GetAll();
        copy[0] = 999;
        Assert.Equal(10, IntCollection.GetAll()[0]);
    }

    [Fact]
    public void Remove_DecreasesCount()
    {
        IntCollection.Add(5);
        IntCollection.Remove(0);
        Assert.Equal(0, IntCollection.Count);
    }

    [Fact]
    public void Remove_RemovesValueAtIndex()
    {
        IntCollection.Add(1);
        IntCollection.Add(2);
        IntCollection.Add(3);
        IntCollection.Remove(1);
        Assert.Equal(new[] { 1, 3 }, IntCollection.GetAll());
    }

    [Fact]
    public void Remove_OutOfRange_ThrowsArgumentOutOfRangeException()
    {
        IntCollection.Add(5);
        Assert.Throws<ArgumentOutOfRangeException>(() => IntCollection.Remove(5));
    }

    [Fact]
    public void Clear_ResetsToEmpty()
    {
        IntCollection.Add(1);
        IntCollection.Add(2);
        IntCollection.Clear();
        Assert.Equal(0, IntCollection.Count);
    }

    [Fact]
    public void IsEmpty_TrueAfterClear()
    {
        IntCollection.Add(1);
        IntCollection.Clear();
        Assert.True(IntCollection.IsEmpty);
    }
}
