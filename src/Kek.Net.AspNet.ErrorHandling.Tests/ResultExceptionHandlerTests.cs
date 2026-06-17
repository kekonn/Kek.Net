using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kek.Net.AspNet.ErrorHandling.Tests;

public class ResultExceptionHandlerTests
{
    [Fact]
    public async Task ResultExceptionHandler_Should_ProduceCorrectResponse()
    {
        // Arrange
        var handler = new ResultExceptionHandler();
        var exception = new Exception("Test exception. Please ignore");
        var responseStream = new MemoryStream();
        var context = new DefaultHttpContext()
        {
            Response =
            {
                Body = responseStream
            }
        };
        
        // Act
        var result = await handler.TryHandleAsync(context, exception,  TestContext.Current.CancellationToken);
        
        // Assert
        Assert.True(result);
        var response = context.Response;
        Assert.Equal("application/problem+json; charset=utf-8", response.ContentType);
        Assert.Equal(StatusCodes.Status500InternalServerError, response.StatusCode);
        responseStream.Position = 0L;

        var problemDetail = await JsonSerializer.DeserializeAsync<ProblemDetails>(responseStream,
            cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(problemDetail);
        Assert.Equal(exception.Message, problemDetail.Detail);
        Assert.Equal(StatusCodes.Status500InternalServerError, problemDetail.Status);
        Assert.Equal(exception.GetType().Name, problemDetail.Title);
        await responseStream.DisposeAsync();
    }
}