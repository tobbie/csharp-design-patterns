using Prototype;
using static System.Console;

namespace ConsoleClient.Examples
{
    internal static class PrototypeDemo
    {
        public static void Run()
        {
            Title = "Prototype";
            var manager = new Manager("Cindy");
            var managerClone = (Manager)manager.Clone();

            WriteLine($"Manager was cloned: {managerClone.Name}");

            var employee = new Employee("Kevin", managerClone);
            var employeeClone = (Employee)employee.Clone(true);

            WriteLine($"Employee was cloned: {employeeClone.Name}, with manager {employeeClone.Manager.Name}");

            //change manager name
            managerClone.Name = "Karen";
            WriteLine($"Employee was cloned: {employeeClone.Name}, with manager {employeeClone.Manager.Name}");
            ReadKey();

        }
    }
}
