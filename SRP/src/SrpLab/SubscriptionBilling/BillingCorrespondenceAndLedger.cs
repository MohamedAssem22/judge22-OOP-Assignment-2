namespace SrpLab;

public sealed class BillingCorrespondenceAndLedger
{
    public string GenerateDunningEmail(string customerName, DateOnly asOf, decimal proratedAmount, string invoiceNumber, int failedPayments)
    {
        var severity = failedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };
        return $"Subject: {severity} {invoiceNumber}\nHi {customerName},\nBalance {proratedAmount:C} as of {asOf:o} ({failedPayments} failures).\n";
    }

    public string GenerateLedgerLine(string customerId, string invoiceNumber, decimal proratedAmount)
    {
        return $"{customerId},{invoiceNumber},{proratedAmount:0.00},AR-SUB";
    }
}