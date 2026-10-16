namespace SrpLab;

public sealed class SlaCalculator
{
    public DateTimeOffset CalculateDeadline(DateTimeOffset openedAt, string priority)
    {
        var hours = priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };
        return openedAt.AddHours(hours);
    }

    public bool IsBreached(DateTimeOffset deadline, DateTimeOffset now)
    {
        return now > deadline;
    }
}