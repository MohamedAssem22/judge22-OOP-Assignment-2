namespace SrpLab.KitchenTicket;

public sealed class CookTimeEstimator
{
    public int EstimateMinutes(IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items, int openStations, bool hasAllergens)
    {
        if (openStations <= 0) openStations = 1;
        var sequential = items.Sum(i => i.PrepMinutes);
        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        if (hasAllergens) parallel += 3;
        var longest = items.Count == 0 ? 0 : items.Max(i => i.PrepMinutes);
        return Math.Max(parallel, longest);
    }

    public string DetermineExpoLane(bool hasAllergens, int estimatedMinutes)
    {
        if (hasAllergens) return "LANE-ALLERGY";
        return estimatedMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
    }
}