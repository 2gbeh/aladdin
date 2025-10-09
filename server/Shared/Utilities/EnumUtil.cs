using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace server.Shared.Utilities;

public static class EnumUtil
{
    public static string GetLabel(this Enum e)
    {
        return e.GetType()
              .GetMember(e.ToString())[0]
              .GetCustomAttribute<DisplayAttribute>()?
              .Name ?? e.ToString();
    }
}

