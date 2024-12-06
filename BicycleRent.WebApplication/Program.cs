using BicycleRent.Domain;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Domain.Repositories.Database;
using BicycleRent.Servicies;


using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<BicycleRentDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repositories

builder.Services.AddTransient<IRepositoryDb<BicycleType, int>, BicycleTypeRepositoryDb>();
builder.Services.AddTransient<IRepositoryDb<Bicycle, int>, BicycleRepositoryDb>();
builder.Services.AddTransient<IRepositoryDb<BicycleRenter, int>, BicycleRenterRepositoryDb>();
builder.Services.AddTransient<IRepositoryDb<Rent, int>, RentRepositoryDb>();
builder.Services.AddTransient<IRepositoryRequestsDb, JobRequestsRepositoryDb>();

// Add mapper
builder.Services.AddAutoMapper(typeof(BicycleRentMapper));


//XML-comments
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bicycle Rent API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
