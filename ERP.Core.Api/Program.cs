using dotenv.net;

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

// Load environment variables from .env file
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Load JWT settings from environment variables
var jwtSettings = new JwtSettings
{
    Key = Environment.GetEnvironmentVariable("JWT_KEY"),
    Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
    Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
    ExpiryMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES") ?? "60")
};

// Debug: print the JWT key to verify it's loaded (remove in production!)
if (string.IsNullOrEmpty(jwtSettings.Key) || string.IsNullOrEmpty(jwtSettings.Issuer) || string.IsNullOrEmpty(jwtSettings.Audience))
{
   throw new Exception("JWT settings are not properly configured in environment variables.");
}
else
{
    Console.WriteLine($"JWT Key Loaded: {(string.IsNullOrEmpty(jwtSettings.Key) ? "No" : "Yes")}");
    Console.WriteLine($"JWT Issuer Loaded: {(string.IsNullOrEmpty(jwtSettings.Issuer) ? "No" : "Yes")}");
    Console.WriteLine($"JWT Audience Loaded: {(string.IsNullOrEmpty(jwtSettings.Audience) ? "No" : "Yes")}");
}

// 🔗 Build DB connection string from environment variables
var connectionString =
    $"Server=tcp:{Environment.GetEnvironmentVariable("DB_SERVER")},1433;" +
    $"Initial Catalog={Environment.GetEnvironmentVariable("DB_HR")};" +
    $"User ID={Environment.GetEnvironmentVariable("DB_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
    $"Encrypt=True;";

// check if connection string is properly built 
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Database connection string is not properly configured in environment variables.");
}



// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ------------------------------
// Configure JWT settings for DI this allows us to inject IOptions<JwtSettings> in our services and controllers to access the JWT configuration values 
builder.Services.Configure<JwtSettings>(options =>
{
    options.Key = jwtSettings.Key;
    options.Issuer = jwtSettings.Issuer;
    options.Audience = jwtSettings.Audience;
    options.ExpiryMinutes = jwtSettings.ExpiryMinutes;
});

builder.Services.AddScoped<IAuthService, AuthService>();


// -----------------------------
// Database (HR Module)
// -----------------------------
builder.Services.AddDbContext<HrDbContext>(options =>
    options.UseSqlServer(connectionString));

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

            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Key)),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// configure CORS to allow requests from the React frontend (adjust the URL as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // your React URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


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

// Enable CORS before authentication and authorization middleware to ensure that CORS headers are included in responses, even for unauthorized requests. This allows the React frontend to receive appropriate CORS headers and handle responses correctly.
app.UseCors("AllowReact");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();