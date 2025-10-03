namespace server.Shared.ValueObjects;

public sealed record class AddressValueObject
{
    public string Line1 { get; }
    public string? Line2 { get; }
    public string City { get; }
    public string? State { get; }
    public string? PostalCode { get; }
    public string Country { get; }

    // For EF Core
    private AddressValueObject()
    {
        Line1 = City = Country = string.Empty;
    }

    private AddressValueObject(string line1, string? line2, string city, string? state, string? postalCode, string country)
    {
        Line1 = line1;
        Line2 = line2;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public static AddressValueObject Create(
        string line1,
        string? line2,
        string city,
        string? state,
        string? postalCode,
        string country)
    {
        if (string.IsNullOrWhiteSpace(line1)) throw new ArgumentException("Line1 is required", nameof(line1));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required", nameof(city));
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country is required", nameof(country));

        line1 = line1.Trim();
        line2 = string.IsNullOrWhiteSpace(line2) ? null : line2.Trim();
        city = city.Trim();
        state = string.IsNullOrWhiteSpace(state) ? null : state.Trim();
        postalCode = string.IsNullOrWhiteSpace(postalCode) ? null : postalCode.Trim();
        country = country.Trim();

        return new AddressValueObject(line1, line2, city, state, postalCode, country);
    }

    public override string ToString()
    {
        var parts = new List<string> { Line1 };
        if (!string.IsNullOrWhiteSpace(Line2)) parts.Add(Line2!);
        parts.Add(City);
        if (!string.IsNullOrWhiteSpace(State)) parts.Add(State!);
        if (!string.IsNullOrWhiteSpace(PostalCode)) parts.Add(PostalCode!);
        parts.Add(Country);
        return string.Join(", ", parts);
    }
}