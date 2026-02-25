/** 
 * 1. Rules Collection
 * 2. Rules Engine - accepts a collection of rules in it's constructor
 * 3. System input or context or state - the data that rules will be applied to
 * 4. Apply ruels to giv system context or state
 **/
namespace RulesEngine.Discounts;

public interface IDiscountRule
{
    decimal CalculateDiscount(Customer customer, decimal currentDiscount);
}

public class FirstTimeCustomerRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (!customer.DateOfFirstPurchase.HasValue)
        {
            return .15m;
        }
        return 0;
    }


}

public class LoyalCustomerRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {


        if (!customer.DateOfFirstPurchase.HasValue)
            return 0m;

        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
        {
            if (customer.IsBirthDay) return .25m;
            return .15m;
        }

        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
        {
            if (customer.IsBirthDay) return .22m;
            return .12m;
        }

        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
        {
            if (customer.IsBirthDay) return .20m;
            return .10m;
        }

        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) && !customer.IsVetran)
        {
            if (customer.IsBirthDay) return .18m;
            return .08m;
        }

        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) && !customer.IsVetran)
        {
            if (customer.IsBirthDay) return .15m;
            return .05m;
        }

        return 0m;
    }
}

public class SeniorRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
        {
            if (customer.IsBirthDay) return .15m;
            return 0.05m;
        }

        return 0;
    }
}

public class VetranRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (customer.IsVetran)
        {
            if (customer.IsBirthDay) return .20m;
            return .10m;
        }

        return 0m;
    }
}

public class BirthdayRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
    {
        if (customer.IsBirthDay)
            //return currentDiscount + 0.10m;
            return 0.10m;

        return currentDiscount;
    }
}

public class DiscountCalculator
{
    public decimal CalculateDiscountPercentage(Customer customer) // customer is system input or context
    {

        var rules = new List<IDiscountRule>();
        rules.Add(new FirstTimeCustomerRule());
        rules.Add(new LoyalCustomerRule());
        rules.Add(new VetranRule());
        rules.Add(new SeniorRule());
        rules.Add(new BirthdayRule());


        var engine = new DiscountRuleEngine(rules);
        return engine.CalculateDiscountPercentage(customer);
    }
}

public class DiscountRuleEngine
{
    private List<IDiscountRule> _rules = new List<IDiscountRule>();
    public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
    {
        _rules.AddRange(rules);
    }

    public decimal CalculateDiscountPercentage(Customer customer)
    {
        decimal discount = 0m;
        foreach (var rule in _rules)
        {
            discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
        }

        return discount;
    }

}
