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

    private Customer CreateCustomer(string name, int age = DEFAULT_AGE, DateTime? dateOfFirstPurchase = null, bool isVeteran = false, DateTime? dateOfBirth = null)
    {
        return new Customer(name, dateOfFirstPurchase,
                        dateOfBirth ?? DateTime.Now.AddYears(-DEFAULT_AGE).AddDays(1), isVeteran);
    }
}
