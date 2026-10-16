namespace SrpLab;

public sealed class InvoiceGenerator
{
    private static int _invoiceSeq = 1000;

    public string MintNextInvoiceNumber(DateOnly periodStart)
    {
        var n = ++_invoiceSeq;
        return $"INV-{periodStart:yyyyMM}-{n:D5}";
    }
}