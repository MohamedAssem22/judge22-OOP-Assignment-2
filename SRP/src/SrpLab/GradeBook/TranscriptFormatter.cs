namespace SrpLab.GradeBook;

public sealed class TranscriptFormatter
{
    public string FormatTranscript(string studentId, string fullName, decimal avg, string letter, bool honor)
    {
        return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {avg}\nLetter: {letter}\nHonor: {honor}\n";
    }

    public string FormatCsv(IDictionary<string, List<decimal>> scores, Func<string, decimal> avgCalculator, Func<string, string> letterProvider, Func<string, bool> honorChecker)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var id in scores.Keys.OrderBy(x => x))
        {
            var avg = avgCalculator(id);
            var letter = letterProvider(id);
            var honor = honorChecker(id);
            rows.Add($"{id},{avg},{letter},{(honor ? 1 : 0)}");
        }
        return string.Join('\n', rows);
    }
}