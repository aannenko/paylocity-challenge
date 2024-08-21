using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Calculations.Policies;

public sealed class LargerSalaryBenefitsCostPolicy(
    decimal applicabilityValue,
    decimal operationValue,
    string description)
    : ICalculationPolicy
{
    public static Guid Key { get; } = Guid.Parse("1379cca1-67a2-4b0d-bf4f-47d35fb20cc5");

    public void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations)
    {
        if (employee.Salary <= applicabilityValue)
            return;

        foreach (var calculation in salaryCalculations)
            calculation.AddOperation(employee.Salary * operationValue * -1, description);
    }
}
