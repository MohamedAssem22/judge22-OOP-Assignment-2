namespace LibrarySystem.Library;

public class Book : LibraryItem
{
    public Book(string catalogNumber, string title, decimal baseFee) : base(catalogNumber , title  , 21 ,baseFee , 1.0m )
    {
        
    }
}