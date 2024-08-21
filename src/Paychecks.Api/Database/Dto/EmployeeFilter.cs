namespace Paychecks.Api.Database.Dto;

public sealed record EmployeeFilter(
    string? FirstNameStartsWith = null,
    string? LastNameStartsWith = null,
    decimal? SalaryMin = null,
    decimal? SalaryMax = null,
    DateTime? DateOfBirthMin = null,
    DateTime? DateOfBirthMax = null);
