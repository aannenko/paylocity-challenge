using Paychecks.Api.Calculations.Abstractions;
using Paychecks.Api.Calculations.Policies;
using Paychecks.Api.Database.Models;
using Paychecks.Api.Database.Services;
using System.Collections.Frozen;

namespace Paychecks.Api.Calculations.Services;

public sealed class PolicyProvider(PolicyValuesService service)
{
    private static readonly FrozenDictionary<Guid, Func<PolicyValue, ICalculationPolicy>> _policyFactories =
        new Dictionary<Guid, Func<PolicyValue, ICalculationPolicy>>
        {
            { BaseBenefitsCostPolicy.Key, CreateBaseBenefitsCostPolicy },
            { PerDependentBenefitsCostPolicy.Key, CreatePerDependentBenefitsCostPolicy },
            { DependentsOfAgeBenefitsCostPolicy.Key, CreateEmployeeOfAgeBenefitsCostPolicy },
            { LargerSalaryBenefitsCostPolicy.Key, CreateLargerSalaryBenefitsCostPolicy },
            { SplitSalaryIntoPaychecksPolicy.Key, CreateSplitSalaryIntoPaychecksPolicy },
        }.ToFrozenDictionary();

    public async Task<IReadOnlyList<ICalculationPolicy>> GetCurrentPoliciesAsync()
    {
        var policiesList = new List<ICalculationPolicy>();

        await foreach (var policyValue in service.GetAllPoliciesOrderedByPriority())
            policiesList.Add(_policyFactories[policyValue.PolicyKey](policyValue));

        return policiesList;
    }

    private static ICalculationPolicy CreateBaseBenefitsCostPolicy(PolicyValue value) =>
        new BaseBenefitsCostPolicy(value.OperationValue, value.Description);

    private static ICalculationPolicy CreatePerDependentBenefitsCostPolicy(PolicyValue value) =>
        new PerDependentBenefitsCostPolicy(value.OperationValue, value.Description);

    private static ICalculationPolicy CreateEmployeeOfAgeBenefitsCostPolicy(PolicyValue value) =>
        new DependentsOfAgeBenefitsCostPolicy(value.ApplicabilityValue!.Value, value.OperationValue, value.Description);

    private static ICalculationPolicy CreateLargerSalaryBenefitsCostPolicy(PolicyValue value) =>
        new LargerSalaryBenefitsCostPolicy(value.ApplicabilityValue!.Value, value.OperationValue, value.Description);

    private static ICalculationPolicy CreateSplitSalaryIntoPaychecksPolicy(PolicyValue value) =>
        new SplitSalaryIntoPaychecksPolicy(value.OperationValue);
}
