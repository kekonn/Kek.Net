namespace Kek.Net.AspNet.ErrorHandling;

internal static class StatusCodeHelper
{
    
    /// <summary>
    /// Helper method to find the highest status code of all the <see cref="ApiError"/>s in the collection.
    /// </summary>
    /// <param name="errors">A collection of <see cref="IError"/>s to search.</param>
    /// <returns>Null if no <see cref="ApiError"/> is present. Otherwise, it returns a tuple of the statusCode and <see cref="IError"/>.</returns>
    internal static (int statusCode, IError error)? FindHighestStatusCode(IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        
        var apiError = errors.OfType<ApiError>()
            .OrderByDescending(e => e.StatusCode).FirstOrDefault();

        if (apiError is null)
        {
            return null;
        }
        
        return (apiError.StatusCode, apiError);
    }
}