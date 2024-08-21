using Paychecks.Api.Database.Dto;
using Paychecks.Api.Endpoints.Abstractions;

namespace Paychecks.Api.Endpoints.Dto;

public sealed record GetEmployeesPageRequest(
    int Take = PageDescriptor.DefaultTake,
    int AfterId = PageDescriptor.DefaultAfterId,
    string? FirstNameStartsWith = null,
    string? LastNameStartsWith = null,
    decimal? SalaryMin = null,
    decimal? SalaryMax = null,
    DateTime? DateOfBirthMin = null,
    DateTime? DateOfBirthMax = null)
    : IGetPageRequest;
