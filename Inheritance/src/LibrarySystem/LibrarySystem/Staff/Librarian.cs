namespace LibrarySystem.Staff;
using Library;
public class Librarian : Staff
{
    public Librarian(string id, string name, string phone, DateTime hireDate, decimal salary) : base(id , name , phone , hireDate  , salary, 0)
    {
            
    }

    public void ReturnProcess(Loan loan, DateTime returnDate)
    {
        if (loan == null)
            throw new ArgumentNullException("loan cannot be null"); 
     

        loan.MarkAsReturned(returnDate);
        if (returnDate > loan.DueDate)
        {
            TimeSpan? totalLateDays = (returnDate - loan.DueDate);
            decimal dailyFee = loan.Item.GetDailyLateFee();
            decimal totalLateFee = totalLateDays.Value.Days * dailyFee; 
        }
    }

    public void MarkLoas(Loan loan)
    {
        loan.MarkAsLost(LoanStatus.Lost);
    }
}