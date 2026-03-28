using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using DeliveryService.Application.Commands;
using DeliveryService.Domain.Interfaces;
using DeliveryService.Infrastructure.Persistence;
using DeliveryService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Database
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryConnection")));

// 2. Repository
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

// 3. MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateDeliveryCommand).Assembly));

// 4. JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "B2BCoffeeRoastery_SuperSecretKey_2026_ChangeMe!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "B2BCoffeeRoastery";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 5. Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "🚚 B2B Coffee Roastery – Delivery Service", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token. Example: Bearer eyJhbGci..."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

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