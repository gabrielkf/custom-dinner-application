using CustomDinner.Api;
using CustomDinner.Application;
using CustomDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler("/error");

app.Run();