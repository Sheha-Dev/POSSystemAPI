using Microsoft.EntityFrameworkCore;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models;
using POSSystemWebAPI.Repositories;
using POSSystemWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<POSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserLocationRepository, UserLocationRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IUserLocationService, UserLocationService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAngular", p =>
        p.WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.Run();