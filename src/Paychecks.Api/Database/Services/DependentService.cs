using Microsoft.EntityFrameworkCore;
using Paychecks.Api.Database.Dto;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database.Services;

public sealed class DependentService(AppDbContext dbContext)
{
    public Task<Dependent[]> GetPageAsync(PageDescriptor pageDescriptor, DependentFilter? filter)
    {
        var query = dbContext.Dependents.AsNoTracking();

        if (filter is not null)
        {
            if (filter.EmployeeId is not null)
                query = query.Where(dependent => dependent.EmployeeId == filter.EmployeeId);

            if (!string.IsNullOrEmpty(filter.FirstNameStartsWith))
                query = query.Where(dependent => dependent.FirstName.StartsWith(filter.FirstNameStartsWith));

            if (!string.IsNullOrEmpty(filter.LastNameStartsWith))
                query = query.Where(dependent => dependent.LastName.StartsWith(filter.LastNameStartsWith));

            if (filter.DateOfBirthMin is not null)
                query = query.Where(dependent => dependent.DateOfBirth >= filter.DateOfBirthMin);

            if (filter.DateOfBirthMax is not null)
                query = query.Where(dependent => dependent.DateOfBirth <= filter.DateOfBirthMax);

            if (filter.Relationship is not null)
                query = query.Where(dependent => dependent.Relationship == filter.Relationship);
        }

        return query.OrderBy(static dependent => dependent.Id)
            .Where(dependent => dependent.Id > pageDescriptor.AfterId)
            .Take(pageDescriptor.Take)
            .ToArrayAsync();
    }

    public Task<Dependent?> FindOneByIdAsync(int id)
    {
        return dbContext.Dependents.FirstOrDefaultAsync(dependent => dependent.Id == id);
    }
}
