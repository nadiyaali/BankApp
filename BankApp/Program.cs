// See https://aka.ms/new-console-template for more information

using System;
using BankLibrary;

namespace BankApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Hello World!");
            var account = new BankAccount("Nadia",500);
            Console.WriteLine($"Account number {account.AccountNumber} was created for {account.Owner} with balance {account.Balance}");
            account.MakeDeposit(4000, DateTime.Now, "First deposit made");
            account.MakeWithdrawal(1000, DateTime.Now, "First withdrawal");
            account.MakeDeposit(3672, DateTime.Now, "Second deposit made");

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}