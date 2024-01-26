using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Data;
using TaskLoggerApi.Interfaces;
using TaskLoggerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext with the connection string
builder.Services.AddDbContext<TaskLoggerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connString")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7089"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
