using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Paychecks.Api.Database.Services;
using Paychecks.Api.Endpoints.Dto;
using Paychecks.Api.Endpoints.Extensions;

namespace Paychecks.Api.Endpoints;

public static class EmployeeEndpoints
{
    private const string _employeesApiAddress = "/api/v1/employees";

    public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(_employeesApiAddress);

        group.MapGet("/", GetPageAsync)
            .WithDescription("Get a page of employees, optionally filtered.")
            .WithOpenApi();
        
        group.MapGet("/{id}", FindOneByIdAsync)
            .WithDescription("Find one employee by ID.")
            .WithOpenApi();

        //group.MapPost("/", AddOrUpdateOneAsync);
        //group.MapPost("/{id}", RefreshOneByIdAsync);
        //group.MapPatch("/{id}", UpdateOneById);
        //group.MapDelete("/{id}", RemoveOneById);

        return builder;
    }

    private static async Task<Results<
        Ok<PagedApiResponse<GetEmployeeDto[]>>,
        NotFound<PagedApiResponse<GetEmployeeDto[]>>>>
        GetPageAsync(
            [FromServices] EmployeeService service,
            [AsParameters] GetEmployeesPageRequest request,
            CancellationToken cancellationToken = default)
    {
        var pageDescriptor = request.ToPageDescriptor();
        var filter = request.ToEmployeeFilter();
        var result = await service.GetPageAsync(pageDescriptor, filter);
        return result.Length > 0
            ? TypedResults.Ok(new PagedApiResponse<GetEmployeeDto[]>
            {
                Data = result.Select(EmployeeExtensions.ToGetEmployeeDto).ToArray(),
                NextPage = pageDescriptor.GetNextPageAddress(_employeesApiAddress, result.Last().Id, filter)
            })
            : TypedResults.NotFound(new PagedApiResponse<GetEmployeeDto[]>
            {
                Error = "No employees match the provided criteria."
            });
    }

    private static async Task<Results<
        Ok<ApiResponse<GetEmployeeDto>>,
        NotFound<ApiResponse<GetEmployeeDto>>>>
        FindOneByIdAsync(
            [FromServices] EmployeeService service,
            int id)
    {
        var result = await service.FindOneByIdAsync(id);
        return result is not null
            ? TypedResults.Ok(new ApiResponse<GetEmployeeDto>
            {
                Data = result.ToGetEmployeeDto()
            })
            : TypedResults.NotFound(new ApiResponse<GetEmployeeDto>
            {
                Error = $"No employees with id {id} were found."
            });
    }
}
