namespace Singleton;
using static System.Console;

/// <summary>
/// Singleton
/// </summary>
public class Logger
{
    //enables a thread safe implementation.
    private static readonly Lazy<Logger> _lazzyLogger
         = new Lazy<Logger>(() => new Logger());

    //private static Logger? _instance;

    /// <summary>
    /// Instance
    /// </summary>
    public static Logger Instance
    {
        get
        {
            return _lazzyLogger.Value;
            //if (_instance == null)
            //    _instance = new Logger();

            // return _instance;
        }

    }

    //set constructor as private or protected so clients can't instantiate it.
    protected Logger() { }
    public void Log(string message)
    {
        WriteLine($"Message to log: {message}");
    }
}



