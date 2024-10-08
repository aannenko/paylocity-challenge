namespace Paychecks.Api.Endpoints.Dto;

public sealed class GetEmployeeDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal Salary { get; set; }

    public DateTime DateOfBirth { get; set; }

    public ICollection<GetDependentDto>? Dependents { get; set; }
}
