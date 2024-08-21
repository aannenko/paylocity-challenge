using Microsoft.EntityFrameworkCore;
namespace Paychecks.Api.Database.Models;

[Index(nameof(FirstName))]
[Index(nameof(LastName))]
[Index(nameof(Salary))]
[Index(nameof(DateOfBirth))]
public sealed class Employee
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required decimal Salary { get; set; }

    public required DateTime DateOfBirth { get; set; }

    public ICollection<Dependent>? Dependents { get; set; }
}
