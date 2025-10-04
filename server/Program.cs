using System.IO;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using server.Api.Common.Conventions;
using server.Api.Common.Transformers;
using server.Application.Common.Behaviors;
using server.Application.Common.Contracts;
using server.Application.WeatherForecasts.Queries;
using server.Infrastructure.Persistence;
using server.Infrastructure.Services;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Aladdin API",
        Version = "v1",
        Description = "Personal Finance & Productivity App (.NET Core)",
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    // Define JWT Bearer security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Authorization: Bearer {token}'"
    });

    // Require Bearer security on operations unless explicitly marked AllowAnonymous
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });

    // Include XML comments in the Swagger doc
    var xmlFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
    if (xmlFile != null)
    {
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
        {
            options.IncludeXmlComments(xmlPath);
        }
    }
});

// Add controllers with a global "/api" route prefix and kebab-case route tokens
builder.Services.AddControllers(options =>
{
    // /api prefix for all attribute-routed controllers
    options.Conventions.Insert(0, new GlobalRoutePrefixConvention(new RouteAttribute("api")));

    // hyphenate [controller] and [action] tokens: WeatherForecast -> weather-forecast
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});

// MediatR registration - scan handlers in the Application assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetWeatherForecastQueryHandler>());

// FluentValidation - scan validators in the Application assembly
builder.Services.AddValidatorsFromAssemblyContaining<GetWeatherForecastQueryHandler>();

// AutoMapper - scan Profiles in the Application assembly
builder.Services.AddAutoMapper(typeof(server.Application.Transactions.Profiles.TransactionProfile).Assembly);

// MediatR Pipeline Behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

// EF Core - AppDbContext with MySQL (Pomelo)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
    }

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
    {
        mySqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
    });
});

builder.Services.Configure<FileUploadOptions>(
    builder.Configuration.GetSection("FileUpload"));

builder.Services.AddScoped<FileUploadServiceContract, FileUploadService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Restrict API docs in production: enabled by default only in Development.
var openApiEnabled = app.Configuration.GetValue<bool>("OpenApi:Enabled", app.Environment.IsDevelopment());
if (openApiEnabled)
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aladdin API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
