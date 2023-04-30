using CustomDinner.Application;
using CustomDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler("/errors");

app.Run();