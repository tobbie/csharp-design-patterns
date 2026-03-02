using System.Data;
using static System.Console;

namespace Bridge;



/**
 **** BRIDGE COMPONENTS****
 * 1. Abstraction (abstract class or interface eg Menu)
 * 2. RefinedAbstraction1, RefinedAbstraction2... etc - ( ConcreteAbstractions e.g MeatBasedMenu, VegetarianBasedMenu)
 
 * 3. Implementor (interface or abstract class eg ICoupon)
 * 4. ConcreteImplementor1, ConcreteImplementor2 ....etc (eg OneEuroCoupon, TwoEuroCoupon)
 * 5  Link to UML --> 
**/

// Abstraction
public abstract class Menu
{
    public readonly ICoupon _coupon = null!;
    public abstract int CalculatePrice();

    public Menu(ICoupon coupon)
    {
        _coupon = coupon;
    }
}


public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    { 
    }
    public override int CalculatePrice()
    {
        return 20 - _coupon.CouponValue;
    }
}

public class MeatBasedMenu : Menu
{
    public MeatBasedMenu(ICoupon coupon) : base(coupon)
    {
    }
    public override int CalculatePrice()
    {
        return 30 - _coupon.CouponValue;
    }
}


/// <summary>
/// Implementor
/// </summary>
public interface ICoupon
{
    int CouponValue { get;}
}


/// <summary>
/// Concrete Implementor
/// </summary>
public class NoCoupon : ICoupon
{
    public int CouponValue { get => 0; }
}

/// <summary>
/// Concrete Implementor
/// </summary>
public class OneEuroCoupon : ICoupon
{
    public int CouponValue { get => 1; }
}

/// <summary>
/// Concrete Implementor
/// </summary>
public class TwoEuroCoupon : ICoupon
{
    public int CouponValue { get => 2; }
}