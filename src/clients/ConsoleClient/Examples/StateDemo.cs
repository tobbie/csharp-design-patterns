using State;
using static System.Console;


namespace ConsoleClient.Examples
{
    public static class StateDemo
    {
        public static void Run()
        {
            BankAccount bankAccount = new();
            bankAccount.Deposit(100);
            WriteLine($"current balance is: {bankAccount.Balance}");
            bankAccount.Withdraw(500);
            WriteLine($"current balance is: {bankAccount.Balance}");
            bankAccount.Withdraw(100);
            WriteLine($"current balance is: {bankAccount.Balance}");

            //deposit enough money to get to gold state
            bankAccount.Deposit(2000);
            WriteLine($"current balance is: {bankAccount.Balance}");

            //should be in gold state now
            bankAccount.Deposit(200);
            WriteLine($"current balance is: {bankAccount.Balance}");


            //back to overdrawn
            bankAccount.Withdraw(3000);
            WriteLine($"current balance is: {bankAccount.Balance}");


            //should transition to regular
            bankAccount.Deposit(3000);
            WriteLine($"current balance is: {bankAccount.Balance}");


            //should now transition to gold again
            bankAccount.Deposit(100);
            WriteLine($"current balance is: {bankAccount.Balance}");


            WriteLine($" Now in state : {bankAccount.BankAccountState.GetType()}");
            bankAccount.Deposit(500);
            WriteLine($"current balance is: {bankAccount.Balance}");

            ReadKey();

            //Rules
            // An account tranistions to overdrawn state when balance is less than zero
            // A user cannot withdraw money from an account in overdrawn state
            // An account transitions to regular state when balance is greater than or equal to zero
            // An account transtions to gold state when banalce is greater than 1000
            // An account in overdrwan state acccount automatically transition to gold state. It firsts moves into regular state.

        }
    }
}
