using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Kek.Net.AspNet.JsonResponse;

/// <summary>
/// This attribute informs the API explorer which status code maps to which Json Api response.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class JsonResponseAttribute: Attribute, IApiResponseMetadataProvider
{
    /// <summary>
    /// A typed result returning data. Status code will be 200.
    /// </summary>
    /// <param name="resultType">The type of the result data.</param>
    public JsonResponseAttribute(Type resultType)
    {
        Type = typeof(IJsonDataResponse<>).MakeGenericType(resultType);
        StatusCode = StatusCodes.Status200OK;
    }

    protected JsonResponseAttribute(int statusCode)
    {
        StatusCode = statusCode;
    }
    
    public void SetContentTypes(MediaTypeCollection contentTypes)
    {
        contentTypes.Clear();
        contentTypes.Add(Constants.JsonResponseMediaType);
    }

    public Type? Type { get; protected set; }
    public int StatusCode { get; protected set; }
}