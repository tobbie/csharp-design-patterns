using Singleton;
using static System.Console;

namespace ConsoleClient.Examples
{
    internal static class SingletonDemo
    {
        public static void Run()
        {
            Title = "Singleton Pattern";
            var instance1 = Logger.Instance;
            var instance2 = Logger.Instance;

            if (instance1 == instance2 && instance2 == Logger.Instance)
            {
                WriteLine("Instances are the same");
            }

            instance1.Log($"message from {nameof(instance1)}");
            //or
            instance2.Log($"message from {nameof(instance2)}");
            //or
            Logger.Instance.Log($"message from {nameof(Logger.Instance)}");

            ReadLine();


        }
    }
}
