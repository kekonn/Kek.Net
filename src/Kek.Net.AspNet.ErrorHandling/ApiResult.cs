using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling;

public sealed class ApiResult : Result
{
    public int StatusCode { get; private set; } = StatusCodes.Status200OK;

    private ApiResult(IEnumerable<IError> errors) : base(errors)
    {
        var highestStatusCode = StatusCodeHelper.FindHighestStatusCode(errors);
        if (highestStatusCode.HasValue)
        {
            StatusCode = highestStatusCode.Value.statusCode;
        }
    }

    private ApiResult() : base()
    {
        
    }
    
    /// <summary>
    /// A result representing a web api failure. It allows setting a status code and a message.
    /// </summary>
    /// <param name="message">The message to include in the error.</param>
    /// <param name="statusCode">The status code the response should have. Defaults to 500.</param>
    /// <returns>A result representing a failed web api operation.</returns>
    /// <seealso cref="ApiError"/>
    public static ApiResult FailWithStatusCode(string message, int statusCode = StatusCodes.Status500InternalServerError)
    {
        return new ApiResult([new ApiError(message, statusCode)]);
    }

    /// <summary>
    /// Creates an OK result that represents an empty response;
    /// </summary>
    /// <returns>The <see cref="ApiResult"/>.</returns>
    public new static ApiResult Ok()
    {
        return new ApiResult();
    }

    /// <summary>
    /// Convert a <see cref="Result"/> to an <see cref="ApiResult"/>.
    /// </summary>
    /// <param name="result">The Result to base the ApiResult off of.</param>
    /// <returns></returns>
    public static ApiResult FromResult(Result result)
    {
        ArgumentNullException.ThrowIfNull(result);
        
        return new ApiResult(result.Errors);
    }
    
    
}