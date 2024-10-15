using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling;

public class ApiError : Error
{
    public const string StatusCodeMetadataKey = "StatusCode";

    public ApiError(string message, int statusCode = StatusCodes.Status500InternalServerError) : base(message)
    {
        WithMetadata(StatusCodeMetadataKey, statusCode);
    }
}