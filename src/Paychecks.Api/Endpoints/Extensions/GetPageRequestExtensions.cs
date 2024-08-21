using Paychecks.Api.Database.Dto;
using Paychecks.Api.Endpoints.Abstractions;

namespace Paychecks.Api.Endpoints.Extensions;

public static class GetPageRequestExtensions
{
    public static PageDescriptor ToPageDescriptor<T>(this T request) where T : IGetPageRequest =>
       new(request.Take, request.AfterId);
}
