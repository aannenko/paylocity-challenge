using Paychecks.Api.Calculations.Services;
using Paychecks.Api.Database;
using Paychecks.Api.Database.Extensions;
using Paychecks.Api.Database.Services;
using Paychecks.Api.Endpoints;
using Paychecks.Api.Extensions;
using Paychecks.Api.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(
    options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default));

builder.Services.AddProblemDetails();
builder.Services.AddSwaggerWithTrimmingSupport();
builder.Services.AddMemoryCacheWithSizeLimit(builder.Configuration);

builder.Services.AddAppDbContext();
builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<DependentService>();
builder.Services.AddTransient<PolicyValuesService>();
builder.Services.AddTransient<PolicyProvider>();
builder.Services.AddTransient<EmployeePaycheckCalculationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<AppDbContext>().DeleteCreateSeedDatabase();
}
else
{
    app.UseExceptionHandler();
}

app.UseStatusCodePages();

app.MapEmployeeEndpoints();
app.MapDependentEndpoints();
app.MapPaycheckEndpoints();

app.Run();
