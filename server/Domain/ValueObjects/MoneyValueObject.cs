namespace server.Domain.ValueObjects;

public sealed record MoneyValueObject
{
    public decimal Value { get; }
    public string Currency { get; }

    private MoneyValueObject()
    {
        Value = 0m;
        Currency = "NGN";
    }

    private MoneyValueObject(decimal value, string currency = "NGN")
    {
        Value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        Currency = currency.ToUpperInvariant();
    }

    public static MoneyValueObject Create(decimal value = 0m, string currency = "NGN")
    {
        return new MoneyValueObject(value, currency);
    }

    public override string ToString()
    {
        return Value.ToString("N2");
    }
}