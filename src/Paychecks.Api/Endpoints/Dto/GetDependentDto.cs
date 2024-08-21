using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Endpoints.Dto;

public sealed class GetDependentDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Relationship Relationship { get; set; }
}
