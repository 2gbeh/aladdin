using System.Reflection;
using Microsoft.OpenApi.Models;
using server.Api.Common.Filters;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring Swagger/OpenAPI documentation
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Adds Swagger/OpenAPI documentation services
    /// </summary>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
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

            // Add date format filters for DateOnly types
            options.SchemaFilter<SwaggerDateFormatSchemaFilter>();
            options.OperationFilter<SwaggerDateFormatOperationFilter>();
        });

        return services;
    }

    /// <summary>
    /// Configures Swagger/OpenAPI middleware in the HTTP request pipeline
    /// </summary>
    public static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        // Restrict API docs in production: enabled by default only in Development.
        var openApiEnabled = app.Configuration.GetValue<bool>("OpenApi:Enabled", app.Environment.IsDevelopment());
        if (openApiEnabled)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aladdin API v1");
                options.RoutePrefix = "swagger";
            });
        }

        return app;
    }
}
