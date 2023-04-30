using CustomDinner.Api.Filters;
using CustomDinner.Application;
using CustomDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers(options => 
    options.Filters.Add<ErrorHandlingFilterAttribute>());

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();