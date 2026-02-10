using Kek.Net.ErrorHandling;

namespace Kek.Net.AspNet.ErrorHandling.Tests;

public class StatusCodeHelperTests
{
    [Fact]
    public void StatusCodeHelper_Should_ThrowIfNull()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => StatusCodeHelper.FindHighestStatusCode(null));
    }

    public static IEnumerable<TheoryDataRow<IEnumerable<ApiError>, int>> StatusCodesList()
    {
        yield return new TheoryDataRow<IEnumerable<ApiError>, int>([new ApiError("500"), new ApiError("400", 400), new ApiError("422", 422)], 500) ;
        yield return new TheoryDataRow<IEnumerable<ApiError>, int>([new ApiError("400", 400), new ApiError("422", 422)], 422) ;
        yield return new TheoryDataRow<IEnumerable<ApiError>, int>([new ApiError("400", 400)], 400) ;
    }
    
    [Theory]
    [MemberData(nameof(StatusCodesList))]
    public void StatusCodeHelper_Should_FindHighestStatusCode(IEnumerable<ApiError> errors, int expectedStatusCode)
    {
        // Act
        var result = StatusCodeHelper.FindHighestStatusCode(errors);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedStatusCode, result.Value.statusCode);
    }
}