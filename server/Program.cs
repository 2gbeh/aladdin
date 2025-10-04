using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using server.Api.Common.Conventions;
using server.Api.Common.Routing;
using server.Application.Common.Behaviors;
using server.Application.WeatherForecasts.Queries;
using server.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Enrich the OpenAPI document (metadata + security)
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "Aladdin API",
            Version = "v1",
            Description = "HTTP API for the Aladdin application (Weather, Transactions, Contacts, Tasks, etc.)",
            Contact = new OpenApiContact { Name = "Aladdin Team", Url = new Uri("https://example.com"), Email = "support@example.com" },
            License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };

        // Define JWT Bearer security scheme
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "JWT Authorization header using the Bearer scheme. Example: 'Authorization: Bearer {token}'"
        };

        // Set a global server entry (informational)
        document.Servers = new List<OpenApiServer>
        {
            new() { Url = "/", Description = "Default" }
        };

        return Task.CompletedTask;
    });

    // Require Bearer security on operations unless explicitly marked AllowAnonymous
    options.AddOperationTransformer((operation, context, cancellationToken) =>
    {
        var hasAllowAnonymous = context.Description?.ActionDescriptor?.EndpointMetadata
            ?.Any(m => m?.GetType().Name == "AllowAnonymousAttribute") == true;

        if (!hasAllowAnonymous)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [ new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } } ] = new List<string>()
            });
        }

        return Task.CompletedTask;
    });

    // Add standard response codes to all operations if not already present
    options.AddOperationTransformer((operation, context, cancellationToken) =>
    {
        operation.Responses ??= new Microsoft.OpenApi.Models.OpenApiResponses();

        void Ensure(string status, string description)
        {
            if (!operation.Responses.ContainsKey(status))
            {
                operation.Responses[status] = new Microsoft.OpenApi.Models.OpenApiResponse
                {
                    Description = description
                };
            }
        }

        Ensure("400", "Bad request");
        Ensure("401", "Unauthorized");
        Ensure("403", "Forbidden");
        Ensure("404", "Not found");
        Ensure("500", "Internal server error");

        return Task.CompletedTask;
    });
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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetWeatherForecastQuery>());

// FluentValidation - scan validators in the Application assembly
builder.Services.AddValidatorsFromAssemblyContaining<GetWeatherForecastQuery>();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
// Restrict API docs in production: enabled by default only in Development.
var openApiEnabled = app.Configuration.GetValue<bool>("OpenApi:Enabled", app.Environment.IsDevelopment());
if (openApiEnabled)
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Aladdin API";
    });
    // Convenience: redirect root to the API docs UI
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
