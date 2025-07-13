using static  System.Console;
using Strategy;

namespace ConsoleClient.Examples
{
    static class StrategyDemo
    {
        public static void Run() 
        {
            Title = "The Strategy Pattern";
            var order = new Order("Oluwatobi Software", "Visual Studio License", 200);
            order.ExportService = new CsvExportService();
            order.Export();

            order.ExportService = new JsonExportService();
            order.Export();

            order.ExportService = new XmlExportService();
            order.Export();

            ReadKey();  






        }

    }
}
