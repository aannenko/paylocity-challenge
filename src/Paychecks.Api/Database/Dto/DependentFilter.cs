using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database.Dto;

public sealed record DependentFilter(
    string? FirstNameStartsWith = null,
    string? LastNameStartsWith = null,
    DateTime? DateOfBirthMin = null,
    DateTime? DateOfBirthMax = null,
    Relationship? Relationship = null);
