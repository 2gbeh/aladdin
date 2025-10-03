using System.Text.RegularExpressions;

namespace server.Shared.ValueObjects;

public sealed record class TelephoneValueObject
{
    // Stored in E.164 format (e.g., +15551234567)
    public string E164 { get; }

    // For EF Core
    private TelephoneValueObject() { E164 = string.Empty; }

    private TelephoneValueObject(string e164)
    {
        E164 = e164;
    }

    public static TelephoneValueObject Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Telephone cannot be empty", nameof(input));

        // Normalize: remove spaces, hyphens, parentheses
        var normalized = Regex.Replace(input, "[\u0020\u00A0\-()]", string.Empty);

        // Add leading + if missing and looks like digits with country code already present
        if (!normalized.StartsWith('+') && Regex.IsMatch(normalized, "^\\d{7,15}$"))
        {
            normalized = "+" + normalized;
        }

        // Validate E.164: + followed by 7 to 15 digits
        if (!Regex.IsMatch(normalized, "^\\+[1-9]\\d{6,14}$"))
            throw new ArgumentException("Telephone must be in E.164 format (e.g., +15551234567)", nameof(input));

        return new TelephoneValueObject(normalized);
    }

    public override string ToString() => E164;

    public static implicit operator string(TelephoneValueObject phone) => phone.E164;
}