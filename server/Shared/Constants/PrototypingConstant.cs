namespace server.Shared.Constants;

public record Prototype
{
    public bool Loader { get; set; }
    public bool Portal { get; set; }
    public bool FormData { get; set; }
    public bool Action { get; set; }
}

public static class Prototyping
{
    public static readonly Prototype Auth = new() { 
        Loader = false, 
        Portal = false, 
        FormData = true, 
        Action = false 
    };
}

