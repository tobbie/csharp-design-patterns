using Adapter;
using static System.Console;

Title = "Adapter Pattern";

ICityAdapter adapter   =  new CityAdapter();
var city = adapter.GetCity();

WriteLine($"{city.FullName}, {city.Inhabitants}");

ReadKey();





