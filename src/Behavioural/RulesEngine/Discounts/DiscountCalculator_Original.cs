

namespace RulesEngine.Discounts;

public class DiscountCalculator_Original
{
    public decimal CalculateDiscountPercentage(Customer customer)
    {
        if (!customer.DateOfFirstPurchase.HasValue)
        {
            return .15m;
        }
        else
        {
            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
            {
                return .15m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
            {
                return .12m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
            {
                return .10m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) && !customer.IsVetran)
            {
                return .08m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) && !customer.IsVetran)
            {
                return .05m;
            }

        }

        if (customer.IsVetran)
        {
            return .10m;
        }

        if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
        {
            return .05m;
        }

        return 0m;
    }
}
