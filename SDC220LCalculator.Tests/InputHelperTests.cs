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
