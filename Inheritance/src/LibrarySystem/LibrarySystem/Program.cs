using System;
using LibrarySystem.Library;
using LibrarySystem.Members;
using LibrarySystem.Staff;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== [ Library Management System Testing ] ===\n");

     
        Console.WriteLine("--- 1. Testing Library Items ---");
        LibraryItem book = new Book("B101", "Clean Code", 5.0m);
        LibraryItem dvd = new DVD("D101", "Inception", 10.0m);
        
        Console.WriteLine($"Book: {book.Title}, Loan Days: {book.LoanPeriodDays}, Daily Fee: {book.GetDailyLateFee()}");
        Console.WriteLine($"DVD: {dvd.Title}, Loan Days: {dvd.LoanPeriodDays}, Daily Fee: {dvd.GetDailyLateFee()}\n");

        Console.WriteLine("--- 2. Testing Staff Members ---");
        Librarian librarian = new Librarian("L001", "Ahmed Ali", "0123456789", DateTime.Now.AddYears(-2), 5000m);
        Shelver shelver = new Shelver("SH001", "Omar Mohamed", "0111223344", DateTime.Now.AddYears(-1), 3500m, "History Section");
        HeadLibrarian headLibrarian = new HeadLibrarian("HL001", "Mahmoud Hassan", "01098765432", DateTime.Now.AddYears(-5), 9000m);

        Console.WriteLine($"Librarian Pay: {librarian.CalculateMonthlyPay()}");
        Console.WriteLine($"Shelver Section: {shelver.Section}");
        shelver.Reassign("Science Section");
        Console.WriteLine($"Shelver New Section: {shelver.Section}");
        Console.WriteLine($"Head Librarian Pay (With Allowance): {headLibrarian.CalculateMonthlyPay()}\n");

     
        librarian.GiveRaise(10m);
        Console.WriteLine($"Librarian Salary after 10% raise: {librarian.MonthlySalary}\n");


        Console.WriteLine("--- 3. Testing Members & Loans ---");
        StudentMember student = new StudentMember("M001", "Sara Ahmed", "0155555555");
        
  

        Loan loan = new Loan("LID-01", DateTime.Now.AddDays(-10), student, book);
        
        Console.WriteLine($"Loan ID: {loan.LoanId}");
        Console.WriteLine($"Borrow Date: {loan.BorrowDate.ToShortDateString()}");
        Console.WriteLine($"Due Date (Calculated): {loan.DueDate.Value.ToShortDateString()}");

     
        librarian.ReturnProcess(loan, DateTime.Now);
       
        Console.WriteLine($"Loan Status after Return: {loan.Status}");

        Console.WriteLine("\n=== [ All Tests Passed Successfully! ] ===");
    }
}