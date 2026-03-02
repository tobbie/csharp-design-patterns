using FactoryMethod;
using static System.Console;


namespace ConsoleClient.Examples
{
    static class FactoryMethodDemo
    {


        public static void Run()
        {

            Title = "Factory Method";

            var reportFactory = GetReportFactory();

            var report = reportFactory.CreateReport();

            report.Generate();
            report.GetFormat();
            report.Save("C:\\reports\\report1");
            WriteLine();
        }

        private static ReportFactory GetReportFactory()
        {
            var reportType = GetUserChoice();
            if (reportType == "exit")
            {
                Environment.Exit(0);
            }


            return reportType switch
            {
                "pdf" => new PdfReportFactory(),
                "excel" => new ExcelReportFactory(),
                "html" => new HtmlReportFactory(),
                _ => throw new ArgumentException("unknown format")
            };
        }

        private static string GetUserChoice()
        {
            WriteLine("Please Choose a report type:");
            WriteLine("1. PDF");
            WriteLine("2. Excel");
            WriteLine("3. Html");
            WriteLine();
            var option = ReadLine();
            return option switch
            {
                "1" => "pdf",
                "2" => "excel",
                "3" => "html",
                "q" => "exit",
                _ => throw new InvalidOperationException("Invalid option")
            };

        }
    }
}
