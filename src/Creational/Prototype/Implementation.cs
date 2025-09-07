namespace Prototype;

/**
*****Prototype Pattern Components******
 * 1. Prototype - can be an interface or an abstract class
 * 2. ConcretePrototypeA - implements the abstract Prototype
 * 3. ConcretePrototypeB -  implements the abstract Prototype
 * 4. Client - uses the prototype to create a clone
**/


/// Prototype
public abstract class Person
{
    public abstract string Name { get; set; }
    public abstract Person Clone();
}

/// <summary>
/// Concrete Prototype 1
/// </summary>
public class Manager : Person
{
    public override string Name { get;set }

    public Manager(string name)
    {
        Name = name;    
    }
    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

/// <summary>
/// Concrete Prototype 2
/// </summary>
public class Employee : Person
{
    public override string Name { get; set; }
    public Manager Manager { get; set; }

    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }
    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

