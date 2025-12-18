namespace Kek.Net.ErrorHandling.Tests;

public class ExceptionalErrorTests
{
    [Fact]
    public void ExceptionalError_Should_SetExceptionMessageAsMessage()
    {
        // Arrange
        const string TestMessage = "TestMessage";
        var exception = new Exception(TestMessage);

        // Act
        var exError = new ExceptionalError(exception);

        // Assert
        Assert.Equal(TestMessage, exError.Message);
        Assert.Equal(exception.Message, exError.Message);
    }

    [Fact]
    public void ExceptionalError_Should_SaveExceptionObject()
    {
        // Arrange
        var exception = new Exception();

        // Act
        var exError = new ExceptionalError(exception);

        // Assert
        Assert.Equal(exception, exError.Exception);
    }

    [Fact]
    public void Exception_Should_ConvertToExceptionalError()
    {
        // Arrange
        var exception = new Exception();

        // Act
        var exError = (ExceptionalError)exception;

        // Assert
        Assert.Equal(exception, exError.Exception);
    }
}