using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database.Extensions;

public static class EmployeeExtensions
{
    public static int GetAge(this Employee employee)
    {
        var today = DateTime.Today;
        var age = today.Year - employee.DateOfBirth.Year;
        if (employee.DateOfBirth.Date > today.AddYears(-age))
            age--;

        return age;
    }
}
