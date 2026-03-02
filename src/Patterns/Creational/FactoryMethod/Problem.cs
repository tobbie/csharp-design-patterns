

namespace FactoryMethod;

public class ReportGenerator
{
    public void GenerateReport(string type, string data)
    {
        if (type == "pdf")
        {
            Console.WriteLine("Creating PDF...");
            var pdfReport = new PdfReport();
            // 50 lines of PDF logic
        }
        else if (type == "excel")
        {
            Console.WriteLine("Creating Excel...");
            var excelReport = new ExcelReport();
            // 50 lines of Excel logic
        }
        else if (type == "html")
        {
            Console.WriteLine("Creating HTML...");
            var htmlReport = new HtmlReport();
            // 50 lines of HTML logic
        }
        // Next week: XML reports = modify this class!
    }
}


