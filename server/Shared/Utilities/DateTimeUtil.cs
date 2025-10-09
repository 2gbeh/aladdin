using Microsoft.OpenApi.Models;

namespace server.Shared.Utilities;

public static class DateTimeUtil
{
    public static void ConfigureDateOnlySchema(OpenApiSchema schema)
    {
        schema.Type = "string";
        schema.Format = "date";
        schema.Default = null;
        schema.Example = new Microsoft.OpenApi.Any.OpenApiString("");
    }

    public static bool IsDateOnlyType(Type? type) =>
        type == typeof(DateOnly) || type == typeof(DateOnly?);
        
    public static int GetDaysLeftInWeek()
    {
        var today = DateTime.Now.DayOfWeek;
        var daysUntilEndOfWeek = DayOfWeek.Saturday - today;
        return daysUntilEndOfWeek == 0 ? 1 : daysUntilEndOfWeek + 1;
    }
}
