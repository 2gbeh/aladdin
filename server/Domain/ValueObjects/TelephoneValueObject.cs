namespace server.Domain.ValueObjects;

public sealed record TelephoneValueObject
{
    public string CountryCode { get; }
    public string Number { get; }

    private TelephoneValueObject()
    {
        CountryCode = "+234";
        Number = string.Empty;
    }

    private TelephoneValueObject(string countryCode, string number)
    {
        CountryCode = countryCode;
        Number = number;
    }

    public static TelephoneValueObject Create(string countryCode = "+234", string number = "")
    {
        return new TelephoneValueObject(countryCode, number);
    }

    public override string ToString()
    {
        return $"{CountryCode}{Number}";
    }
}