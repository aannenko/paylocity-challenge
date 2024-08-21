using Microsoft.EntityFrameworkCore;

namespace Paychecks.Api.Database.Models;

[Index(nameof(PolicyKey))]
[Index(nameof(ApplicationPriority), IsUnique = true)]
public class PolicyValue
{
    public int Id { get; set; }

    public required Guid PolicyKey { get; set; }

    public required short ApplicationPriority { get; set; }

    public required string Description { get; set; }

    public decimal? ApplicabilityValue { get; set; }

    public required decimal OperationValue { get; set; }
}
