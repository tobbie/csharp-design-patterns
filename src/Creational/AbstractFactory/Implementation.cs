using static System.Console;

namespace AbstractFactory;

/**
 **** Abstract Factory Components****
 *
 * 1. AbstractProductA, AbstractProductB (interfaces), the family of releted abstract products
 * 2. ConcreteProductA, ConcreteProductB (concrete classes that implement the abstract products)
 
 * 3. AbstractFactory (interface or abstract class that exposes definitions for creating the abstract family of products)
 * 4. Concrete Factory (concrete class that  implements the abstract factory by creating the concrete products, but will return their abstract versions)
 * 5. A Client that uses the AbstractFactory to create the abstract family of products it needs.
 * 

**/


// Abstract Factory
public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();
    IShippingCostsService CreateShippingCostsService();
}

/// <summary>
/// Abstract Product
/// </summary>
public interface IDiscountService
{
    int DiscountPercentage { get; }
}

/// <summary>
/// Concrete Product
/// </summary>
public class BelgiumDiscountService : IDiscountService
{
    public int DiscountPercentage => 20;
}

/// <summary>
/// Concrete Product
/// </summary>
public class FranceDiscountService : IDiscountService
{
    public int DiscountPercentage => 10;
}


/// <summary>
///  Abstract Product 
/// </summary>
public interface IShippingCostsService
{
    decimal? ShippingCosts { get; }
}

/// <summary>
/// Concrete Product
/// </summary>
public class BelgiumShippingCostsService : IShippingCostsService
{
    public decimal? ShippingCosts => 20;
}


/// <summary>
/// Concrete Product
/// </summary>
class FranceShippingCostsService : IShippingCostsService
{
    public decimal? ShippingCosts => 25;
}

/// <summary>
/// Concrete Factory for Belgium Family
/// </summary>
public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
      return new BelgiumDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new BelgiumShippingCostsService();
    }
}

/// <summary>
/// Concrete Factory for France Family
/// </summary>
public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new FranceDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new FranceShippingCostsService();
    }
}

/// <summary>
/// Client class
/// </summary>

public class ShoppingCart
{
    private readonly IDiscountService _discountService;
    private readonly IShippingCostsService _shippingCostsService;
    private int _orderCosts;

    public ShoppingCart(IShoppingCartPurchaseFactory factory)
    {
          _discountService  = factory.CreateDiscountService();
          _shippingCostsService = factory.CreateShippingCostsService();
        _orderCosts = 200;
    }

    public void CalculateCosts()
    {
        WriteLine($"Total costs =  {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage)
            + _shippingCostsService.ShippingCosts}");
    }
}

