namespace Atm1;

public class ATM
{
    private Account account;

    public ATM()
    {
        account = new Account();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the ATM!");

        for (int attempts = 0; attempts < 3; attempts++)
        {
            Console.Write("Please enter your PIN: ");
            string inputPin = Console.ReadLine();

            if (account.ValidatePin(inputPin))
            {
                ShowMenu();
                return;
            }
            else
            {
                Console.WriteLine("Incorrect PIN. Try again.");
            }
        }

        Console.WriteLine("You have entered an incorrect PIN 3 times. Your account is locked.");
    }

    private void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nATM Menu:");
            Console.WriteLine("1. Withdraw Money");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Change PIN");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WithdrawMoney();
                    break;
                case "2":
                    DepositMoney();
                    break;
                case "3":
                    ChangePin();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void WithdrawMoney()
    {
        Console.Write("Enter amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"You have withdrawn {amount:C}. Your new balance is {account.Balance:C}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    private void DepositMoney()
    {
        Console.Write("Enter amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            account.Deposit(amount);
            Console.WriteLine($"You have deposited {amount:C}. Your new balance is {account.Balance:C}.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    private void ChangePin()
    {
        Console.Write("Enter your current PIN: ");
        string currentPin = Console.ReadLine();

        if (account.ValidatePin(currentPin))
        {
            Console.Write("Enter your new PIN: ");
            string newPin = Console.ReadLine();

            if (account.ChangePin(newPin))
            {
                Console.WriteLine("Your PIN has been changed successfully.");
            }
            else
            {
                Console.WriteLine("PIN change failed. New PIN should be 4 digits.");
            }
        }
        else
        {
            Console.WriteLine("Incorrect current PIN.");
        }
    }
}

