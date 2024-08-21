using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Calculations.Policies;

public sealed class BaseBenefitsCostPolicy(decimal operationValue, string description) : ICalculationPolicy
{
    public static Guid Key { get; } = Guid.Parse("162bd473-a8a1-4676-a9eb-85d1e6160580");

    public void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations)
    {
        foreach (var calculation in salaryCalculations)
            calculation.AddOperation(operationValue, description);
    }
}
