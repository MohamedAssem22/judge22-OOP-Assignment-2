namespace SrpLab;

public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    private readonly AcuityScorer _acuityScorer = new();
    private readonly WardPagerService _pagerService = new();
    private readonly HandoffAndCensusFormatter _formatter = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        var acuity = ScoreAcuity(heartRate, spo2);
        _vitalsScore[bed] = acuity;

        _pagerService.CheckAndTriggerAlert(bed, acuity);
    }

    public int ScoreAcuity(int heartRate, int spo2)
    {
        return _acuityScorer.ScoreAcuity(heartRate, spo2);
    }

    public string BuildHandoffNote(int bed)
    {
        _bedPatient.TryGetValue(bed, out var patient);
        _vitalsScore.TryGetValue(bed, out var acuity);
        return _formatter.BuildHandoffNote(bed, patient, acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerService.DrainPagerLog();
    }

    public string ExportCensusCsv()
    {
        return _formatter.FormatCensusCsv(_bedPatient, _vitalsScore);
    }
}