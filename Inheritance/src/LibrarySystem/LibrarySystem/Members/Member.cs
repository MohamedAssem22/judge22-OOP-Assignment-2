using LibrarySystem.Library;

namespace LibrarySystem.Members;

public class Member : Person
{
    private List<Loan> loans;
    public int MaxLoans { get; }
    public int DiscountPrecent { get; }
    public IReadOnlyList<Loan> Loans => loans.AsReadOnly(); 
    protected Member(string personId, string fullName, string phone, int maxLoans, decimal discountPercentage) : base(personId , fullName , phone)
    {
        this.MaxLoans = maxLoans;
    }

    public int ActiveLoanCount()
    {
        return loans.Count; 
    }

    public Loan BorrowItem(LibraryItem item, string loanId, DateTime borrowDate)
    {
        return null; 
    }
    
    
}