using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace BankLibrary
{
    internal class Transaction
    {
        public DateTime Date { get; set; }  
        public decimal Amount { get; set; }
        
        public string AmountInWords {
            get {

                return Humanizer.NumberToWordsExtension.ToWords((int)Amount);
                           
            }
        }
        public string Detail { get; set; }

        public string Type { get; set; }


        public Transaction(DateTime date, decimal amount, string detail, string type) 
        {
            this.Date = date;
            this.Amount = amount;
            this.Detail = detail;
            this.Type = type;
        }
    
    }
}
