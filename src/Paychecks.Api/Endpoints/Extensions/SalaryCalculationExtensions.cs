using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.Api.Endpoints.Extensions;

public static class SalaryCalculationExtensions
{
    public static GetSalaryCalculationDto ToGetSalaryCalculationDto(this ISalaryCalculation salaryCalculation) =>
        new()
        {
            SalaryOperations = salaryCalculation.SalaryOperations
                .Select(tuple => new KeyValuePair<decimal, string>(tuple.Value, tuple.Description))
                .ToArray(),
            
            Total = salaryCalculation.Total,
        };
}
