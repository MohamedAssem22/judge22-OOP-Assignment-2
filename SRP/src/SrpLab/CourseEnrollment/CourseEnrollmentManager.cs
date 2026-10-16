namespace SrpLab;

public sealed class CourseEnrollmentManager
{
    private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<string> _waitlist = new();
    
    private readonly WelcomePacketFormatter _welcomeFormatter = new();
    private readonly TuitionInvoiceFormatter _invoiceFormatter = new();

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentManager(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
    }

    public string Register(string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
        var email = studentEmail.Trim();

        if (_seated.Contains(email) || _waitlist.Contains(email))
            return "ALREADY_REGISTERED";

        if (_seated.Count < Capacity)
        {
            _seated.Add(email);
            return "SEATED";
        }

        _waitlist.Add(email);
        return $"WAITLIST:{_waitlist.Count}";
    }

    public int WaitlistPosition(string studentEmail)
    {
        var idx = _waitlist.FindIndex(x => x.Equals(studentEmail, StringComparison.OrdinalIgnoreCase));
        return idx < 0 ? -1 : idx + 1;
    }

    public string WelcomePacketMarkdown(string studentEmail, string studentName)
    {
        var status = _seated.Contains(studentEmail) ? "confirmed seat" : $"waitlist #{WaitlistPosition(studentEmail)}";
        return _welcomeFormatter.GenerateWelcomePacket(CourseCode, studentName, status);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        var isSeated = _seated.Contains(studentEmail);
        return _invoiceFormatter.GenerateInvoiceLine(CourseCode, Tuition, isSeated);
    }

    public void PromoteFromWaitlist(int seats)
    {
        while (seats > 0 && _waitlist.Count > 0 && _seated.Count < Capacity)
        {
            var next = _waitlist[0];
            _waitlist.RemoveAt(0);
            _seated.Add(next);
            seats--;
        }
    }
}