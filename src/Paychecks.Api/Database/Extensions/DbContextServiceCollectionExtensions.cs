using Microsoft.EntityFrameworkCore;

namespace Paychecks.Api.Database.Extensions;

internal static class DbContextServiceCollectionExtensions
{
    private const string _appDbConfigKey = "AppDb";

    public static IServiceCollection AddAppDbContext(this IServiceCollection services) =>
        services.AddDbContext<AppDbContext>(ConfigureDbContextOptions);

    private static void ConfigureDbContextOptions(IServiceProvider services, DbContextOptionsBuilder options) =>
        options.UseSqlite(services.GetRequiredService<IConfiguration>().GetConnectionString(_appDbConfigKey));
}
