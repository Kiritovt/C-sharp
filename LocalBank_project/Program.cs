using Bank;

public class Run
{
    public static void Main(string[] args)
    {
        BankAccount Account = new BankAccount();
        bool TurnOff = false;
        Console.WriteLine("Insert your name:");
        string? name = Console.ReadLine();
        Account.AccountHolder = name ?? "";
        while (!TurnOff)
        {

            Console.WriteLine("===== Bank Account =====");
            int choice = ReadNumber("1. Deposit\n2. WithDraw\n3. Show balance\n0. Exit");
            double funds;
            switch (choice){
                case 1:
                    funds = ReadNumber("Enter the amount of funds to add:");
                    if (Account.Deposit(funds) == true)
                    {
                        Console.WriteLine($"You have added {funds}€ to your balance. Now you have {Account.Balance}€");
                    }
                    else
                    {
                        Console.WriteLine($"The funds input is invalid.");
                    }
                    break;


                case 2:
                    funds = ReadNumber("Enter the funds that u spent:");
                    if (Account.Withdraw(funds) == true)
                    {
                        Console.WriteLine($"You have subtracted {funds}€ to your balance. Now you have {Account.Balance}€");
                    }
                    else
                    {
                        Console.WriteLine($"You can't subtract {funds}€ to your balance for not enough funds.");
                    }
                    break;

                case 3:
                    Console.WriteLine($"Your actual balance is: {Account.GetBalance()}");
                    break;

                case 0:
                    TurnOff = true;
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

    private static int ReadNumber(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
