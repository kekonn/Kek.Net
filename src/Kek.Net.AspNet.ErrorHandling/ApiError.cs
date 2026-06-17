using Microsoft.AspNetCore.Http;

namespace Kek.Net.AspNet.ErrorHandling;

public class ApiError : Error
{
    public const string StatusCodeMetadataKey = "StatusCode";

    /// <summary>
    /// Returns the status code from the metadata as an int.
    /// </summary>
    /// <remarks>If for some reason the status code is not in the metadata, return 500.</remarks>
    public int StatusCode
    {
        get
        {
            if (Metadata.TryGetValue(StatusCodeMetadataKey, out var value))
            {
                return Convert.ToInt32(value);
            }

            return StatusCodes.Status500InternalServerError;
        }
    }

    public ApiError(string message, int statusCode = StatusCodes.Status500InternalServerError) : base(message)
    {
        WithMetadata(StatusCodeMetadataKey, statusCode);
    }
}