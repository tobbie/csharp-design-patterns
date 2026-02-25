

namespace RulesEngine.Discounts;

public class DiscountCalculator_Original
{
    public decimal CalculateDiscountPercentage(Customer customer) // customer is system input or context
    {
        bool isBirthday = customer.DateOfBirth.HasValue &&
            customer.DateOfBirth.Value.Month == DateTime.Now.Month &&
            customer.DateOfBirth.Value.Day == DateTime.Now.Day;

        decimal discount = 0m;


        if (!customer.DateOfFirstPurchase.HasValue)
        {
            discount = .15m;
        }
        else
        {
            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
            {
                if (isBirthday) return .25m;
                return .15m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
            {
                if (isBirthday) return .22m;
                return .12m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
            {
                if (isBirthday) return .20m;
                return .10m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) && !customer.IsVetran)
            {
                if (isBirthday) return .18m;
                return .08m;
            }

            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) && !customer.IsVetran)
            {
                if (isBirthday) return .15m;
                return .05m;
            }

        }

        if (customer.IsVetran)
        {
            if (isBirthday) return .20m;
            return .10m;
        }

        if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
        {
            if (isBirthday) return .15m;
            return Math.Max(discount, .05m);
        }

        if (isBirthday) return .10m;

        return discount;
    }
}
