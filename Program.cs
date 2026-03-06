using APIService.Data;
using APIService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<GameDbContext>(opt =>
    opt.UseInMemoryDatabase("GameDB"));
builder.Services.AddScoped<GameRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.MapGet("/", () => "Welcome to the GuessTheNumber API!");

app.UseAuthorization();

app.MapControllers();

app.Run();
