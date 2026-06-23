using System.ComponentModel.Design;
using static System.Console;

namespace Observer;


/**
 ****OBSERVER COMPONENTS****
 * 1. Observer
 * 2. Subject
 * 
 * 3. ConcreteObserverA, ConcreteObserverB, etc
 * 4. ConcreteSubject
**/




/// -- Object that will be recieved by the observer, it's the object whose state we're intrested in
public class TicketChange
{
    public decimal Amount { get; private set; }
    public int ArtistId { get; private set; }

    public TicketChange(decimal amount, int artistId)
    {
            Amount = amount;
            ArtistId = artistId;
    }
}

/// <summary>
/// Observer
/// </summary>
public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
}


/// <summary>
/// Subject
/// </summary>
public abstract class TicketChangeNotifier
{
    private List<ITicketChangeListener> _observers = new();

   public void AddObserver(ITicketChangeListener observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ITicketChangeListener observer) 
    { 
        _observers.Remove(observer);
    }

    public void Notify(TicketChange ticketChange)
    {
        foreach (ITicketChangeListener observer in _observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

/// <summary>
/// Concrete Subject -- OrderService, whose state the observers are intrested in
/// </summary>

public class OrderService : TicketChangeNotifier
{
   public void CompleteTicketSale(int artistId, decimal amount)
    {
        //do CRUD operation on datastoren here
        WriteLine($"{nameof(OrderService)} is changing it's state");

        //notify observers
        WriteLine($"{nameof(OrderService)} is notifying  it's observers");
        Notify(new TicketChange(amount, artistId));
    }
}


/// <summary>
/// Concrete Observer A
/// </summary>
public class TicketResellerService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        //update local data store here-------
        WriteLine();
        WriteLine($"{nameof(TicketResellerService)} notified " +
            $" of ticket change:  artist  {ticketChange.ArtistId}, amount {ticketChange.Amount}");           
    }
}


/// <summary>
/// Concrete Observer B
/// </summary>
public class TicketStockService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        //update local data store here-------
        WriteLine();
        WriteLine($"{nameof(TicketStockService)} notified " +
            $" of ticket change:  artist  {ticketChange.ArtistId}, amount {ticketChange.Amount}");
    }
}