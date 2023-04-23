using CustomDinner.Application.Injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();