namespace SrpLab.GradeBook;

public sealed class GradingPolicy
{
    public string GetLetter(decimal avg)
    {
        if (avg >= 90) return "A";
        if (avg >= 80) return "B";
        if (avg >= 70) return "C";
        if (avg >= 60) return "D";
        return "F";
    }

    public bool MeetsHonorRoll(decimal avg, string letter)
    {
        return avg >= 85 && letter is "A" or "B";
    }
}