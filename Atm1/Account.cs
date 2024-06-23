namespace Atm1;

internal class Account
{
    private string pin;
    public decimal Balance { get; private set; }

    public Account()
    {
        pin = "1234";
        Balance = 0;
    }

    public bool ValidatePin(string inputPin)
    {
        return inputPin == pin;
    }

    public bool ChangePin(string newPin)
    {
        if (newPin.Length == 4 && int.TryParse(newPin, out _))
        {
            pin = newPin;
            return true;
        }
        return false;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}

