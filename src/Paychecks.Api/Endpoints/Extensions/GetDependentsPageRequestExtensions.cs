using Paychecks.Api.Database.Dto;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.Api.Endpoints.Extensions;

public static class GetDependentsPageRequestExtensions
{
    public static DependentFilter? ToDependentFilter(this GetDependentsPageRequest request)
    {
        DependentFilter? filter = null;
        if (request.FirstNameStartsWith is not null ||
            request.LastNameStartsWith is not null ||
            request.DateOfBirthMin is not null ||
            request.DateOfBirthMax is not null ||
            request.Relationship is not null)
        {
            filter = new(
                request.FirstNameStartsWith,
                request.LastNameStartsWith,
                request.DateOfBirthMin,
                request.DateOfBirthMax,
                request.Relationship);
        }

        return filter;
    }
}
