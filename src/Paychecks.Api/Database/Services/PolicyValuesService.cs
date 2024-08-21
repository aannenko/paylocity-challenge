using Microsoft.EntityFrameworkCore;
using Paychecks.Api.Database.Models;

namespace Paychecks.Api.Database.Services;

public sealed class PolicyValuesService(AppDbContext dbContext)
{
    public IAsyncEnumerable<PolicyValue> GetAllPoliciesOrderedByPriority()
    {
        return dbContext.PolicyValues.AsNoTracking()
            .OrderBy(static policy => policy.ApplicationPriority)
            .AsAsyncEnumerable();
    }

    public async Task AddPolicyValue(
        Guid policyKey,
        short applicationPriority,
        string description,
        decimal? IsApplicableValue,
        decimal PolicyOperationValue)
    {
        dbContext.PolicyValues.Add(new()
        {
            PolicyKey = policyKey,
            ApplicationPriority = applicationPriority,
            Description = description,
            ApplicabilityValue = IsApplicableValue,
            OperationValue = PolicyOperationValue,
        });

        await dbContext.SaveChangesAsync();
    }
}
