using static System.Console;
using AbstractFactory;

namespace ConsoleClient.Examples
{
    static class AbstractFactoryDemo
    {
        public static void Run()
        {
            Title = "Abstract Factory Demo";

            var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
            var shoppingCartForBelgium  = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
            shoppingCartForBelgium.CalculateCosts();

            var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
            var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
            shoppingCartForFrance.CalculateCosts();

            ReadKey();

        }
    }
}
