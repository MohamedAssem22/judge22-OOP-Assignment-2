namespace LibrarySystem.Library;
using Members;

public class LibraryItem
{
    public string CataLogNumber { get; }
    public string Title { get; }
    public int LoanPeriodDays { get; }
    protected decimal LateFeeFactor { get; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsLoan { get; private set; }

    protected LibraryItem(string catalogNumber, string title, int loanDays, decimal baseFee , decimal lateFeeFactor)
    {
        ValidateString(catalogNumber , "Catalog Number can not null or empty");
        ValidateString(title , "title can not null or empty");
        CheckNegativeOrZero(loanDays , "Loan Period Days can not be zero or negative");
        CheckNegativeOrZero(baseFee , "Base Fee can not be zero or negative");
        CheckNegativeOrZero(lateFeeFactor , "Late Fee Factor can not be zero or negative");
        this.CataLogNumber = catalogNumber;
        this.Title = title;
        this.LoanPeriodDays = loanDays;
        this.LateFeeFactor = lateFeeFactor; 

    }

   

    public virtual decimal GetDailyLateFee()
    {
        return LateFeeFactor * BaseLateFee; 
    }

    public void SetBaseLateFee(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException("BaseLateFee can not be zero or negative"); 
        BaseLateFee = value; 
    }

    public void WithDraw()
    {
        IsWithdrawn = true; 
    }

    public void Restore()
    {
        IsWithdrawn = false; 
    }
    private void ValidateString(string check , string message)
    {
        bool isOk = (string.IsNullOrEmpty(check) || string.IsNullOrWhiteSpace(check));
        if (isOk) 
            throw new ArgumentException(message);
        // Console.Write("all is okay");
    }

    private void CheckNegativeOrZero(decimal value, string message)
    {
        if(value <= 0)
            throw new ArgumentException(message);
    }
}