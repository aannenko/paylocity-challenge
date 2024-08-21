using Paychecks.Api.Database.Models;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.Api.Endpoints.Extensions;

public static class EmployeeExtensions
{
    public static GetEmployeeDto ToGetEmployeeDto(this Employee employee) =>
        new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary,
            DateOfBirth = employee.DateOfBirth,
            Dependents = employee.Dependents?.Select(static dependent => dependent.ToGetDependentDto()).ToArray(),
        };
}
