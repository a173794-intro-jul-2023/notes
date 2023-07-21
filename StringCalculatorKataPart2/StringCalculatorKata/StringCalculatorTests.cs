namespace StringCalculatorKata;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;
    public StringCalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {
        // Given
        var calculator = new StringCalculator();

        // When
        var result = calculator.Add("");

        // Then
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void CommaSeparatedNumbers(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
}

