using static System.Console;
using Facade;

namespace ConsoleClient.Examples
{
   static class FacadeDemo
    {
        public static void Run()
        {
            Title = "Facade Pattern";

            var facade = new DiscountFacade();
            WriteLine($"Discount percentage for customer with id 1:{facade.CalculateDiscountPercentage(6)}");
            WriteLine($"Discount percentage for customer with id 10:{facade.CalculateDiscountPercentage(11)}");

            ReadKey();

        }
    }
}
