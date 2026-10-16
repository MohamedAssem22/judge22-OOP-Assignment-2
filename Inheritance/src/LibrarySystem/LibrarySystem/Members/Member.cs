using LibrarySystem.Library;

namespace LibrarySystem.Members;

public class Member : Person
{
    private List<Loan> _loans;
    public int MaxLoans { get; }
    public int DiscountPrecent { get; }
    // public int ActiveLoansCount => _loans.Count; OH shhhhit 
    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly(); 
    protected Member(string personId, string fullName, string phone, int maxLoans, decimal discountPercentage) : base(personId , fullName , phone)
    {
        CheckNegative(maxLoans , "max loans cannot be negative"); 
        CheckNegative(discountPercentage , "discount precentage cannot be negative");
        this.MaxLoans = maxLoans; 
        this.MaxLoans = maxLoans;
    }
    public int ActiveLoanCount()
    {
        return _loans.Count; 
    }

    public Loan BorrowItem(LibraryItem item, string loanId, DateTime borrowDate)
    {
     
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Library item cannot be null.");
 
        if (item.IsWithdrawn)
            throw new InvalidOperationException("Cannot borrow an item that has been withdrawn from the library.");

        if (item.IsLoan)
            throw new InvalidOperationException("Item is already on loan.");

     
        if (ActiveLoanCount() >= MaxLoans)
            throw new InvalidOperationException("Member has reached the maximum number of allowed loans.");


        Loan newLoan = new Loan(loanId, borrowDate, this, item);

   
        _loans.Add(newLoan);
        
        return newLoan;
    }
    private void CheckNegative(decimal value, string message)
    {
        if(value < 0)
            throw new ArgumentException(message);
    }
    
    
}