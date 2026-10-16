namespace PatternsLab.Problems.Builder;

public class CourseRegistrationBuilder
{
    
    private string _studentEmail = null;
    private string _courseCode = null;
    private string _accessMode = null;
    private string? _groupCode = null;
    private string? _discountCode = null;
    private bool _sendWhatsApp = false; 
    private bool _sendEmailWelcome = false;
    private string? _mentorNote = null;
    public DateOnly? _preferredStart = null;

    public CourseRegistrationBuilder(string studentEmail, string courseCode)
    {
        _studentEmail = studentEmail;
        _courseCode = courseCode; 
    }

    public CourseRegistrationBuilder AsLiveGroup(string groupCode)
    {
        _groupCode = groupCode;
        _accessMode = "LiveGroup"; 
        return this; 
    }

    public CourseRegistrationBuilder AsVideosOnly()
    {
        _accessMode = "VideosOnly";
        return this; 
    }

    public CourseRegistrationBuilder WithDiscount(string discountCode)
    {
        _discountCode = discountCode;
        return this; 
    }

    public CourseRegistrationBuilder WithWhatsAppNotifications(bool send)
    {
        _sendWhatsApp = send;
        return this; 
    }
    public CourseRegistrationBuilder WithWelcomeEmail(bool send)
    {
        _sendEmailWelcome = send;
        return this; 
    }
    public CourseRegistrationBuilder WithMentorNote(string note)
    {
        _mentorNote = note;
        return this;
    }
    public CourseRegistrationBuilder WithPreferredStart(DateOnly date)
    {
        _preferredStart = date;
        return this;
    }
    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(_courseCode)) throw new ArgumentException("course required");

        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");
        
        return new CourseRegistration(
      
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart
        ); 
    }

}