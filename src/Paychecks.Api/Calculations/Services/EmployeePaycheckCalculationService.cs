using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;
using Paychecks.Api.Database.Services;

namespace Paychecks.Api.Calculations.Services;

public sealed class EmployeePaycheckCalculationService(
    EmployeeService employeeService,
    PolicyProvider policyProvider)
{
    public async Task<IReadOnlyList<ISalaryCalculation>?> CalculatePaychecksForEmployeeById(int id)
    {
        var employee = await employeeService.FindOneByIdAsync(id);
        if (employee is null)
            return null;

        var policies = await policyProvider.GetCurrentPoliciesAsync();
        var builder = new PaycheckBuilder(employee);
        foreach (var policy in policies)
            builder.ApplyPolicy(policy);

        return builder.Build();
    }
}

file sealed class PaycheckBuilder
{
    private readonly Employee _employee;
    private SalaryCalculation[] _salaryCalculations;

    public PaycheckBuilder(Employee employee)
    {
        _employee = employee;

        var baseCalculation = new SalaryCalculation();
        baseCalculation.AddOperation(_employee.Salary, "Base salary");
        _salaryCalculations = [baseCalculation];
    }

    public void ApplyPolicy(ICalculationPolicy policy) =>
        policy.Apply(_employee, ref _salaryCalculations);

    public IReadOnlyList<ISalaryCalculation> Build() =>
        _salaryCalculations;
}
