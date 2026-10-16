namespace LibrarySystem.Library;

public class Magazine : LibraryItem
{
    Magazine(string catalogNumber, string title, decimal baseFee) : base(catalogNumber, title, 3, baseFee, 0.5m)
    {
        
    }
}