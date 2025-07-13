using static  System.Console;
using Strategy;
using System.Net.Http.Headers;

namespace ConsoleClient.Examples;

static class StrategyDemo
{
    public static void Run()
    {
        Title = "The Strategy Pattern";
        var order = new Order("Oluwatobi Software", "Visual Studio License", 200);
       
        order.Export(new CsvExportService());

        
        order.Export(new JsonExportService());

       
        order.Export(new XmlExportService());

        ReadKey();

    }
}
