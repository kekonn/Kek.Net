namespace Kek.Net.AspNet.JsonResponse;

public class JsonError
{
    public string Message { get; set; } = string.Empty;
    public IDictionary<string, object>? Metadata { get; set; }
}