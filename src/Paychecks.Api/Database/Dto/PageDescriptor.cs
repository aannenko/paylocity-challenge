namespace Paychecks.Api.Database.Dto;

public readonly record struct PageDescriptor(
    int Take = PageDescriptor.DefaultTake,
    int AfterId = PageDescriptor.DefaultAfterId)
{
    internal const int DefaultTake = 20;
    internal const int DefaultAfterId = 0;
}
