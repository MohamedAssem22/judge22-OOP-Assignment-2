namespace LibrarySystem.Members;

public class PremiumMember : Member
{
    public int? ReadingPoints => null;

    public PremiumMember(string id, string name, string phone, decimal discountPrecentage) : base(id, name, phone,
        10, discountPrecentage)
    {
        
    }
}