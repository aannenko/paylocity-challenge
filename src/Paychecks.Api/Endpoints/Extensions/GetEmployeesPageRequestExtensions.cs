using Paychecks.Api.Database.Dto;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.Api.Endpoints.Extensions;

public static class GetEmployeesPageRequestExtensions
{
    public static EmployeeFilter? ToEmployeeFilter(this GetEmployeesPageRequest request)
    {
        EmployeeFilter? filter = null;
        if (request.FirstNameStartsWith is not null ||
            request.LastNameStartsWith is not null ||
            request.SalaryMin is not null ||
            request.SalaryMax is not null ||
            request.DateOfBirthMin is not null ||
            request.DateOfBirthMax is not null)
        {
            filter = new(
                request.FirstNameStartsWith,
                request.LastNameStartsWith,
                request.SalaryMin,
                request.SalaryMax,
                request.DateOfBirthMin,
                request.DateOfBirthMax);
        }

        return filter;
    }
}
