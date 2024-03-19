namespace Kek.Net.AspNet.JsonResponse;

/// <summary>
/// Indicates that a controller action could return a <see cref="IJsonErrorResponse"/> for a certain status code.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class JsonResponseErrorAttribute : JsonResponseAttribute
{
    public JsonResponseErrorAttribute(int statusCode) : base(statusCode)
    {
        Type = typeof(IJsonErrorResponse);
    }
}