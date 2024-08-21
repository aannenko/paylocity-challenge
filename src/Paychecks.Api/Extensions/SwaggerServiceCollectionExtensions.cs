using Microsoft.AspNetCore.Routing.Constraints;
using Paychecks.Api.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Paychecks.Api.Extensions;

public static class SwaggerServiceCollectionExtensions
{
    public static void AddSwaggerWithTrimmingSupport(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(
            options => options.SetParameterPolicy<RegexInlineRouteConstraint>("regex"));

        services.AddSingleton<ISerializerDataContractResolver, JsonSerializerDataContractResolver>(
            _ => new(new() { TypeInfoResolver = AppJsonSerializerContext.Default }));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
