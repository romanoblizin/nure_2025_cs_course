using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Course.Classes
{
    public enum TransactionType
    {
        Transfer,
        Deposit,
        Withdraw,
        Payment,
        ServicePayment,
        Interest,
        Payout,
        CreditPayment,
        DepositPayment
    }

    class Transaction
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string? Target { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(string number, DateTime date, double amount, string? target, string description, TransactionType type)
        {
            Number = number;
            Date = date;
            Amount = amount;
            Target = target;
            Description = description;
            Type = type;
        }
        public Transaction(string number, double amount, string? target, string description, TransactionType type)
        {
            Number = number;
            Date = DateTime.Now;
            Amount = amount;
            Target = target;
            Description = description;
            Type = type;
        }
    }
}
