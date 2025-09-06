using static System.Console;
using ClassAdapter;

namespace ConsoleClient.Examples
{
    public static class AdapterDemo
    {
        public static void Run()
        {
            Title = "Adapter Pattern";

            ICityAdapter adapter = new CityAdapter();
            var city = adapter.GetCity();

            WriteLine($"{city.FullName}, {city.Inhabitants}");

            ReadKey();
        }
    }
}
