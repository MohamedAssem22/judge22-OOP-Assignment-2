namespace LibrarySystem.Library;

public class DVD : LibraryItem
{
    public DVD(string catalogNumber, string title, decimal baseFee) : base(catalogNumber, title, 7, baseFee, 2.0m)
    {
        
    }
}