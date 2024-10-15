using Microsoft.Extensions.DependencyInjection;

namespace Kek.Net.AspNet.ErrorHandling;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add exception handler that converts exceptions to KekNet Results.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddKekNetErrorHandling(this IServiceCollection services)
    {
        return services.AddExceptionHandler<ResultExceptionHandler>();
    }
}