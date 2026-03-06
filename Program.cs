using APIService.Data;
using APIService.Models;
using APIService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
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
app.MapGet("/", () => "Welcome to the APIService for the ASI_GuessTheNumber game!");

app.UseAuthorization();

app.MapControllers();

app.Run();
