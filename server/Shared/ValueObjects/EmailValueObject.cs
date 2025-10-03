using System.Text.RegularExpressions;

namespace server.Shared.ValueObjects;

public sealed record class EmailValueObject
{
    public string Value { get; }

    // For EF Core
    private EmailValueObject() { Value = string.Empty; }

    private EmailValueObject(string value)
    {
        Value = value;
    }

    public static EmailValueObject Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty", nameof(value));

        // Simple RFC 5322-ish email validation
        var pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
            throw new ArgumentException("Invalid email format", nameof(value));

        return new EmailValueObject(value.Trim());
    }

    public override string ToString() => Value;

    public static implicit operator string(EmailValueObject email) => email.Value;
}