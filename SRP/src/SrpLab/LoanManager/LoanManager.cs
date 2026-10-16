namespace SrpLab.LoanManager;

public sealed class LoanManager
{
    private readonly RiskUnderwritingEngine _riskEngine = new();
    private readonly LoanDocumentChecklist _docChecklist = new();
    private readonly LoanCorrespondence _correspondence = new();

    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanManager(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskEngine.CalculateRiskScore(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public bool IsEligible() 
    {
        return _riskEngine.CheckEligibility(RiskScore(), CreditScore);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _docChecklist.GetRequiredDocuments(RequestedAmount, HasCollateral, EmploymentMonths, IsEligible());
    }

    public string DecisionLetter(string applicantName)
    {
        return _correspondence.GenerateDecisionLetter(applicantName, RequestedAmount, RiskScore(), IsEligible(), RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _correspondence.GenerateCsvRow(applicationId, CreditScore, EmploymentMonths, HasCollateral, RiskScore(), IsEligible());
    }
}