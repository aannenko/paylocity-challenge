using Paychecks.Api.Database.Models;
using Paychecks.Api.Calculations.Policies;

namespace Paychecks.Api.Database.Extensions;

internal static class DbSeedingServiceCollectionExtensions
{
    internal static Employee[] Employees { get; } =
    [
        new()
        {
            Id = 1,
            FirstName = "LeBron",
            LastName = "James",
            Salary = 75420.99m,
            DateOfBirth = new DateTime(1984, 12, 30)
        },
        new()
        {
            Id = 2,
            FirstName = "Ja",
            LastName = "Morant",
            Salary = 92365.22m,
            DateOfBirth = new DateTime(1999, 8, 10),
            Dependents =
            [
                new()
                {
                    Id = 1,
                    FirstName = "Spouse",
                    LastName = "Morant",
                    Relationship = Relationship.Spouse,
                    DateOfBirth = new DateTime(1998, 3, 3)
                },
                new()
                {
                    Id = 2,
                    FirstName = "Child1",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2020, 6, 23)
                },
                new()
                {
                    Id = 3,
                    FirstName = "Child2",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2021, 5, 18)
                }
            ]
        },
        new()
        {
            Id = 3,
            FirstName = "Michael",
            LastName = "Jordan",
            Salary = 143211.12m,
            DateOfBirth = new DateTime(1963, 2, 17),
            Dependents =
            [
                new()
                {
                    Id = 4,
                    FirstName = "DP",
                    LastName = "Jordan",
                    Relationship = Relationship.DomesticPartner,
                    DateOfBirth = new DateTime(1974, 1, 2)
                }
            ]
        }
    ];

    internal static PolicyValue[] PolicyValues { get; } =
    [
        new()
        {
            PolicyKey = BaseBenefitsCostPolicy.Key,
            ApplicationPriority = 5000,
            Description = "Subtract base benefit cost",
            OperationValue = -1000 * 12,
        },
        new()
        {
            PolicyKey = PerDependentBenefitsCostPolicy.Key,
            ApplicationPriority = 10000,
            Description = "Subtract benefit cost per each dependent",
            OperationValue = -600 * 12,
        },
        new()
        {
            PolicyKey = DependentsOfAgeBenefitsCostPolicy.Key,
            ApplicationPriority = 15000,
            Description = "Subtract additional benefit cost per each employee's dependent who is at least 50 years old",
            ApplicabilityValue = 50,
            OperationValue = -200 * 12,
        },
        new()
        {
            PolicyKey = LargerSalaryBenefitsCostPolicy.Key,
            ApplicationPriority = 20000,
            Description = "Subtract 2% of benefit cost if the employee's salary is larger than 80000",
            ApplicabilityValue = 80000,
            OperationValue = 0.02m,
        },
        new()
        {
            PolicyKey = SplitSalaryIntoPaychecksPolicy.Key,
            ApplicationPriority = 30000,
            Description = "Split annual income into this many parts",
            OperationValue = 26,
        },
    ];

    public static async Task DeleteCreateSeedDatabase(this AppDbContext dbContext)
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
        await dbContext.Employees.AddRangeAsync(Employees);
        await dbContext.PolicyValues.AddRangeAsync(PolicyValues);
        await dbContext.SaveChangesAsync();
    }
}
