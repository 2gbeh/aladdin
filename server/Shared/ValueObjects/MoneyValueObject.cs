using System.Globalization;
using System.Text.RegularExpressions;

namespace server.Shared.ValueObjects;

public sealed record class MoneyValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    // For EF Core
    private MoneyValueObject()
    {
        Amount = 0m;
        Currency = "USD";
    }

    private MoneyValueObject(decimal amount, string currency)
    {
        Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        Currency = currency;
    }

    public static MoneyValueObject Create(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required", nameof(currency));

        currency = currency.Trim().ToUpperInvariant();
        if (!Regex.IsMatch(currency, "^[A-Z]{3}$"))
            throw new ArgumentException("Currency must be a 3-letter ISO code (e.g., USD)", nameof(currency));

        return new MoneyValueObject(amount, currency);
    }

    public MoneyValueObject Add(MoneyValueObject other)
    {
        EnsureSameCurrency(other);
        return new MoneyValueObject(Amount + other.Amount, Currency);
    }

    public MoneyValueObject Subtract(MoneyValueObject other)
    {
        EnsureSameCurrency(other);
        return new MoneyValueObject(Amount - other.Amount, Currency);
    }

    public MoneyValueObject Multiply(decimal factor) => new(Amount * factor, Currency);

    public override string ToString() => string.Create(CultureInfo.InvariantCulture, $"{Currency} {Amount:N2}");

    private void EnsureSameCurrency(MoneyValueObject other)
    {
        if (!string.Equals(Currency, other.Currency, StringComparison.Ordinal))
            throw new InvalidOperationException("Currency mismatch");
    }
}