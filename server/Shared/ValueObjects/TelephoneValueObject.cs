using System.Text.RegularExpressions;

namespace server.Shared.ValueObjects;

public sealed record class TelephoneValueObject
{
    // Stored as Nigerian E.164 format: +234XXXXXXXXXX (10 digits after +234)
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

        // Normalize: remove spaces, non‑breaking spaces, hyphens, parentheses
        var normalized = Regex.Replace(input, "[\u0020\u00A0\-()]", string.Empty);

        // Accept common Nigerian forms and normalize to +234XXXXXXXXXX
        // 1) Local mobile format: 0XXXXXXXXXX (11 digits starting with 0)
        if (Regex.IsMatch(normalized, "^0\d{10}$"))
        {
            normalized = "+234" + normalized.Substring(1);
        }
        // 2) International without plus: 234XXXXXXXXXX
        else if (Regex.IsMatch(normalized, "^234\d{10}$"))
        {
            normalized = "+" + normalized;
        }
        // 3) Already E.164: +234XXXXXXXXXX (validate later)
        else if (Regex.IsMatch(normalized, "^\+234\d{10}$"))
        {
            // ok as-is
        }
        else
        {
            throw new ArgumentException("Telephone must be a valid Nigerian number (e.g., 08031234567 or +2348031234567)", nameof(input));
        }

        // Final validation: +234 followed by 10 digits
        if (!Regex.IsMatch(normalized, "^\+234\d{10}$"))
            throw new ArgumentException("Telephone must be in Nigerian E.164 format: +234XXXXXXXXXX", nameof(input));

        return new TelephoneValueObject(normalized);
    }

    public override string ToString() => E164;

    public static implicit operator string(TelephoneValueObject phone) => phone.E164;
}