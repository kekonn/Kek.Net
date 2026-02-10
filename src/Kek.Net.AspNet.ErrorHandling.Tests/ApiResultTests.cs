using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling.Tests;

public class ApiResultTests
{
    [Fact]
    public void ApiResult_Should_HaveDefault500Status()
    {
        // Arrange
        var apiResult = ApiResult.FailWithStatusCode("Test message");
        var apiError = apiResult.Errors.First();
        var statusCode = apiError.Metadata[ApiError.StatusCodeMetadataKey] as int?;
        
        // Assert
        Assert.IsType<ApiError>(apiError);
        Assert.True(statusCode.HasValue);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCode.Value);
    }
}