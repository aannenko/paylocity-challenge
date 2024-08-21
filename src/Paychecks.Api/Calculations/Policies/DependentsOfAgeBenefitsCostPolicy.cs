using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;
using Paychecks.Api.Extensions;

namespace Paychecks.Api.Calculations.Policies;

public sealed class DependentsOfAgeBenefitsCostPolicy(
    decimal applicabilityValue,
    decimal operationValue,
    string description)
    : ICalculationPolicy
{
    public static Guid Key { get; } = Guid.Parse("8c158f1f-367e-4210-8927-5ad8f5d3bbde");

    public void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations)
    {
        if (employee.Dependents?.Count is null or 0)
            return;

        foreach (var calculation in salaryCalculations)
            foreach (var dependent in employee.Dependents.Where(d => d.DateOfBirth.ToAge() >= applicabilityValue))
                calculation.AddOperation(operationValue, description);
    }
}
