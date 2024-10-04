
using AccountsDemo1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Account
{
    public double AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public string BankName { get; set; }
    public double Balance { get; set; }

    public const double MinimunBalance = 500;

    public Account(double accountNumber, string accountHolderName, string bankName, double balance)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        BankName = bankName;
        Balance = MinimunBalance;
    }

    public void Deposit(double amount)
    {
      
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Withdraw(double amount)
    {
        try
        {
            if (Balance - amount < MinimunBalance)
            {
                throw new MinimumBalanceException("Account must maintain minimum balance.");
            }
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

            if (amount > MinimunBalance && amount <= Balance)
        {
            Balance -= amount;
        }
    }

    public override string ToString()
    {
        return $" AccountNumber={AccountNumber}, AccountHolderName={AccountHolderName}, BankName={BankName}, Balance={Balance}";
    }
}
