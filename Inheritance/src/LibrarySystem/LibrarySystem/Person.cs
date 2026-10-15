namespace LibrarySystem;

public class Person
{
    protected string PersonId { get; }
    public string FullName { get;  }
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        this.PersonId = personId;
        this.FullName = fullName;
        this.Phone = phone; 
    }
          
}