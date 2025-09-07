using System.Text;

namespace Builder;

/**
*****Builder Pattern Components******
 * 1. Builder - can be an interface or abstract class
 * 2. ConcreteBuilderA
 * 3. ConcreteBuilderB
 * 4. Product (e.g car)
 * 5. Director --- uses abstract builder to construct car representations
**/

/**
 *** use cases*****
 * 1. Generating Documents
 * 2. Building Database queries
 * 3. Creating Game Characters
 * 4. Constructing a UI or form
**/

/**
 * Related Patterns  Abstract factory, Singleton, Composite
**/
/// <summary>
/// Product - Object created by builder
/// </summary>

public class Car
{
    private readonly string _carType;
    private readonly List<string> _parts = new();
    public Car(string carType)
    {
        _carType = carType;
    }

    public void AddPart(string part)
    {
        _parts.Add(part);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (string part in _parts)
        {
            sb.Append($" Car of type {_carType} has part {part}.  ");
        }

        return sb.ToString();
    }
}


/// <summary>
/// Builder
/// </summary>
public abstract class CarBuilder
{
    public abstract void BuildEngine();
    public abstract void BuildFrame();

    public Car Car { get; private set; }

    public CarBuilder(string carType)
    {
        Car = new Car(carType);
    }
}


/// <summary>
/// ConcreteBuilderA
/// </summary>
public class MiniBuilder : CarBuilder
{
    public MiniBuilder() : base("Mini")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("'not a V8'");
    }

    public override void BuildFrame()
    {
        Car.AddPart("'3-door with stripes'");
    }
}


/// <summary>
/// ConcreteBuilderB
/// </summary>
public class BMWBuilder : CarBuilder
{
    public BMWBuilder() : base("BMW")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("'a fancy V8 engine'");
    }

    public override void BuildFrame()
    {
        Car.AddPart("'5-door with metallic finish'");
    }
}

/// <summary>
/// Director - uses abstract builder class to build the required car representation
/// abstract builder class can be introduced by construction injection or via a construct method
/// </summary>
public class Garage
{
    private CarBuilder? _builder;
    public Garage() { }

    public void Construct(CarBuilder builder)
    {
        _builder = builder;
        _builder.BuildEngine();
        _builder.BuildFrame();
    }


    public void Show()
    {
        Console.WriteLine(_builder?.Car.ToString());
    }
}





