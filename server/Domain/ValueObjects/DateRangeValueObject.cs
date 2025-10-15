namespace server.Domain.ValueObjects;

public sealed record class DateRangeValueObject
{
    public DateOnly Start { get; }
    public DateOnly End { get; }

    // For EF Core
    private DateRangeValueObject()
    {
        Start = End = DateOnly.FromDateTime(DateTime.UtcNow.Date);
    }

    private DateRangeValueObject(DateOnly start, DateOnly end)
    {
        if (start > end)
            throw new ArgumentException("Start date must be <= end date");

        Start = start;
        End = end;
    }

    public static DateRangeValueObject Create(DateOnly start, DateOnly end) => new(start, end);

    public int DurationDays => End.DayNumber - Start.DayNumber + 1; // inclusive

    public bool Contains(DateOnly date) => date >= Start && date <= End;

    public bool Overlaps(DateRangeValueObject other) => Start <= other.End && other.Start <= End;

    public DateRangeValueObject ExpandToInclude(DateOnly date)
    {
        var newStart = date < Start ? date : Start;
        var newEnd = date > End ? date : End;
        return new DateRangeValueObject(newStart, newEnd);
    }

    public override string ToString() => $"{Start:yyyy-MM-dd}..{End:yyyy-MM-dd}";
}