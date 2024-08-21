using Paychecks.Api.Database.Models;
using Paychecks.Api.Endpoints.Dto;
using System.Text.Json.Serialization;

namespace Paychecks.Api.Serialization;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(PagedApiResponse<GetEmployeeDto[]>))]
[JsonSerializable(typeof(ApiResponse<GetEmployeeDto>))]
[JsonSerializable(typeof(PagedApiResponse<GetDependentDto[]>))]
[JsonSerializable(typeof(ApiResponse<GetDependentDto>))]
[JsonSerializable(typeof(ApiResponse<GetSalaryCalculationDto[]>))]
[JsonSerializable(typeof(Relationship))]
[JsonSerializable(typeof(Relationship?))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
