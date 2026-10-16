namespace SrpLab.LoanManager;

public sealed class LoanCorrespondence
{
    public string GenerateDecisionLetter(string applicantName, decimal requestedAmount, decimal riskScore, bool isEligible, IEnumerable<string> requiredDocs)
    {
        if (isEligible)
        {
            return $"Dear {applicantName},\nYour request for {requestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                   $"Please upload: {string.Join("; ", requiredDocs)}.\n";
        }

        return $"Dear {applicantName},\nWe are unable to approve {requestedAmount:C} at this time.\n" +
               $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
    }

    public string GenerateCsvRow(string applicationId, int creditScore, int employmentMonths, bool hasCollateral, decimal riskScore, bool isEligible)
    {
        return $"{applicationId},{creditScore},{employmentMonths},{(hasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
    }
}