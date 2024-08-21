using Paychecks.Api.Calculations.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Calculations.Abstractions;

public interface ICalculationPolicy
{
    void Apply(Employee employee, ref SalaryCalculation[] salaryCalculations);
}
