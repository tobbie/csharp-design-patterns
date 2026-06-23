using TemplateMethod;
using static System.Console;

namespace ConsoleClient.Examples
{
    public static class TemplateMethodDemo
    {
        public static void Run()
        {
            ExchangeMailParser exchangeMailParser = new();
            WriteLine(exchangeMailParser.ParseMailBody(Guid.NewGuid().ToString()));

            WriteLine();
            ApacheMailParser apacheMailServer = new();
            WriteLine(apacheMailServer.ParseMailBody(Guid.NewGuid().ToString()));

            WriteLine();
            EudoraMailServer eudoraMailServer = new();
            WriteLine(eudoraMailServer.ParseMailBody(Guid.NewGuid().ToString()));

            ReadKey();

        }
    }
}
