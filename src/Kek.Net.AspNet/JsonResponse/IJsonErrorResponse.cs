namespace Kek.Net.AspNet.JsonResponse;

public interface IJsonErrorResponse
{
    public ICollection<JsonError>? Errors { get; }
}