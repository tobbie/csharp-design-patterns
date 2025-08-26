using Bridge;
using static System.Console;


namespace ConsoleClient.Examples
{
    internal static class BridgeDemo
    {
        public static void Run()
        {
            Title = "Bridge Pattern";

            var noCoupon = new NoCoupon();
            var oneEuroCoupon = new OneEuroCoupon();
            var twoEuroCoupon  = new TwoEuroCoupon();

            var meatBasedMenu = new MeatBasedMenu(noCoupon);
            WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

            WriteLine();

            meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
            WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euro.");

            WriteLine();

            var vegetarianMenu = new VegetarianMenu(noCoupon);
            WriteLine($"Vegetarian  menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

            WriteLine();

            vegetarianMenu = new VegetarianMenu(twoEuroCoupon);
            WriteLine($"Vegetarian  menu, two euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

            Console.ReadKey();
        }
    }
}
