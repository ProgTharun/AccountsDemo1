
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class AccountPresentation
{
     static AccountManager controller = new AccountManager();
   
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("==========Menu:===========");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Show Details");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    GetAccountDetails();
                    break;
                case 5:
                    Exit();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }

    }
    public static void CreateAccount()
    {
        Console.Write("Enter account number: ");
        double accountNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter account holder name: ");
        string accountHolderName = Console.ReadLine();
        Console.Write("Enter bank name: ");
        string bankName = Console.ReadLine();
        Console.Write("Enter initial balance: ");
        double balance = double.Parse(Console.ReadLine());
        controller.CreateAccount(accountNumber, accountHolderName, bankName, balance);
    }
    public static void Deposit()
    {
        Console.Write("Enter account number: ");
        double accountNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter amount to deposit: ");
        double depositAmount = double.Parse(Console.ReadLine());
        controller.Deposit(accountNumber, depositAmount);

    }
    public static void Withdraw()
    {
        Console.Write("Enter account number: ");
        double accountNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter amount to withdraw: ");
        double withdrawAmount = double.Parse(Console.ReadLine());
        controller.Withdraw(accountNumber, withdrawAmount);
    }
    public static void GetAccountDetails()
    {
        Console.Write("Enter account number: ");
       double  accountNumber = double.Parse(Console.ReadLine());
        Account account = controller.GetAccountDetails(accountNumber);
        if (account != null)
        {
            Console.WriteLine(account);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
       
        
    }
    public static void Exit()
    {
        Console.WriteLine("Exiting...");
        controller.Exit();
    }

}
