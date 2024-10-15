namespace Kek.Net.ErrorHandling.Tests;

public class ResultTests
{
    [Fact]
    public void DataResult_ShouldNot_AllowAccess_ToReturnDataOnFailure()
    {
        // Arrange
        var error = new Error("Something went wrong");
        Result<object> sut = Result.Fail<object>(error);
        
        // Act + Assert
        Assert.Throws<InvalidOperationException>(() => sut.Data);
    }

    [Fact]
    public void Result_Should_KeepReasonsAfterConversion()
    {
        // Arrange
        var error = new Error("Something went wrong");
        var sourceResult = Result.Fail(error);
        
        // Act
        var sut = sourceResult.ToResult<object>();
        
        // Assert
        Assert.Contains(error, sut.Errors);
        Assert.Contains(error, sut.Reasons);
    }

    [Fact]
    public void Result_WithError_ShouldBeFailure()
    {
        // Arrange
        var sut = Result.Fail(new Error("Test"));
        
        // Assert
        Assert.False(sut.IsSuccess, "Result should not be a success");
        Assert.NotEmpty(sut.Errors);
    }

    [Fact]
    public void Result_WithSuccess_ShouldBeSuccess()
    {
        // Arrange
        var resValue = 1;
        var sut = Result.Ok(resValue);
        
        // Assert
        Assert.True(sut.IsSuccess, "Ok result should be marked successful");
        Assert.Equal(resValue, sut.Data);
    }

    [Fact]
    public void DataResult_Should_KeepReasons_AfterConversion()
    {
        // Arrange
        var error = new Error("Test");
        var sourceResult = Result.Fail<object>(error);
        
        // Act
        var sut = sourceResult.ToResult();
        
        // Assert
        Assert.Contains(error, sut.Errors);
        Assert.Contains(error, sut.Reasons);
    }
}