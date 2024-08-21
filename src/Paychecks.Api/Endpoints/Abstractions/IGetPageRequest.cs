namespace Paychecks.Api.Endpoints.Abstractions;

public interface IGetPageRequest
{
    int Take { get; }

    int AfterId { get; }
}
