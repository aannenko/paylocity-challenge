namespace Paychecks.Api.Extensions;

public static class DecimalExtensions
{
    public static IReadOnlyList<decimal> SplitIntoSummableParts(this decimal value, int count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0);

        var wasValueNegative = false;
        if (value < 0)
        {
            wasValueNegative = true;
            value = Math.Abs(value);
        }

        var result = new decimal[count];
        var runningTotal = 0M;
        for (int i = 0; i < count; i++)
        {
            var remainder = value - runningTotal;
            var share = remainder > 0M
                ? Math.Max(Math.Round(remainder / (count - i), 2), .01M)
                : 0M;

            result[i] = share;
            runningTotal += share;
        }

        if (runningTotal < value)
            result[count - 1] += value - runningTotal;

        if (wasValueNegative)
            for (int i = 0; i < result.Length; i++)
                result[i] = -result[i];

        return result;
    }
}
