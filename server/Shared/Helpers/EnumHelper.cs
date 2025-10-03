using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace server.Shared.Helpers;

public static class EnumHelper
{
    public static string GetLabel(this Enum e)
    {
        return e.GetType()
              .GetMember(e.ToString())[0]
              .GetCustomAttribute<DisplayAttribute>()?
              .Name ?? e.ToString();
    }
}

