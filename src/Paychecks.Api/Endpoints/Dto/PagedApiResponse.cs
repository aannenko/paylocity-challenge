namespace Paychecks.Api.Endpoints.Dto;

public sealed class PagedApiResponse<T> : ApiResponse<T>
{
    public string NextPage { get; set; } = string.Empty;
}
