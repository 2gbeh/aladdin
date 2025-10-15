namespace server.Domain.ValueObjects;

public sealed class FileValueObject : IEquatable<FileValueObject>
{
    public string Name { get; private init; } = string.Empty;
    public string Url { get; private init; } = string.Empty;
    public long Size { get; private init; }
    public string Type { get; private init; } = string.Empty;

    private FileValueObject() { }

    public FileValueObject(string name, string url, long size, string type, FileValueObjectOptions options)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("File name is required", nameof(name));

        if (name.Length > 255)
            throw new ArgumentException("File name too long", nameof(name));

        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("File URL is required", nameof(url));

        if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            throw new ArgumentException("Invalid file URL", nameof(url));

        if (size <= 0)
            throw new ArgumentException("File size must be greater than zero", nameof(size));

        if (size > options.MaxSizeInBytes)
            throw new ArgumentException($"File size exceeds {options.MaxSizeInBytes / (1024 * 1024)} MB", nameof(size));

        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("File type is required", nameof(type));

        if (!options.AllowedTypes.Contains(type))
            throw new ArgumentException($"Unsupported file type '{type}'", nameof(type));

        Name = name;
        Url = url;
        Size = size;
        Type = type;
    }

    public bool Equals(FileValueObject? other)
    {
        if (other is null) return false;
        return Name == other.Name &&
               Url == other.Url &&
               Size == other.Size &&
               Type == other.Type;
    }

    public override bool Equals(object? obj) => Equals(obj as FileValueObject);

    public override int GetHashCode() => HashCode.Combine(Name, Url, Size, Type);
}
