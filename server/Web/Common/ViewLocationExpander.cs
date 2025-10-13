using Microsoft.AspNetCore.Mvc.Razor;

namespace server.Web.Common;

public class CommonViewLocationExpander : IViewLocationExpander
{
    private static readonly string[] _commonLocations = GetCommonViewLocations();

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        return _commonLocations.Concat(viewLocations);
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
        // No additional values needed
    }

    private static string[] GetCommonViewLocations()
    {
        var commonPath = Path.Combine(Directory.GetCurrentDirectory(), "Web", "Common");
        var locations = new List<string>();

        if (Directory.Exists(commonPath))
        {
            // Get all subdirectories in Common
            var subdirectories = Directory.GetDirectories(commonPath, "*", SearchOption.AllDirectories);
            
            // Add the Common root directory
            locations.Add("/Web/Common/{0}.cshtml");
            
            // Add each subdirectory as a potential location
            foreach (var dir in subdirectories)
            {
                var relativePath = Path.GetRelativePath(commonPath, dir).Replace('\\', '/');
                locations.Add($"/Web/Common/{relativePath}/{{0}}.cshtml");
            }
        }

        return locations.ToArray();
    }
}
