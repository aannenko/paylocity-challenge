namespace Paychecks.Api.Calculations.Abstractions;

public interface ISalaryCalculation
{
    IReadOnlyList<(decimal Value, string Description)> SalaryOperations { get; }

    decimal Total { get; }
}
