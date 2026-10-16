namespace SrpLab.GradeBook;

public sealed class GradeBook
{
    private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);
    private readonly GradingPolicy _gradingPolicy = new();
    private readonly TranscriptFormatter _transcriptFormatter = new();

    public void Record(string studentId, decimal score)
    {
        if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
        if (!_scores.TryGetValue(studentId, out var list))
        {
            list = new List<decimal>();
            _scores[studentId] = list;
        }
        list.Add(score);
    }

    public decimal Average(string studentId)
    {
        if (!_scores.TryGetValue(studentId, out var list) || list.Count == 0) return 0m;
        return Math.Round(list.Average(), 2);
    }

    public string Letter(string studentId)
    {
        var avg = Average(studentId);
        return _gradingPolicy.GetLetter(avg);
    }

    public bool MeetsHonorRoll(string studentId)
    {
        var avg = Average(studentId);
        var letter = Letter(studentId);
        return _gradingPolicy.MeetsHonorRoll(avg, letter);
    }

    public string TranscriptPlain(string studentId, string fullName)
    {
        var avg = Average(studentId);
        var letter = Letter(studentId);
        var honor = MeetsHonorRoll(studentId);
        return _transcriptFormatter.FormatTranscript(studentId, fullName, avg, letter, honor);
    }

    public string ExportCsv()
    {
        return _transcriptFormatter.FormatCsv(
            _scores, 
            Average, 
            Letter, 
            MeetsHonorRoll
        );
    }
}