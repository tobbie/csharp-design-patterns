namespace State;
using static System.Console;

/******
 * STATE PATTERN COMPONENTS
 * =========================================================
 * 1. State - (abstract class or interface)
 * 2. ConcreteState1, ConcreteState2,.... etc (concrete classes that implement abstract class or interface)
 * 3. Context (class that uses the abstract state component)
*****/



/// <summary>
/// State
/// </summary>
public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;

    public decimal Balance { get; protected set; }
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

public class RegularState : BankAccountState
{
    public RegularState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        WriteLine($"In {GetType()}, depositing amount {amount} to balance {Balance}");
        Balance += amount;
       

        if (Balance >= 1000)
        {
            //change to gold state
            BankAccount.BankAccountState = new GoldState(BankAccount, Balance);
        }
    }

    public override void Withdraw(decimal amount)
    {
        WriteLine($"In {GetType()}, withdrawing amount  {amount} from {Balance}");
        Balance -= amount;

        //change state to overdrawn when withdrawing is less than zero
        if (Balance < 0)
            BankAccount.BankAccountState = new OverDrawnState(BankAccount, Balance);
    }
}

public class OverDrawnState : BankAccountState
{
    public OverDrawnState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        WriteLine($"In {GetType()}, depositing amount {amount} to balance");
        Balance += amount;

        //change state to regular when balance is zero or greater
        if (Balance >= 0)
            BankAccount.BankAccountState = new RegularState(BankAccount, Balance);
    }

    public override void Withdraw(decimal amount)
    {
        //cannot withdraw in overdrawn state
        WriteLine($"In {GetType()} cannot withdraw, balance {Balance}");
    }
}

public class GoldState : BankAccountState
{
    public GoldState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }
    public override void Deposit(decimal amount)
    {
        WriteLine($"In {GetType()}, depositing {amount} + 10% bonus: {amount / 10}");
        Balance += (amount + (amount / 10));
    }

    public override void Withdraw(decimal amount)
    {
        WriteLine($"In {GetType()}, withdrawing amount  {amount} from {Balance}");
        Balance -= amount;

        if (Balance < 1000 && Balance >= 0)
        {
            //change state back to regular
            BankAccount.BankAccountState = new RegularState(BankAccount, Balance);
        }
        else if (Balance < 0)
        {
            //change state to overdrawn
            BankAccount.BankAccountState = new OverDrawnState(BankAccount, Balance);
        }
    }
}

public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    public decimal Balance { get { return BankAccountState.Balance; } }
    public BankAccount()
    {
        BankAccountState = new RegularState(this, 200);
    }

    public void Deposit(decimal amount)
    {
        //let the current state handle the deposit.
        BankAccountState.Deposit(amount);
    }

    public void Withdraw(decimal amount)
    {
        //let the current state handle the withdrawal
        BankAccountState.Withdraw(amount);
    }
}



