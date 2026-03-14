using ERP.Core.Api.Services;
using ERP.Core.Api.Settings;

using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Application.Services;
using ERP.HumanResources.Infrastructure.Persistence;
using ERP.HumanResources.Infrastructure.Repositories;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// -----------------------------
// JWT Settings
// -----------------------------
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddScoped<IAuthService, AuthService>();


// -----------------------------
// Database (HR Module)
// -----------------------------
builder.Services.AddDbContext<HrDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRConnection")));


// -----------------------------
// HR Module Services
// -----------------------------
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


// -----------------------------
// Authentication
// -----------------------------
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


// -----------------------------
// Build App
// -----------------------------
var app = builder.Build();


// -----------------------------
// Middleware
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();