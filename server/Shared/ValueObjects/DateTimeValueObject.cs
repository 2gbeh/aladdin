namespace server.Shared.ValueObjects;

public sealed record class DateTimeValueObject
{
    public DateTime Value { get; }

    // For EF Core
    private DateTimeValueObject()
    {
        Value = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }

    private DateTimeValueObject(DateTime utc)
    {
        // Ensure stored value is strictly UTC
        Value = utc.Kind == DateTimeKind.Utc ? utc : utc.ToUniversalTime();
    }

    public static DateTimeValueObject Create(DateTime value)
    {
        // Accept any kind, normalize to UTC
        var utc = value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
        return new DateTimeValueObject(utc);
    }

    public static DateTimeValueObject FromUnixSeconds(long seconds)
    {
        var utc = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
        return new DateTimeValueObject(utc);
    }

    public long ToUnixSeconds() => new DateTimeOffset(Value).ToUnixTimeSeconds();

    public override string ToString() => Value.ToString("O"); // ISO 8601

    public static implicit operator DateTime(DateTimeValueObject dt) => dt.Value;
}