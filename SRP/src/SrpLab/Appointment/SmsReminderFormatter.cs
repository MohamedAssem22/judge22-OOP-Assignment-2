namespace SrpLab;

public sealed class SmsReminderFormatter
{
    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}