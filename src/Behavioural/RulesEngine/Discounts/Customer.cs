
namespace RulesEngine.Discounts;

public class Customer
{
    public Customer(string name, DateTime? dateOfFirstPurchase, DateTime? dateOfBirth, bool isVetran)
    {
        FullName = name;
        DateOfFirstPurchase = dateOfFirstPurchase;
        DateOfBirth = dateOfBirth;
        IsVetran = isVetran;
    }

    public string FullName { get; private set; }
    public DateTime? DateOfFirstPurchase { get; private set; }
    public DateTime? DateOfBirth { get; private set; }
    public bool IsVetran { get; private set; }
}
