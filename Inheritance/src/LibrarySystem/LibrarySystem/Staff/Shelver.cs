namespace LibrarySystem.Staff;
using System;

public class Shelver : Staff
{
    
    public string Section { get; private set; }

    public Shelver(string id, string name, string phone, DateTime hireDate, decimal salary, string section) 
        : base(id, name, phone, hireDate, salary, 0m)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentException("Section cannot be null or empty.", nameof(section));

        Section = section;
    }
    
    public void Reassign(string newSection)
    {
        if (string.IsNullOrWhiteSpace(newSection))
            throw new ArgumentException("New section cannot be null or empty.", nameof(newSection));

        Section = newSection;
    }
}