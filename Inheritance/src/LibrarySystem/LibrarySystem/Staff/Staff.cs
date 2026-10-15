namespace LibrarySystem.Staff;

public class Staff
{
    protected decimal allowance; 
    public DateTime HireDate { get; }
    public decimal MonthlySalary { get; private set; }

    protected Staff(string id, string name, string phone, DateTime hireDate, decimal salary, decimal allowance)
    {
        Validate(name , "name cannot be null or empty");
        Validate(id , "id cannot be null or empty");
        Validate(phone , "phone cannot be null or empty");
        CheckNegativeOrZero(salary , "salary cannot be zero or negative");
        CheckNegativeOrZero(allowance , "allowance cannot be zero or negative");
        if (hireDate == null) throw new ArgumentException("hire date cannot be null");
    }

    public void GiveRaise(decimal precent)
    {
        CheckNegativeOrZero(precent , "precent cannot be zero or negative");
        decimal riaseAmount =  MonthlySalary * (precent / 100m);
        MonthlySalary += riaseAmount; 
    }

    public virtual decimal CalculateMonthlyPay()
    {
        return MonthlySalary + allowance; 
    }
    private void Validate(string check , string message)
    {
        bool isOk = (string.IsNullOrEmpty(check) || string.IsNullOrWhiteSpace(check)) || check == null;
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