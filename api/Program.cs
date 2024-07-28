using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using api.Data;
using api.controllers;
using api.Interfaces;
using api.Repository;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<apiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("apiContext") ?? throw new InvalidOperationException("Connection string 'apiContext' not found.")));

builder.Services.AddScoped<IWeatherLocationsRepository, WeatherLocationsRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
