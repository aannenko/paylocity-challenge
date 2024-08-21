namespace Paychecks.Api.Extensions;

public static class DateTimeExtensions
{
    public static int ToAge(this DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > today.AddYears(-age))
            age--;

        return age;
    }
}
