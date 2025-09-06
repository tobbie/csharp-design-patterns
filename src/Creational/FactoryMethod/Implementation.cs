namespace FactoryMethod;

/**
 * Factory Components
 * Phase 1
 * 1. Product --- Abstract class or interface of the objects to be created
 * 2. ConcreteProductA
 * 3. ConcreteProductB
 * 
 * Phase 2
 * 1. Creator  ---- Abstract class with factory method for creating products
 * 2. ConcreteCreatorA ----- class that implements Creator factory method to create ConcreteProductA
 * 3. ConcreateCreatorB ------class that implements Creator factory method to create ConcreteProductB
 * 
**/


    
// Product
public abstract class DiscountService
{
    public abstract int DiscountPercentage { get; }
    public override string ToString() => GetType().Name;
   
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CountryDiscountService : DiscountService
{
    private readonly string _countryIdentifier;

    public CountryDiscountService(string countryIdentifier)
    {
        _countryIdentifier = countryIdentifier;
    }

    public override int DiscountPercentage
    {
        get
        {
            switch (_countryIdentifier) {

                //if you're from Belgium, you get a better discount 
                case "BE":
                    return 20;
                default:
                    return 10;
            }
        }
    }
}


/// <summary>
/// ConcreteProductB
/// </summary>
public class CodeDiscountService : DiscountService
{
    private readonly Guid _code;

    public CodeDiscountService(Guid code)
    {
        _code = code;
    }

    public override int DiscountPercentage
    {
        //each code returns the same fixed percentage, but a code is only valid once
        // inlclude a check so whether the code's been used before.
        get => 15;
    }
}

/// <summary>
/// Creator - Abstract factory class
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcreteCreatorA - A ConcreteFactory
/// </summary>
public class CountryDiscountFactory : DiscountFactory
{
    private readonly string _countryIdentifier;

    public CountryDiscountFactory(string countryIdentifier)
    {
        _countryIdentifier = countryIdentifier;
    }

    public override DiscountService CreateDiscountService()
    {
        return new CountryDiscountService(_countryIdentifier);
    }
}


/// <summary>
/// ConcreteCreatorB - A ConcreteFactory
/// </summary>
public class CodeDiscountFactory : DiscountFactory
{
    private readonly Guid _code;

    public CodeDiscountFactory(Guid code)
    {
        _code= code;
    }

    public override DiscountService CreateDiscountService()
    {
        return new CodeDiscountService(_code);
    }
}


