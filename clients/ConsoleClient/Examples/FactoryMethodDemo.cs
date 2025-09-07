using FactoryMethod;
using static System.Console;


namespace ConsoleClient.Examples
{
    static class FactoryMethodDemo
    {
        public static void Run()
        {
            Title = "Factory Method";

            var factories = new List<DiscountFactory>();
            factories.Add(new CodeDiscountFactory(Guid.NewGuid()));
            factories.Add(new CountryDiscountFactory("BE"));

            //loop through the factory to create the diffent products (CountryDiscountService and CodeDiscountService)
            foreach (var factory in factories)
            {
                var discountService = factory.CreateDiscountService();
                Console.WriteLine($"Percentage {discountService.DiscountPercentage} " + $" coming from {discountService}");
            }

            Console.ReadKey();
        }
    }
}
