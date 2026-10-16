
namespace LibrarySystem.Staff;
using Library;
using System;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(string id, string name, string phone, DateTime hireDate, decimal salary) 
        : base(id, name, phone, hireDate, salary, 400m)
    {
    }

    public void SetLateFee(LibraryItem item, decimal newFee)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        item.SetBaseLateFee(newFee);
    }

    public void Withdraw(LibraryItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        item.WithDraw(); 
    }


    public void Restore(LibraryItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        item.Restore(); 
    }
}