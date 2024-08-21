using Paychecks.Api.Database.Models;
using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Extensions;

namespace Paychecks.Api.Calculations.Policies;

public sealed class SplitSalaryIntoPaychecksPolicy(decimal operationValue) : ICalculationPolicy
{
    public static Guid Key { get; } = Guid.Parse("c4498953-84fb-42c9-b8eb-80793e26a356");

    public void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations)
    {
        if (salaryCalculations.Length != 1)
            throw new ArgumentException($"This policy expects {nameof(salaryCalculations)} to have a length of 1.");

        var originalCalculation = salaryCalculations[0];
        var splitSalaryCalculations = new SalaryCalculation[(int)operationValue];
        foreach (var (value, description) in originalCalculation.SalaryOperations)
        {
            var splitValue = value.SplitIntoSummableParts(splitSalaryCalculations.Length);
            for (int i = 0; i < splitSalaryCalculations.Length; i++)
            {
                var currentCalculation = splitSalaryCalculations[i] ?? (splitSalaryCalculations[i] = new());
                currentCalculation.AddOperation(splitValue[i], description);
            }
        }

        salaryCalculations = splitSalaryCalculations;
    }
}
