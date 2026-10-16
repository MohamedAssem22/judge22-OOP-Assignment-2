
namespace SrpLab;

public sealed class SubscriptionBilling
{
    private readonly SubscriptionProrationCalculator _prorationCalculator = new();
    private readonly InvoiceGenerator _invoiceGenerator = new();
    private readonly BillingCorrespondenceAndLedger _correspondenceAndLedger = new();

    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }

    public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom)
    {
        return _prorationCalculator.CalculateProrate(MonthlyPrice, PeriodStart, PeriodEnd, activeFrom);
    }

    public string NextInvoiceNumber()
    {
        return _invoiceGenerator.MintNextInvoiceNumber(PeriodStart);
    }

    public void RegisterFailedPayment() => FailedPayments++;

    public string DunningEmail(string customerName, DateOnly asOf)
    {
        var amount = Prorate(PeriodStart);
        var invoice = NextInvoiceNumber(); 
        return _correspondenceAndLedger.GenerateDunningEmail(customerName, asOf, amount, invoice, FailedPayments);
    }

    public string LedgerJournalLine(DateOnly activeFrom)
    {
        return _correspondenceAndLedger.GenerateLedgerLine(CustomerId, NextInvoiceNumber(), Prorate(activeFrom));
    }
}