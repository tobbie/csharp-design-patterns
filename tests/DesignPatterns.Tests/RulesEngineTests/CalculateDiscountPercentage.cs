using RulesEngine.Discounts;

namespace DesignPatterns.Tests.RulesEngineTests;


public class CalculateDiscountPercentage
{
    private DiscountCalculator _discountCalculator = new DiscountCalculator();
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

    [Fact]
    public void Elderly_NotBirthday_Returns_5Percent()
    {
        // Arrange
        var calculator = new DiscountCalculator_Original();
        // older than 65 but not same month/day as today
        var dateOfBirth = DateTime.Now.AddYears(-66).AddDays(1);
        var dateOfFirstPurchase = DateTime.Now;
        var customer = new Customer("Elder Not Birthday", dateOfFirstPurchase, dateOfBirth, isVetran: false);

        // Act
        var discount = calculator.CalculateDiscountPercentage(customer);

        // Assert
        Assert.Equal(0.05m, discount);
    }

    [Fact]
    public void Elderly_OnBirthday_Returns_15Percent()
    {
        // Arrange
        var calculator = new DiscountCalculator_Original();
        var dateOfBirth = DateTime.Now.AddYears(-66); // older than 65 and same month/day => birthday
        var dateOfFirstPurchase = DateTime.Now; // recent to avoid earlier branches
        var customer = new Customer("Elder Birthday", dateOfFirstPurchase, dateOfBirth, isVetran: false);

        // Act
        var discount = calculator.CalculateDiscountPercentage(customer);

        // Assert
        Assert.Equal(0.15m, discount);
    }

    [Fact]
    public void Return10PercentOnCustomerBirthday()
    {
        var customer = CreateBirthdayCustomer("Sam Amadi",
                         DEFAULT_AGE, DateTime.Today);
        var result = _discountCalculator.CalculateDiscountPercentage(customer);

        Assert.Equal(.10m, result);

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
