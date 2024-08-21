namespace Paychecks.Api.Endpoints.Dto;

public sealed class GetSalaryCalculationDto
{
    public KeyValuePair<decimal, string>[] SalaryOperations { get; set; } = [];

    public decimal Total { get; set; }
}
