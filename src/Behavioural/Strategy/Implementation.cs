using static System.Console;

namespace Strategy;

/**
 ****** STRATEGY COMPONENTS *****
 1. Strategy - Interface that defines algorithm method defination that will be implemented
 2. ConcreteStrategyA, ConcreteStrategyB...and so on (for example - CSVExportService, JSONExportService, XMLExportService)
 3. Context - Class recieves which strategy to use from the client code.  
     (for example and Order object that needs to be exported into various formats)
**/


/// -- The Strategy
public interface IExportService
{
    void Export(Order order);
}

public class CsvExportService : IExportService
{
    public void Export(Order order)
    {
        WriteLine($"Exporting {order.Name} to CSV.");
    }
}

public class JsonExportService : IExportService
{
    public void Export(Order order)
    {
        WriteLine($"Exporting {order.Name} to Json.");
    }
}

public class XmlExportService : IExportService
{
    public void Export(Order order)
    {
        WriteLine($"Exporting {order.Name} XML.");
    }
}


/// <summary>
/// Context
/// </summary>
public class Order
{
    public Order(string name, string customer, decimal amount)
    {
        Name = name;
        Customer = customer;
        Amount = amount;
    }

    public string Name { get; private set; }
    public string Customer { get; private set; }
    public string? Description { get; private set; }
    public decimal Amount { get; private set; }

    public IExportService?  ExportService { get; set; }

    public void Export()
    {
        ExportService?.Export(this);
    }
}