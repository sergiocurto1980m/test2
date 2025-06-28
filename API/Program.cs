using Application.Behaviors;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CleanArchDb")); // Puedes cambiarlo a SQL Server

// MediatR y Pipeline
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ProductoService).Assembly));

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));


builder.Services.AddApplicationServices();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
