namespace TemplateMethod;
using static System.Console;

/**
 * TEMPLATE METHOD COMPONENTS
 * 1. Abstract Class with the template method that defines the order in wich other methods are called
 * 2. Concrete classes (Concerte Class A, Concrete Class B) that implement the abstract class 
 * and  overide the methods with their unique implementations
 * Note: The template method is not overriden as it defines the order in with the other methods are called.
 */


public abstract class MailParser
{
   public virtual void FindServer()
    {
        WriteLine("Finding server.....");
    }

    public abstract void AuthenticateToServer();

    public string ParseHtmlMailBody(string identifier)
    {
        WriteLine("Parsing HTML mail body.....");
        return $"This is the body of mail with id {identifier}";
    }

    /// <summary>
    /// Template method here we define the algorithm by calling the other methods  in order.
    /// </summary>
    /// <param name="identifier"></param>
    /// <returns></returns>
    public string ParseMailBody(string identifier)
    {
        WriteLine("Parsing mail body (in template method).....");
        FindServer();
        AuthenticateToServer();
        return ParseHtmlMailBody(identifier);
    }
}

public class ExchangeMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        WriteLine("Connecting to Exchange....");
    }
}

public class ApacheMailParser: MailParser
{
    public override void AuthenticateToServer()
    {
        WriteLine("Connecting to Apache");
    }
}

public class EudoraMailServer : MailParser
{
    public override void FindServer()
    {
        WriteLine("Finding Eudora server through a custom algorithm.....");
    }

    public override void AuthenticateToServer()
    {
       
        WriteLine("Connecting to Eudora");
    }
}




