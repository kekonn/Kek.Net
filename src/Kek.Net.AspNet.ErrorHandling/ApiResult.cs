using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling;

public class ApiResult : Result
{
    /// <summary>
    /// A result representing a web api failure. It allows to set a status code and a message.
    /// </summary>
    /// <param name="message">The message to include in the error.</param>
    /// <param name="statusCode">The status code the response should have. Defaults to 500.</param>
    /// <returns>A result representing a failed web api operation.</returns>
    /// <seealso cref="ApiError"/>
    public static Result FailWithStatusCode(string message, int statusCode = StatusCodes.Status500InternalServerError)
    {
        return Result.Fail(new ApiError(message, statusCode));
    }
}