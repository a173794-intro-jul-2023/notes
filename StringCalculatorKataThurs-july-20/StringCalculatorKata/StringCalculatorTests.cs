namespace StringCalculatorKata;

public class StringCalculatorTests
{
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

    [Fact]
    public void TestWithOneInt()
    {
        // Given 
        var calculator = new StringCalculator();

        // When
        var result = calculator.Add("5");

        // Then
        Assert.Equal(5, result);
    }

    [Fact]
    public void TestWithTwoInts()
    {
        // Given 
        var calculator = new StringCalculator();

        // when
        var result = calculator.Add("5,3");

        // Then 
        Assert.Equal(8, result);
    }

    [Fact]
    public void TestWithNewLineCharacter()
    {
        // Given 
        var calculator = new StringCalculator();

        // when
        var result = calculator.Add("5\n3,2");

        // Then 
        Assert.Equal(10, result);
    }
}

