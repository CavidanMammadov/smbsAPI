using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Models;
using Smbs.Api.Filters;
using Smbs.Api.Services;
using Smbs.Application;
using Smbs.Application.Services.implements;
using Smbs.Application.Services.Interfaces;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence;
using Smbs.Persistence.Repositories;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Kestrel 
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 30 * 1024 * 1024; 
});

// IIS 
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 30 * 1024 * 1024; 
});

// Cloudinary configuration
var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings");

builder.Services.AddSingleton(sp =>
{
    var account = new Account(
        cloudinarySettings["CloudName"],
        cloudinarySettings["ApiKey"],
        cloudinarySettings["ApiSecret"]
    );
    return new Cloudinary(account);
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JwtAuthenticationService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ICorporateTrainingService, CorporateTrainingService>();
builder.Services.AddScoped<ICorporateTrainingRepository, CorporateTrainingRepository>();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "KadrSensibleApi.WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new()
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
    c.MapType<IFormFile>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "binary"
    });
});
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;

    options.AddFixedWindowLimiter("anon-limit", opt =>
    {
        opt.PermitLimit = 100; // 5 request
        opt.Window = TimeSpan.FromMinutes(1); // 1 d?qiq?d?
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;
    });
});

builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMultipleFrontends", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://94.130.218.227:5021",
                "http://94.130.218.227:3009",
                "smbs.az"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Disposition")
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.UseCors("AllowMultipleFrontends");

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
