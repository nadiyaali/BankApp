using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Humanizer;

namespace BankLibrary
{
   public class BankAccount
    {
        public string AccountNumber { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in Transactions) 
                {
                    balance += item.Amount;
                }
                
                return balance;
            }

         }

        private List<Transaction> Transactions = new List<Transaction>();
        
        private static int accountNumberSeed = 1234567890;
        public BankAccount(string owner, decimal amount)
        {
            this.Owner = owner;
            this.AccountNumber = accountNumberSeed.ToString();
            MakeDeposit(amount, DateTime.Now, "Initial Deposit");
            accountNumberSeed++;
        }


        public void MakeWithdrawal(decimal amount, DateTime date, string detail)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount of withdrawal must be positive");
            }
            if (this.Balance - amount < 0)
            {
                throw new InvalidOperationException("You don't have sufficient funds");
            }

            var tr = new Transaction(date,-amount,detail, "WITHDRAWAL");
            this.Transactions.Add(tr);
            Console.WriteLine($"WITHDRAWAL : {amount}\t Current Balance :{this.Balance}");
        }


        public void MakeDeposit(decimal amount, DateTime date, string detail)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount of deposit must be positive");
            }
            
            var tr = new Transaction(date, amount, detail, "DEPOSIT");
            this.Transactions.Add(tr);
            Console.WriteLine($"DEPOSIT : {amount}\t Current Balance :{this.Balance}");
        }

        public string GetAccountHistory() 
        { 
            var report = new StringBuilder();
            report.AppendLine("ALL TRANSACTIONS");
            foreach ( Transaction tr in this.Transactions ) 
            {
                report.AppendLine($"{tr.Type}\t{tr.Date.Date} \t{tr.Amount} \t {tr.AmountInWords} \t{tr.Detail} ");
            }
            

            return report.ToString();
        }

    }
}
