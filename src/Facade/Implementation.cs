namespace Facade;

/**
 **** Facade Components ****
 * 1. Subsystem classes
 * 2. Facade Interface
 * 
 ** Subsystem Classes ***
 * 1. OrderService
 * 2. CustomerDiscountBaseService
 * 3. DayOfTheWeekFactorService
 * 
**/




// Subsystm class 1

public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        //does the customer have enough orders
        return (customerId > 5);
    }
}

/// <summary>
/// Subsystem class 2
/// </summary>
public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        //demo calculation
        return (customerId > 8) ? 10 : 20;
    }
}

/// <summary>
/// Subsystem class 3
/// </summary>
public class DayOfTheWeekFactorService
{
    public double CalculateDayOfTheWeekFactor()
    {
        //demo calculation
        switch (DateTime.UtcNow.DayOfWeek)
        {
            case DayOfWeek.Sunday:
            case DayOfWeek.Saturday:
                return 0.8;
            default:
                return 1.2;
        }
    }
}

public class DiscountFacade
{
    //We could inject these objects via constructor injection with an IOC, since we don't have that,
    //we are manually instantiating them

    private readonly OrderService _orderService = new();
    private readonly CustomerDiscountBaseService _customerDiscountBaseService= new();
    private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

    public double CalculateDiscountPercentage(int customerId)
    {
        if(!_orderService.HasEnoughOrders(customerId))
            return 0;

        return _customerDiscountBaseService.CalculateDiscountBase(customerId)
                  *_dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
    }
}
