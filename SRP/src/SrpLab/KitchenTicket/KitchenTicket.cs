namespace SrpLab.KitchenTicket;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();
    
    private readonly AllergenScanner _allergenScanner = new();
    private readonly CookTimeEstimator _cookTimeEstimator = new();
    private readonly ThermalTicketPrinter _ticketPrinter = new();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenScanner.DetectAllergens(_items.Select(i => i.Ingredients));
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        var hasAllergens = DetectAllergens().Count > 0;
        return _cookTimeEstimator.EstimateMinutes(_items, openStations, hasAllergens);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        var eta = EstimatedReadyMinutes(2);
        var allergens = DetectAllergens();
        return _ticketPrinter.Render(orderNumber, eta, _items, allergens);
    }

    public string ExpoLaneHint()
    {
        var hasAllergens = DetectAllergens().Count > 0;
        var eta = EstimatedReadyMinutes(2);
        return _cookTimeEstimator.DetermineExpoLane(hasAllergens, eta);
    }
}