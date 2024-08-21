using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Calculations.Policies;

public sealed class PerDependentBenefitsCostPolicy(decimal operationValue, string description) : ICalculationPolicy
{
    public static Guid Key { get; } = Guid.Parse("df41f833-4e17-4c66-baf0-09260e52998c");

    public void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations)
    {
        if (employee.Dependents?.Count is null or 0)
            return;

        foreach (var calculation in salaryCalculations)
            for (int i = 0; i < employee.Dependents!.Count; i++)
                calculation.AddOperation(operationValue, description);
    }
}
