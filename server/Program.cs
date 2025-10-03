using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using server.Api.Common.Conventions;
using server.Api.Common.Routing;
using server.Application.Common.Behaviors;
using server.Application.WeatherForecasts.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

// MediatR Pipeline Behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
