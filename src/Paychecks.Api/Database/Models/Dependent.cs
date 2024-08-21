using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paychecks.Api.Database.Models;

[Index(nameof(FirstName))]
[Index(nameof(LastName))]
[Index(nameof(DateOfBirth))]
public sealed class Dependent
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required DateTime DateOfBirth { get; set; }

    [Column(TypeName = "varchar(30)")]
    public required Relationship Relationship { get; set; }

    public int EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}
