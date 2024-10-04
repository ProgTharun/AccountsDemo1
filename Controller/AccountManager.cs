using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using AccountsDemo1.Controller;
using AccountsDemo1.Model;
using Newtonsoft.Json;

public class AccountManager
{
          List<Account> accounts;
    private const string FileName = "accounts.json";
     static string filepath = ConfigurationManager.AppSettings["Myfilepath"];
    public AccountManager()
    {
        accounts = new List<Account>();
        Deserialzer();
    }

    public void CreateAccount(double accountNumber, string accountHolderName, string bankName, double balance)
    {
        {
            Account account = new Account(accountNumber, accountHolderName, bankName, balance);
            accounts.Add(account);
            Serializer();
        }
    }

    public void Deposit(double accountNumber, double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new MustBePositiveException("Deposit amount must be positive.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                account.Deposit(amount);
                Serializer();
                return;
            }
        }
    }

    public void Withdraw(double accountNumber, double amount)
    {
        

        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                account.Withdraw(amount);
                Serializer();
                return;
            }
        }
    }

    public Account GetAccountDetails(double accountNumber)
    {
        try
        {
            if (accounts == null)
            {
                throw new InvalidAccountException("Account must be added.");
            }
        }
        catch (InvalidAccountException ex)
        {
            Console.WriteLine(ex.Message);
        }
        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;
    }
    public void Exit()
    {
        Environment.Exit(0);
    
    }
    private void Serializer()
    {
        File.WriteAllText(FileName, JsonConvert.SerializeObject(accounts));
    }

    private void Deserialzer()
    {
        if (File.Exists(FileName))
        {
            accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(FileName));
        }
    }
}
