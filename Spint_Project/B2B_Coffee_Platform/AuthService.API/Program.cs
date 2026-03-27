using AuthService.Application.Commands;
using AuthService.Domain.Entities;
using AuthService.Domain.Enums;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Persistence;
using AuthService.Infrastructure.Repositories;
using AuthService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AuthService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ─── 1. Database ───────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// ─── 2. Repository & JWT Service ───────────────────────────────────────────────
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// ─── 3. MediatR ────────────────────────────────────────────────────────────────
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));

// ─── 4. JWT Authentication ─────────────────────────────────────────────────────
var jwtKey = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = jwtIssuer,
            ValidAudience            = jwtIssuer,
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ─── 5. Swagger with Bearer Token Support ──────────────────────────────────────
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title   = "☕ B2B Coffee Roastery – Auth Service",
        Version = "v1"
    });

    // Add the "Authorize" button to Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name         = "Authorization",
        Type         = SecuritySchemeType.Http,
        Scheme       = "Bearer",
        BearerFormat = "JWT",
        In           = ParameterLocation.Header,
        Description  = "Enter your JWT token. Example: Bearer eyJhbGci..."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ─── 6. Auto-migrate & Seed Superadmin ────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db         = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    var userRepo   = scope.ServiceProvider.GetRequiredService<IUserRepository>();

    // Apply any pending migrations automatically
    db.Database.Migrate();

    // If no users exist at all, seed the one Superadmin
    bool hasUsers = await userRepo.AnyUsersExistAsync(CancellationToken.None);
    if (!hasUsers)
    {
        var superAdminPassword = builder.Configuration["Seeding:SuperadminPassword"]
                                 ?? "SuperAdmin@123";

        var superadmin = new AppUser(
            fullName:        "Super Admin",
            email:           "superadmin@coffeeroastery.com",
            passwordHash:    BCrypt.Net.BCrypt.HashPassword(superAdminPassword),
            role:            UserRole.Superadmin,
            createdByUserId: null
        );

        await userRepo.AddAsync(superadmin, CancellationToken.None);
        Console.WriteLine("✅ Superadmin seeded: superadmin@coffeeroastery.com");
    }
}

// ─── 7. Middleware Pipeline ────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();   // MUST come before UseAuthorization
app.UseAuthorization();
app.MapControllers();
app.Run();
