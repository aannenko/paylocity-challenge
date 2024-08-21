using Microsoft.EntityFrameworkCore;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database;

[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Trimming",
    "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code",
    Justification = $"{nameof(AppDbContext)} is checked manually and its functionality is covered with tests.")]
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Dependent> Dependents { get; set; }

    public DbSet<PolicyValue> PolicyValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>()
        //    .Property(static employee => employee.DateOfBirth)
        //    .HasConversion(
        //        value => value.ToUniversalTime(),
        //        value => new DateTime(value.Ticks, DateTimeKind.Utc));

        modelBuilder.Entity<Employee>()
            .Property(static employee => employee.Salary)
            .HasConversion<double>();

        modelBuilder.Entity<PolicyValue>()
            .Property(static policyValue => policyValue.ApplicabilityValue)
            .HasConversion<double>();

        modelBuilder.Entity<PolicyValue>()
            .Property(static policyValue => policyValue.OperationValue)
            .HasConversion<double>();
    }
}
