using CustomDinner.Api.Errors;
using CustomDinner.Application;
using CustomDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler("/error");

app.Run();