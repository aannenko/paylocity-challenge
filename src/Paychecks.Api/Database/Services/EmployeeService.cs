using Microsoft.EntityFrameworkCore;
using Paychecks.Api.Database.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database.Services;

public sealed class EmployeeService(AppDbContext dbContext)
{
    public Task<Employee[]> GetPageAsync(PageDescriptor pageDescriptor, EmployeeFilter? filter)
    {
        var query = dbContext.Employees.Include(employee => employee.Dependents).AsNoTracking();

        if (filter is not null)
        {
            if (!string.IsNullOrEmpty(filter.FirstNameStartsWith))
                query = query.Where(employee => employee.FirstName.StartsWith(filter.FirstNameStartsWith));

            if (!string.IsNullOrEmpty(filter.LastNameStartsWith))
                query = query.Where(employee => employee.LastName.StartsWith(filter.LastNameStartsWith));

            if (filter.SalaryMin is not null)
                query = query.Where(employee => employee.Salary >= filter.SalaryMin);

            if (filter.SalaryMax is not null)
                query = query.Where(employee => employee.Salary <= filter.SalaryMax);

            if (filter.DateOfBirthMin is not null)
                query = query.Where(employee => employee.DateOfBirth >= filter.DateOfBirthMin);

            if (filter.DateOfBirthMax is not null)
                query = query.Where(employee => employee.DateOfBirth <= filter.DateOfBirthMax);
        }

        return query.OrderBy(static employee => employee.Id)
            .Where(employee => employee.Id > pageDescriptor.AfterId)
            .Take(pageDescriptor.Take)
            .ToArrayAsync();
    }

    public Task<Employee?> FindOneByIdAsync(int id)
    {
        return dbContext.Employees
            .Include(employee => employee.Dependents)
            .AsNoTracking()
            .FirstOrDefaultAsync(employee => employee.Id == id);
    }
}
