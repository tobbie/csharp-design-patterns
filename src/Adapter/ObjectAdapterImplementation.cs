namespace Adapter;

/**
 *** ADAPTER COMPONENTS ****
 * 1.Adaptee - External System that's being adapted
 * 2. Target  - Interface the client will use
 * 3. Adapter - Concrete class that implements the target
 * 4. Client  -- That uses the traget to get the model it needs in the form it can use
 * 
 * *****Models*************************
 * 1. Model (class/object) from external system.
 * 2. Model (class/objet) we convert the model above to. Our final adapted object.
 * 
**/


/// <summary>
///  object model from external system
/// </summary>
public class CityFromExternalSystem
{
    public CityFromExternalSystem(string name, string nickName, int inhabitaants)
    {
        Name = name;
        NickName = nickName;
        Inhabitaants = inhabitaants;
    }
    public string Name { get; private set; }

    public string NickName { get; private set; }

    public int Inhabitaants { get; private set; }
}

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystem
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("Lagos", "Eko", 20000000);
    }
}


/// <summary>
/// object model to adpat external model to
/// </summary>
public class City
{
    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }

    public string FullName { get; private set; }
    public long Inhabitants { get; private set; } 
}

/// <summary>
/// Target
/// </summary>
public interface ICityAdapter
{
    City GetCity();
}

public class CityAdapter : ICityAdapter
{
    public ExternalSystem ExternalSystem { get; private set; } = new();
    public City GetCity()
    {
        var cityFromExternalSystem  = ExternalSystem.GetCity();
        return new City($"{cityFromExternalSystem.Name}  {cityFromExternalSystem.NickName}",
                             cityFromExternalSystem.Inhabitaants);
    }
}

