using Paychecks.Api.Database.Dto;
using Paychecks.Api.Database.Models;
using Paychecks.Api.Endpoints.Abstractions;

namespace Paychecks.Api.Endpoints.Dto;

public sealed record GetDependentsPageRequest(
    int Take = PageDescriptor.DefaultTake,
    int AfterId = PageDescriptor.DefaultAfterId,
    string? FirstNameStartsWith = null,
    string? LastNameStartsWith = null,
    DateTime? DateOfBirthMin = null,
    DateTime? DateOfBirthMax = null,
    Relationship? Relationship = null)
    : IGetPageRequest;
