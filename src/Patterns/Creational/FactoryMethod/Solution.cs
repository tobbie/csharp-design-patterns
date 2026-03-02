namespace FactoryMethod;

/**
 * Factory Components
 * Phase 1
 * 1. Product --- Abstract class or interface of the objects to be created
 * 2. ConcreteProductA
 * 3. ConcreteProductB
 * 
 * Phase 2
 * 1. Creator  ---- Abstract class with factory method for creating products
 * 2. ConcreteCreatorA ----- class that implements Creator factory method to create ConcreteProductA
 * 3. ConcreateCreatorB ------class that implements Creator factory method to create ConcreteProductB
 * 
**/

//Product
public interface IReport
{
    void Generate();
    void Save(string location);
    string GetFormat();
}

//ConcreteProductA
public class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Creating PDF with tables...");
        // PDF-specific PDF logic here
    }

    public void Save(string location)
    {
        Console.WriteLine($"Saving to {location}.pdf");
    }

    public string GetFormat() => "PDF";
}

//ConcreteProductB
public class ExcelReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Creating Excel with formulas...");
        // Excel-specific logic here
    }

    public void Save(string location)
    {
        Console.WriteLine($"Saving to {location}.xlsx");
    }

    public string GetFormat() => "Excel";
}

public class HtmlReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Creating HTML report...");
        // Excel-specific logic here
    }

    public void Save(string location)
    {
        Console.WriteLine($"Saving to {location}.html");
    }

    public string GetFormat() => "Html";
}



// Creator
public abstract class ReportFactory
{
    public abstract IReport CreateReport();
}

//ConcreteCreatorA
public class PdfReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new PdfReport();
    }
}

//ConcreteCreatorB
public class ExcelReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new ExcelReport();
    }
}

public class HtmlReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new HtmlReport();
    }
}


public class GenericReportFactory : ReportFactory
{
    private readonly string _reportType;
    public GenericReportFactory(string reportType)
    {
        _reportType = reportType;
    }
    public override IReport CreateReport()
    {
        return _reportType switch
        {
            "pdf" => new PdfReport(),
            "excel" => new ExcelReport(),
            "html" => new HtmlReport(),
            _ => throw new ArgumentException("Unknown report type")
        };
    }
}

