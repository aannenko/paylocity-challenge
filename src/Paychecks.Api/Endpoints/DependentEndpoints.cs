using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Paychecks.Api.Database.Services;
using Paychecks.Api.Endpoints.Dto;
using Paychecks.Api.Endpoints.Extensions;

namespace Paychecks.Api.Endpoints;

public static class DependentEndpoints
{
    private const string _dependentApiAddress = "/api/v1/dependents";

    public static IEndpointRouteBuilder MapDependentEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(_dependentApiAddress);

        group.MapGet("/", GetPageAsync)
            .WithDescription("Get a page of employees' dependents, optionally filtered.")
            .WithOpenApi();

        group.MapGet("/{id}", FindOneByIdAsync)
            .WithDescription("Find one dependent person by ID.")
            .WithOpenApi();

        return builder;
    }

    private static async Task<Results<
        Ok<PagedApiResponse<GetDependentDto[]>>,
        NotFound<PagedApiResponse<GetDependentDto[]>>>>
        GetPageAsync(
            [FromServices] DependentService service,
            [AsParameters] GetDependentsPageRequest request,
            CancellationToken cancellationToken = default)
    {
        var pageDescriptor = request.ToPageDescriptor();
        var filter = request.ToDependentFilter();
        var result = await service.GetPageAsync(pageDescriptor, filter);
        return result.Length > 0
            ? TypedResults.Ok(new PagedApiResponse<GetDependentDto[]>
            {
                Data = result.Select(DependentExtensions.ToGetDependentDto).ToArray(),
                NextPage = pageDescriptor.GetNextPageAddress(_dependentApiAddress, result.Last().Id, filter)
            })
            : TypedResults.NotFound(new PagedApiResponse<GetDependentDto[]>
            {
                Error = "No employee dependents match the provided criteria."
            });
    }

    private static async Task<Results<
        Ok<ApiResponse<GetDependentDto>>,
        NotFound<ApiResponse<GetDependentDto>>>>
        FindOneByIdAsync(
            [FromServices] DependentService service,
            int id)
    {
        var result = await service.FindOneByIdAsync(id);
        return result is not null
            ? TypedResults.Ok(new ApiResponse<GetDependentDto>
            {
                Data = result.ToGetDependentDto()
            })
            : TypedResults.NotFound(new ApiResponse<GetDependentDto>
            {
                Error = $"No employees with id {id} were found."
            });
    }
}
