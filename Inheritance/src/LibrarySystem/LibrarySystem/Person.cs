namespace LibrarySystem;

public class Person
{
    protected string PersonId { get; }
    public string FullName { get;  }
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        ValidateString(phone , "phone cannot be empty or null");
        ValidateString(personId , "person id cannot be empty or null");
        ValidateString(fullName , "full name cannot be empty or null");
        this.PersonId = personId;
        this.FullName = fullName;
        this.Phone = phone; 
    }
          
    private void ValidateString(string check , string message)
    {
        bool isOk = (string.IsNullOrEmpty(check) || string.IsNullOrWhiteSpace(check));
        if (isOk) 
            throw new ArgumentException(message);
        // Console.Write("all is okay");
    } 
}