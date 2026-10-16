namespace LibrarySystem.Library;
using Members;
public enum LoanStatus
{
    Borrowed,
    Returned,
    Lost
}
public class Loan
{
    public string LoanId { get; }
    public DateTime BorrowDate { get; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public LoanStatus Status { get; private set; }
    public DateTime ReturnedDate { get; private set; }
    // public DateTime? DueDate => BorrowDate.AddDays(Item.LoanPeriodDays); this give me error i replace it with next line 
    public DateTime? DueDate => BorrowDate.AddDays(Item?.LoanPeriodDays ?? 0);
    public decimal LateFee => 0;

    internal Loan(string loanId, DateTime borrowDate, Member member, LibraryItem item)
    {
        if (string.IsNullOrEmpty(loanId) || string.IsNullOrWhiteSpace(loanId))
            throw new ArgumentNullException("loanId cannot be null or empty"); 
        if(member == null) 
            throw new ArgumentNullException("member cannot be null or empty"); 
        if(item == null) 
            throw new ArgumentNullException("item cannot be null or empty"); 
        if(borrowDate == null) 
            throw new ArgumentNullException("borrow date cannot be null or empty"); 

    }

    internal void MarkAsReturned(DateTime returnedDate)
    {
        this.ReturnedDate = returnedDate;
        Status = LoanStatus.Returned; 
    }

    internal void MarkAsLost(LoanStatus status)
    {
        Status = LoanStatus.Lost; 
    }
}