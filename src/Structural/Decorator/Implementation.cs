using System.Reflection.PortableExecutable;
using static System.Console;
namespace Decorator;


/**
 **** DECORATOR COMPONENTS****
 * 1. Component (interfact or abstract class) - IMailService
 * 2. ConcreteComponent1, ConcreteComponent2... etc - CloudMailService, OnPremiseMailService
 * 3. Decorator (abstract class)
 * 4. ConcreteDecorator1, ConcreteDeocrator2 ....etc --- StatisticsDecorator, MessageDatabaseDecorator
 * 5  Link to UML -->
**/


/// <summary>
/// Component (as interface)
/// </summary>
public interface IMailService
{
    bool SendMail(string message);
}

/// <summary>
/// ConcreteComponent1
/// </summary>
public class CloudMailService : IMailService
{
    public bool SendMail(string message)
    {
        WriteLine($"Message {message} sent via {nameof(CloudMailService)}.");
        return true;
    }
}


/// <summary>
/// ConcreteComponent2
/// </summary>
public class OnPremiseMailService : IMailService
{
    public bool SendMail(string message)
    {
        WriteLine($"Message {message} sent via {nameof(OnPremiseMailService)}.");
        return true;
    }
}



/// <summary>
/// Decorator - base wrappper
/// </summary>
public abstract class MailServiceDecoratorBase : IMailService
{
    private readonly IMailService _mailService;

    public MailServiceDecoratorBase(IMailService mailService)
    {
        _mailService = mailService;
    }

    public virtual bool SendMail(string message)
    {
        return _mailService.SendMail(message);
    }
}


/// <summary>
/// ConcreteDecorator1
/// </summary>
public class StatisticsDecorator : MailServiceDecoratorBase
{
    public StatisticsDecorator(IMailService mailService)
        : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
        return base.SendMail(message);
    }
}


/// <summary>
/// ConcreteDecorator2
/// </summary>
public class MessageDatabaseDecorator : MailServiceDecoratorBase
{
    public List<string> SentMessages { get; private set; }  = new List<string>();
    public MessageDatabaseDecorator(IMailService mailService)
        : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        if (base.SendMail(message))
        {
            SentMessages.Add(message);
            return true;
        }
        return false;
    }
}

