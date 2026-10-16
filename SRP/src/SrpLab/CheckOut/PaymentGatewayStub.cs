namespace SrpLab;

public sealed class PaymentGatewayStub
{
    public string AuthorizePayment(decimal grandTotal, int itemCount, string cardLast4)
    {
        var payload = $"{grandTotal:0.00}|{cardLast4}|{itemCount}";
        var hash = payload.GetHashCode();
        return $"AUTH-{Math.Abs(hash):X8}";
    }
}