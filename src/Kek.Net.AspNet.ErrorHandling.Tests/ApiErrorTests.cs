using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling.Tests;

public class ApiErrorTests
{
    [Theory]
    [InlineData([410])]
    [InlineData([500])]
    [InlineData([429])]
    public void ApiError_Should_SaveStatusCode(int statusCode)
    {
        // Act
        var sut = new ApiError("Test", statusCode);
        
        // Assert
        Assert.True(sut.Metadata.ContainsKey(ApiError.StatusCodeMetadataKey));
        Assert.Equal(statusCode, sut.Metadata[ApiError.StatusCodeMetadataKey]);
    }
}