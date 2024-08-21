using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Paychecks.Api.Calculations.Services;
using Paychecks.Api.Endpoints.Dto;
using Paychecks.Api.Endpoints.Extensions;

namespace Paychecks.Api.Endpoints;

public static class PaycheckEndpoints
{
    private const string _paychecksApiAddress = "/api/v1/paychecks";

    public static IEndpointRouteBuilder MapPaycheckEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(_paychecksApiAddress);

        group.MapGet("/{id}", GetEmployeePaychecks)
            .WithDescription("Get a list of annual paychecks for an employee.")
            .WithOpenApi();

        return builder;
    }

    private static async Task<Results<
        Ok<ApiResponse<GetSalaryCalculationDto[]>>,
        NotFound<ApiResponse<GetSalaryCalculationDto[]>>>>
        GetEmployeePaychecks(
            [FromServices] EmployeePaycheckCalculationService service,
            int id)
    {
        var result = await service.CalculatePaychecksForEmployeeById(id);
        return result is not null
            ? TypedResults.Ok(new ApiResponse<GetSalaryCalculationDto[]>
            {
                Data = result.Select(SalaryCalculationExtensions.ToGetSalaryCalculationDto).ToArray()
            })
            : TypedResults.NotFound(new ApiResponse<GetSalaryCalculationDto[]>
            {
                Error = $"No employees with id {id} were found."
            });
    }
}
