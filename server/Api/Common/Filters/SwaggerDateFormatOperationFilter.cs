using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using server.Shared.Utilities;

namespace server.Api.Common.Filters;

public class SwaggerDateFormatOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var parameter in operation.Parameters ?? Enumerable.Empty<OpenApiParameter>())
        {
            var parameterInfo = context.ApiDescription.ParameterDescriptions
                .FirstOrDefault(p => p.Name == parameter.Name);

            if (DateTimeUtil.IsDateOnlyType(parameterInfo?.Type))
            {
                DateTimeUtil.ConfigureDateOnlySchema(parameter.Schema);
                parameter.Description ??= "Ex. YYYY-MM-DD";
            }
        }
    }
}
