namespace SrpLab;

public sealed class SupportTicket
{
    private readonly TicketPriorityAnalyzer _priorityAnalyzer = new();
    private readonly SlaCalculator _slaCalculator = new();
    private readonly TicketCorrespondenceFormatter _formatter = new();

    public string Id { get; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; } = "P3";

    public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;
        RecalculatePriorityFromText();
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
    {
        Priority = _priorityAnalyzer.DeterminePriority(Subject, Body);
    }

    public DateTimeOffset SlaDeadline()
    {
        return _slaCalculator.CalculateDeadline(OpenedAt, Priority);
    }

    public bool IsBreached(DateTimeOffset now)
    {
        return _slaCalculator.IsBreached(SlaDeadline(), now);
    }

    public string DraftPublicReply(string agentName)
    {
        return _formatter.FormatPublicReply(Id, agentName, Priority, SlaDeadline());
    }

    public string InternalEscalationBlurb()
    {
        return _formatter.FormatInternalEscalation(Id, Priority, SlaDeadline());
    }
}