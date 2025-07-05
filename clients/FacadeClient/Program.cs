using Facade;
using static System.Console;

Title = "Facade Pattern";

var facade = new DiscountFacade();
WriteLine($"Discount percentage for customer with id 1:{facade.CalculateDiscountPercentage(6)}");
WriteLine($"Discount percentage for customer with id 10:{facade.CalculateDiscountPercentage(11)}");

ReadKey();
