using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext with the connection string
builder.Services.AddDbContext<TaskLoggerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
