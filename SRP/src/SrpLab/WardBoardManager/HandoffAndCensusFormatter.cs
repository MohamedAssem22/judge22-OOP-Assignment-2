namespace SrpLab;

public sealed class HandoffAndCensusFormatter
{
    public string BuildHandoffNote(int bed, string? patient, int acuityScore)
    {
        if (string.IsNullOrEmpty(patient))
            return $"Bed {bed}: empty";

        var tone = acuityScore >= 8 ? "ESCALATE" : acuityScore >= 4 ? "WATCH" : "STABLE";
        return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patient} · acuity={acuityScore} · {tone}";
    }

    public string FormatCensusCsv(IDictionary<int, string> bedPatients, IDictionary<int, int> vitalsScores)
    {
        var lines = new List<string> { "bed,patient,acuity" };
        foreach (var bed in bedPatients.Keys.OrderBy(x => x))
        {
            lines.Add($"{bed},{bedPatients[bed]},{vitalsScores[bed]}");
        }
        return string.Join('\n', lines);
    }
}