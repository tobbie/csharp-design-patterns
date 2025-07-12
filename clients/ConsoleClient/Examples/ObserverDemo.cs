using static System.Console;
using Observer;

namespace ConsoleClient.Examples
{
    static class ObserverDemo
    {
        public static void Run()
        {
            Title = "The Observer Pattern";
            WriteLine("---Running Observer Demo-----");

            TicketResellerService ticketResellerService = new();
            TicketStockService ticketStockService = new();
            OrderService orderService = new();

            //add two observers
            orderService.AddObserver(ticketResellerService);
            orderService.AddObserver(ticketStockService);

            WriteLine();
            //notify
            orderService.CompleteTicketSale(1, 5000);

            WriteLine();
            
            //remove observer
            orderService.RemoveObserver(ticketResellerService);

            //notify
            orderService.CompleteTicketSale(2, 8000);
            
            WriteLine();
            ReadKey();

        }
    }
}
