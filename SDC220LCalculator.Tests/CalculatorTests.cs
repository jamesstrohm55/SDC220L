using Xunit;

namespace SDC220LCalculator.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoPositives_ReturnsSum() =>
        Assert.Equal(5.0, Calculator.Add(2.0, 3.0));

    [Fact]
    public void Add_WithNegative_ReturnsSum() =>
        Assert.Equal(1.0, Calculator.Add(-1.0, 2.0));

    [Fact]
    public void Add_Decimals_ReturnsSum() =>
        Assert.Equal(3.5, Calculator.Add(1.5, 2.0));

    [Fact]
    public void Subtract_LargerMinusSmaller_ReturnsPositive() =>
        Assert.Equal(1.0, Calculator.Subtract(3.0, 2.0));

    [Fact]
    public void Subtract_SmallerMinusLarger_ReturnsNegative() =>
        Assert.Equal(-1.0, Calculator.Subtract(2.0, 3.0));

    [Fact]
    public void Multiply_TwoPositives_ReturnsProduct() =>
        Assert.Equal(6.0, Calculator.Multiply(2.0, 3.0));

    [Fact]
    public void Multiply_ByZero_ReturnsZero() =>
        Assert.Equal(0.0, Calculator.Multiply(5.0, 0.0));

    [Fact]
    public void Divide_EvenSplit_ReturnsExactQuotient() =>
        Assert.Equal(2.5, Calculator.Divide(5.0, 2.0));

    [Fact]
    public void Divide_NegativeDividend_ReturnsNegativeQuotient() =>
        Assert.Equal(-2.5, Calculator.Divide(-5.0, 2.0));

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException() =>
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5.0, 0.0));

    // Sum
    [Fact]
    public void Sum_ReturnsCorrectTotal() =>
        Assert.Equal(6, Calculator.Sum(new[] { 1, 2, 3 }));

    [Fact]
    public void Sum_SingleValue_ReturnsThatValue() =>
        Assert.Equal(5, Calculator.Sum(new[] { 5 }));

    [Fact]
    public void Sum_WithNegatives_ReturnsCorrectTotal() =>
        Assert.Equal(0, Calculator.Sum(new[] { -3, 3 }));

    // Average
    [Fact]
    public void Average_EvenValues_ReturnsCorrectMean() =>
        Assert.Equal(2.0, Calculator.Average(new[] { 1, 2, 3 }));

    [Fact]
    public void Average_NonEvenSplit_ReturnsDecimal() =>
        Assert.Equal(2.5, Calculator.Average(new[] { 1, 2, 3, 4 }));

    [Fact]
    public void Average_EmptyArray_ThrowsInvalidOperationException() =>
        Assert.Throws<InvalidOperationException>(() => Calculator.Average(Array.Empty<int>()));

    // FirstLastDifference
    [Fact]
    public void FirstLastDifference_ReturnsFirstMinusLast() =>
        Assert.Equal(2, Calculator.FirstLastDifference(new[] { 5, 3, 1, 3 }));

    [Fact]
    public void FirstLastDifference_TwoValues_ReturnsFirstMinusLast() =>
        Assert.Equal(3, Calculator.FirstLastDifference(new[] { 5, 2 }));

    [Fact]
    public void FirstLastDifference_SingleValue_ThrowsInvalidOperationException() =>
        Assert.Throws<InvalidOperationException>(() => Calculator.FirstLastDifference(new[] { 1 }));

    [Fact]
    public void FirstLastDifference_EmptyArray_ThrowsInvalidOperationException() =>
        Assert.Throws<InvalidOperationException>(() => Calculator.FirstLastDifference(Array.Empty<int>()));
}
