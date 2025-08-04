
using static System.Console;
using Decorator;

namespace ConsoleClient.Examples;

 static class DecoratorDemo
 {
    public static void Run()
    {
        Title = "Decorator Demo";

        var cloudMailService = new CloudMailService();
        cloudMailService.SendMail("Good day from the cloud mail service....");

        WriteLine();

        var onPremiseMailService  = new OnPremiseMailService();
        onPremiseMailService.SendMail("Good day from the on-premise mail service");

        WriteLine();

        //add behaviour
        var statisticsDecorator = new StatisticsDecorator(cloudMailService);
        statisticsDecorator.SendMail($"Good day via {nameof(StatisticsDecorator)} wrapper");

        WriteLine();

        //add behaviour
        var messageDecorator  = new MessageDatabaseDecorator(onPremiseMailService);
        messageDecorator.SendMail($"Good day via {nameof(messageDecorator)} wrapper, message 1.");
        WriteLine();

        messageDecorator.SendMail($"Good day via {nameof(messageDecorator)} wrapper, message 2.");
        WriteLine();

        foreach (var message in messageDecorator.SentMessages)
            WriteLine($"stored message: \"{message}\"");

        ReadKey();
    }


 }

