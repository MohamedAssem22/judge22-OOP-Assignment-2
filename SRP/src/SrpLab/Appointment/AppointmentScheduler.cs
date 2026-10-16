namespace SrpLab.Appointment;

public sealed class AppointmentScheduler
{
    private readonly HashSet<DateTimeOffset> _booked = new();
    private readonly OperatingHoursPolicy _policy;

    public AppointmentScheduler(OperatingHoursPolicy policy)
    {
        _policy = policy;
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        var cursor = Align(from);
        var end = from.AddHours(searchHours);
        while (cursor < end)
        {
            if (_policy.IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                return cursor;
            cursor = cursor.AddMinutes(_policy.SlotMinutes);
        }
        return null;
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!_policy.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
        _booked.Add(slot);
        return true;
    }

    private DateTimeOffset Align(DateTimeOffset from)
    {
        var slotMinutes = _policy.SlotMinutes;
        var minutes = from.Minute - (from.Minute % slotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}