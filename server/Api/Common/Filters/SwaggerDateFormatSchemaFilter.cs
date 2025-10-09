using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using server.Shared.Utilities;

namespace server.Api.Common.Filters;

public class SwaggerDateFormatSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (DateTimeUtil.IsDateOnlyType(context.Type))
        {
            DateTimeUtil.ConfigureDateOnlySchema(schema);
        }
    }
}
