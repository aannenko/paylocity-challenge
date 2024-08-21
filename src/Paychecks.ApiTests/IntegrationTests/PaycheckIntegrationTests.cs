using System.Net;
using Paychecks.Api.Database.Models;
using Paychecks.Api.Endpoints.Dto;

namespace Paychecks.ApiTests.IntegrationTests;

public class PaycheckIntegrationTests : IntegrationTest
{
    [Fact]
    public async Task WhenAskedForJaMorantPaychecks_ShouldReturnCorrectValues()
    {
        var response = await HttpClient.GetAsync("/api/v1/paychecks/2");
        var paychecks = new List<GetSalaryCalculationDto>
        {
            new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },
            new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.13m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.13m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.13m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.16m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.13m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.50m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.15m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.53m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.14m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.50m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.15m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.53m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.14m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.50m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.15m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.53m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.14m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.50m, "Base salary"),
                    new(-461.54m, "Subtract base benefit cost"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-276.92m, "Subtract benefit cost per each dependent"),
                    new(-71.05m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.15m
            },new()
            {
                SalaryOperations =
                [
                    new(3552.51m, "Base salary"),
                    new(-461.53m, "Subtract base benefit cost"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-276.93m, "Subtract benefit cost per each dependent"),
                    new(-71.0544m, "Subtract 2% of benefit cost if the employee's salary is larger than 80000"),
                ],
                Total = 2189.1356m
            },
        };

        await response.ShouldReturn(HttpStatusCode.OK, paychecks);
    }
}
