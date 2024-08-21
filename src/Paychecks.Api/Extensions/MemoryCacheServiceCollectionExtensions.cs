using Microsoft.Extensions.Caching.Memory;

namespace Paychecks.Api.Extensions;

public static class MemoryCacheServiceCollectionExtensions
{
    public static void AddMemoryCacheWithSizeLimit(this IServiceCollection services, IConfigurationRoot configuration)
    {
        var size = configuration.GetSection(nameof(MemoryCache)).GetValue<int>(nameof(MemoryCacheOptions.SizeLimit));
        services.AddMemoryCache(options => options.SizeLimit = size);
    }
}
