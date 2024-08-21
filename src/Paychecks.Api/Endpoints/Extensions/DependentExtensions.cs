using Paychecks.Api.Database.Models;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.Api.Endpoints.Extensions;

public static class DependentExtensions
{
    public static GetDependentDto ToGetDependentDto(this Dependent dependent) =>
        new()
        {
            Id = dependent.Id,
            FirstName = dependent.FirstName,
            LastName = dependent.LastName,
            DateOfBirth = dependent.DateOfBirth,
            Relationship = dependent.Relationship,
        };
}
