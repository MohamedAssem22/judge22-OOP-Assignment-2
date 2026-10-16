namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

    private readonly StockAllocator _allocator = new();
    private readonly WarehousePathOptimizer _pathOptimizer = new();
    private readonly PickerInstructionAndWmsFormatter _formatter = new();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        return _allocator.Allocate(_lines);
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        return _pathOptimizer.CalculateWalkingOrder(_lines);
    }

    public string PickerScript()
    {
        return _formatter.BuildPickerScript(WalkingOrder(), Allocate(), _lines);
    }

    public string WmsXmlBatch(string batchId)
    {
        return _formatter.BuildWmsXmlBatch(batchId, Allocate());
    }
}