namespace Bank;

public class BankAccount
{
    public double Balance { get; private set; } = 0;
    public string AccountHolder { get; set; } = "";
    public bool Deposit(double a)
    {
        if (a > 0)
        {
            Balance = Balance + a;
            return  true;
        }
        else
        {
            return false;
        }
    }
    public bool Withdraw(double a)
    {
        if (Balance < a || a <= 0)
        {
            return false;
        }
        else
        {   
            Balance = Balance - a;
            return true;
        }
    }

    public double GetBalance()
    {
        return Balance;
    }
    
}