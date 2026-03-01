using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Application.Services;
using ERP.HumanResources.Infrastructure.Persistence;
using ERP.HumanResources.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<HrDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HrDb")));

// Register repositories and services
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JWT authentication 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "ERP.Core",
            ValidAudience = "ERP.Users",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_CHANGE_LATER")),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// Register application services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
