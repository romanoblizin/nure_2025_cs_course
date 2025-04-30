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
        Interest,
        CreditPayment,
        DepositPayment
    }

    class Transaction // -> + подкласс, который имеет таргет
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(int id, DateTime date, double amount, string description, TransactionType type)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
            Type = type;
        }
        public Transaction(int id, double amount, string description, TransactionType type)
        {
            Id = id;
            Date = DateTime.Now;
            Amount = amount;
            Description = description;
            Type = type;
        }
    }
}
