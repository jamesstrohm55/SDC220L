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
}
