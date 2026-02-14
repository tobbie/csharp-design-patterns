using RulesEngine.Discounts;

namespace DesignPatterns.Tests.RulesEngineTests;


public class CalculateDiscountPercentage
{
    private DiscountCalculator_Original _discountCalculator = new DiscountCalculator_Original();
    const int DEFAULT_AGE = 30;

    [Fact]
    public void Return0PercentForBasicCustomer()
    {
        //arrange
        var customer = CreateCustomer("Basic Customer", 20, DateTime.Today.AddDays(-1));

        //act
        var result = _discountCalculator.CalculateDiscountPercentage(customer);


        //assert
        Assert.Equal(0m, result);

    }

    [Fact]
    public void Return15PercentForFirstTimeCustomer()
    {
        //arrange
        var customer = CreateCustomer("Basic Customer", 20);

        //act
        var result = _discountCalculator.CalculateDiscountPercentage(customer);


        //assert
        Assert.Equal(.15m, result);

    }

    [Fact]
    public void Return10PercentForVetrans()
    {
        //arrange
        var customer = CreateCustomer("Basic Customer", 50, DateTime.Today.AddYears(-2), true, null);

        //act
        var result = _discountCalculator.CalculateDiscountPercentage(customer);


        //assert
        Assert.Equal(.10m, result);

    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ReturnsVetransDiscountForLoyal1And2YearCustomers(int yearAsCustomer)
    {
        var customer = CreateCustomer("Jean Grey", DEFAULT_AGE, DateTime.Today.AddYears(-yearAsCustomer).AddDays(-1), true, null);

        var result = _discountCalculator.CalculateDiscountPercentage(customer);

        Assert.Equal(.10m, result);
    }

    [Fact]
    public void Returs10PercentForCustomerSecondPurchaseeOnBirthday()
    {
        var customer = CreateBirthdayCustomer("Jean Grey", 20, DateTime.Today.AddDays(-1), false);
        var result = _discountCalculator.CalculateDiscountPercentage(customer);
        Assert.Equal(.10m, result);
    }

    [Theory]
    [InlineData(1, .05)]
    [InlineData(2, .08)]
    [InlineData(5, .10)]
    [InlineData(10, .12)]
    [InlineData(15, .15)]
    public void ReturnsCorrectLoyaltyDiscountForLongTimeCustomer(int yearsAsCustomer, decimal expectedDiscount)
    {
        var customer = CreateCustomer("Sam Amadi",
                          DEFAULT_AGE, DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));
        var result = _discountCalculator.CalculateDiscountPercentage(customer);
        Assert.Equal(expectedDiscount, result);
    }

    [Theory]
    [InlineData(1, .15)]
    [InlineData(2, .18)]
    [InlineData(5, .20)]
    [InlineData(10, .22)]
    [InlineData(15, .25)]
    public void ReturnsCorrectLoyaltyDiscountForLongTimeCustomerOnTheirBirthday(int yearsAsCustomer, decimal expectedDiscount)
    {
        var customer = CreateBirthdayCustomer("Sam Amadi",
                          DEFAULT_AGE, DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));
        var result = _discountCalculator.CalculateDiscountPercentage(customer);
        Assert.Equal(expectedDiscount, result);
    }

    private Customer CreateCustomer(string name, int age = DEFAULT_AGE, DateTime? dateOfFirstPurchase = null, bool isVeteran = false, DateTime? dateOfBirth = null)
    {
        return new Customer(name, dateOfFirstPurchase,
                        dateOfBirth ?? DateTime.Now.AddYears(-DEFAULT_AGE).AddDays(1), isVeteran);
    }

    private Customer CreateBirthdayCustomer(string name, int age = DEFAULT_AGE, DateTime? dateOfFirstPurchase = null, bool isVeteran = false, DateTime? dateOfBirth = null)
    {
        return new Customer(name, dateOfFirstPurchase,
                        dateOfBirth ?? DateTime.Now.AddYears(-age), isVeteran);
    }
}
