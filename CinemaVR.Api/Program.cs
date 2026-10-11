using CinemaVR.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger (Swashbuckle 10.x — без Microsoft.OpenApi.Models)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "CinemaVR API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CinemaVR API v1");
});

// Map controllers
app.MapControllers();

// -------------------------
// Запуск HttpServer
// -------------------------

string[] prefixes = { "http://localhost:5218/" };
var server = new CinemaVR.Api.Server.HttpServer(prefixes);

Console.WriteLine("Запуск Http сервера...");
Console.WriteLine("Натисніть 'g' для завершення.");

var serverTask = server.StartAsync();

while (true)
{
    var key = Console.ReadKey(true);
    if (key.KeyChar == 'g' || key.KeyChar == 'G')
        break;
}

Console.WriteLine("Зупинка сервера...");
server.Stop();

// -------------------------
// Запуск Web API
// -------------------------
app.Run();
