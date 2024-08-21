using Paychecks.Api.Calculations.Abstractions;

namespace Paychecks.Api.Calculations.Dto;

public sealed class SalaryCalculation : ISalaryCalculation
{
    private readonly List<(decimal Value, string Description)> _salaryOperations = [];
    
    public IReadOnlyList<(decimal Value, string Description)> SalaryOperations => _salaryOperations;

    public decimal Total { get; private set; }

    public void AddOperation(decimal value, string description)
    {
        _salaryOperations.Add((value, description));
        Total += value;
    }
}
