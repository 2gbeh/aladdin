using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace server.Api.Common.Transformers;

public sealed class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;
        var input = value.ToString();
        if (string.IsNullOrWhiteSpace(input)) return input;

        // Insert hyphen between lowercase-to-uppercase boundaries: "WeatherForecast" -> "Weather-Forecast"
        var withHyphens = Regex.Replace(input!, "(?<!^)([A-Z][a-z]|[0-9]+)", "-$1");

        // Replace spaces/underscores with hyphens and lowercase
        var slug = Regex.Replace(withHyphens, "[ _]+", "-").ToLowerInvariant();
        return slug;
    }
}
