using System.Text.Json.Serialization;

namespace Kek.Net.AspNet.JsonResponse;

/// <summary>
/// Response object that represents an api call returning data (or an empty response).
/// </summary>
/// <typeparam name="TData">The type of data this response contains. Can be set to <see cref="Object"/> if the response is empty.</typeparam>
public class JsonResponse<TData> : IJsonDataResponse<TData>, IJsonErrorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TData? Data { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<JsonError>? Errors { get; }
}