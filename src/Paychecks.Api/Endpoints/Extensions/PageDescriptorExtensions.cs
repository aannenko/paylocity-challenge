using Paychecks.Api.Database.Dto;
using System.Net;
using System.Text;

namespace Paychecks.Api.Endpoints.Extensions;

internal static class PageDescriptorExtensions
{
    public static string GetNextPageAddress(
        this PageDescriptor pageDescriptor,
        string baseAddress,
        int afterId,
        EmployeeFilter? filter)
    {
        var builder = GetBaseBuilder(baseAddress, afterId, pageDescriptor);

        if (filter is null)
            return builder.ToString();

        if (!string.IsNullOrEmpty(filter.FirstNameStartsWith))
            builder.AppendParameter(nameof(filter.FirstNameStartsWith), filter.FirstNameStartsWith);

        if (!string.IsNullOrEmpty(filter.LastNameStartsWith))
            builder.AppendParameter(nameof(filter.LastNameStartsWith), filter.LastNameStartsWith);

        if (filter.SalaryMin is not null)
            builder.AppendParameter(nameof(filter.SalaryMin), filter.SalaryMin);

        if (filter.SalaryMax is not null)
            builder.AppendParameter(nameof(filter.SalaryMax), filter.SalaryMax);

        if (filter.DateOfBirthMin is not null)
            builder.AppendParameter(nameof(filter.DateOfBirthMin), filter.DateOfBirthMin);

        if (filter.DateOfBirthMax is not null)
            builder.AppendParameter(nameof(filter.DateOfBirthMax), filter.DateOfBirthMax);

        return builder.ToString();
    }

    public static string GetNextPageAddress(
        this PageDescriptor pageDescriptor,
        string baseAddress,
        int afterId,
        DependentFilter? filter)
    {
        var builder = GetBaseBuilder(baseAddress, afterId, pageDescriptor);

        if (filter is null)
            return builder.ToString();

        if (!string.IsNullOrEmpty(filter.FirstNameStartsWith))
            builder.AppendParameter(nameof(filter.FirstNameStartsWith), filter.FirstNameStartsWith);

        if (!string.IsNullOrEmpty(filter.LastNameStartsWith))
            builder.AppendParameter(nameof(filter.LastNameStartsWith), filter.LastNameStartsWith);

        if (filter.DateOfBirthMin is not null)
            builder.AppendParameter(nameof(filter.DateOfBirthMin), filter.DateOfBirthMin);

        if (filter.DateOfBirthMax is not null)
            builder.AppendParameter(nameof(filter.DateOfBirthMax), filter.DateOfBirthMax);

        if (filter.Relationship is not null)
            builder.AppendParameter(nameof(filter.Relationship), filter.Relationship.ToString()!);

        return builder.ToString();
    }

    private static StringBuilder GetBaseBuilder(string baseAddress, int afterId, PageDescriptor pageDescriptor)
    {
        return new StringBuilder()
            .Append(baseAddress)
            .Append("?take=")
            .Append(pageDescriptor.Take)
            .Append("&afterId=")
            .Append(afterId);
    }

    private static StringBuilder AppendParameter<T>(this StringBuilder builder, string name, T value) =>
        builder.Append('&')
            .Append(char.ToLowerInvariant(name[0]))
            .Append(name.AsSpan(1))
            .Append('=')
            .Append(value);

    private static StringBuilder AppendParameter(this StringBuilder builder, string name, string value) =>
        builder.Append('&')
            .Append(char.ToLowerInvariant(name[0]))
            .Append(name.AsSpan(1))
            .Append('=')
            .Append(WebUtility.UrlEncode(value));
}
