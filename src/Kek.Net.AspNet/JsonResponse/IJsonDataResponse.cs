namespace Kek.Net.AspNet.JsonResponse;

public interface IJsonDataResponse<out TData>
{
    public TData? Data { get; }
}